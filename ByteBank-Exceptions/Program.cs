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
                ContaCorrente conta = new ContaCorrente(8090, 9080);
                Metodo();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ocorreu uma ArgumentException");
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Não é possível divisão por zero.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
