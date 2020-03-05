using System;

namespace P10___LacoesRepeticaoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("While");

            int cont = 1;
            int total = 0;

            while (cont <= 10)
            {
                total = cont;
                Console.WriteLine(total);
                cont ++;
            }
            Console.WriteLine(cont);
            Console.WriteLine(total);
        }
    }
}
