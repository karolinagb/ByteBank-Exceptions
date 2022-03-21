using ByteBank;
using System;

namespace ByteBank_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Metodo();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Não é possível divisão por zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Aconteceu um erro");
            }

            Console.ReadLine();
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
            var divisao =  numero / divisor;

            ContaCorrente conta = null;

            Console.WriteLine(conta.Saldo);

            return divisao;
        }
    }
}
