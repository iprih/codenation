using System;

namespace P14___LacoFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laco 4");


            for (int linha = 0; linha < 10; linha++)
            {
                for (int coluna = 0; coluna < 10; coluna++)
                {
                    if (coluna > linha)
                    {
                        break;
                    }
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
