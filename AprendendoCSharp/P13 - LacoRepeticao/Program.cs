using System;

namespace P13___LacoRepeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int numero = 0; numero <= 10; numero++) // for encadeado
            {
                Console.Write("Tabuada do " + numero + " : ");
                for (int multiplicador = 0; multiplicador < 10; multiplicador++)
                {
                    Console.Write(numero * multiplicador);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
