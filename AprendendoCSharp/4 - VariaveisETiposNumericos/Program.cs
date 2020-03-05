using System;

namespace _4___VariaveisETiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Criando variaveis e tipos numericos");

            int v1 = 5;
            int v2 = 2;
            double res = (double)v1 / v2;

            long n1 = 1333333333;// 64bits
            short n2 = 155; // 16 bits

            float altura = 1.5555f;

            Console.WriteLine(altura);


            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
