using ByteBank;
using System;
using System.IO;

namespace ByteBank_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                CarregarContasCorrente();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no metodo main");
            }

            Console.ReadLine();
        }

        private static void CarregarContasCorrente()
        {
            LeitorDeArquivos leitor = null;

            try
            {
                leitor = new LeitorDeArquivos("contas.txt");

                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            finally
            {
                if (leitor != null)
                {
                    leitor.Fechar();
                }
            }
        }

        private static void TestaExcecoes()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(8090, 9080);

                ContaCorrente conta2 = new ContaCorrente(4850, 5048);

                conta2.Transferir(1000, conta);

                conta.Depositar(50);
                Console.WriteLine(conta.Saldo);
                conta.Sacar(-500);
                Metodo();

                ContaCorrente conta3 = new ContaCorrente(4564, 789684);
                ContaCorrente conta4 = new ContaCorrente(7891, 456794);

                //conta4.Transferir(10000, conta2);
                conta4.Sacar(10000);
            }
            //catch (SaldoInsuficienteException e)
            //{
            //    Console.WriteLine(e.Saldo);
            //    Console.WriteLine(e.ValorSaque);

            //    Console.WriteLine(e.StackTrace);

            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("Exceção de SaldoInsuficienteException");
            //}
            catch (ArgumentException e)
            {
                Console.WriteLine("Argumento com problema " + e.ParamName);
                Console.WriteLine("Ocorreu uma ArgumentException");
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Não é possível divisão por zero.");
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.InnerException.StackTrace);
                Console.WriteLine(e.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Aconteceu um erro");

            }
        }

        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {

            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " igual a " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com número=" + numero + " e divisor=" + divisor);
                throw; //Lança a exceção que aconteceu aqui dentro e saimos desse fluxo pois ele encerra o metodo
            }
        }
    }
}
