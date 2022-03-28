using System;
using System.IO;

namespace ByteBank_Exceptions
{
    public class LeitorDeArquivos
    {
        public string Arquivo { get; set; }
        public LeitorDeArquivos(string arquivo)
        {
            Arquivo = arquivo;

            throw new FileNotFoundException();

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");

            //Excecao de entrada ou saida (no nosso caso é arquivo)
            throw new IOException();

            return "Linha do arquivo";
        }

        public void Fechar()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
