using ByteBank;
using System;

namespace ByteBank_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            Metodo();

            Console.ReadLine();
        }

        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            try
            {
                int resultado = Dividir(10, divisor);
                Console.WriteLine("Resultado da divisão de 10 por " + divisor + " igual a " + resultado);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Não é possível fazer divisão por zero!\n");
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            //ContaCorrente conta = null;

            //Console.WriteLine(conta.Saldo);

            return numero / divisor;
        }
    }
}
