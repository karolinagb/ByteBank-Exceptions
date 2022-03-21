// using _05_ByteBank;

using ByteBank_Exceptions;
using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        //propriedades statics sao aquelas que serao compartilhadas por todas as instancias da classe
        //é uma propriedade relativa a classe e não ao objeto
        public static double TaxaOperacao { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }

        public int Agencia { get; }

        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                ArgumentException excecao = new ArgumentException("A agencia deve ser maiores que 0.", nameof(agencia));

                //throw sozinho só dá para ser usado em um contexto que tenha uma exceção
                //Posso usar o throw passando  qual exceção quero lançar
                throw excecao;
            }

            if (numero <= 0)
            {
                ArgumentException excecao = new ArgumentException("Número deve ser maiores que 0.", nameof(numero));

                //throw sozinho só dá para ser usado em um contexto que tenha uma exceção
                //Posso usar o throw passando  qual exceção quero lançar
                throw excecao;
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            Sacar(valor);
            contaDestino.Depositar(valor);
            
        }
    }
}
