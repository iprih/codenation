using System;

namespace _7___Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabalhando com Condicionais");

            int idadeCarla = 16;
            //int qtdPessoas = 2;
            bool acompanhada = false;

            string msgAdicional = string.Empty;

            if (acompanhada)
                msgAdicional = "Carla esta acompanhada";
            else
              msgAdicional = "Carla nao está acompanhada";


            if (idadeCarla >= 18 || acompanhada == true)
            {
                Console.WriteLine("Pode entrar");
                Console.WriteLine(msgAdicional);
            }
            else
            {
                Console.WriteLine("Nao pode entrar");
                Console.WriteLine(msgAdicional);
            }

        }
    }
}