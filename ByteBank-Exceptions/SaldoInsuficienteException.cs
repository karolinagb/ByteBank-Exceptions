using System;

namespace ByteBank_Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {

        }

        public SaldoInsuficienteException()
        {

        }

        //this usa o construtor da classe atual
        //base usa o construtor da classe mãe da herança
        public SaldoInsuficienteException(double saldo, double valorSaque) : this("Tentativa de saque do valor de " 
            + valorSaque + " em uma conta com saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
    }
}
