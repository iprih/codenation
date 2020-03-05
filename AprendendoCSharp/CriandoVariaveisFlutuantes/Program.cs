using System;

namespace CriandoVariaveisFlutuantes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Criando Variaveis com Ponto Flutuante");

            double salario = 2.9;
            Console.WriteLine(salario);
            
            int valorUm = 5;
            int ValorDois = 2;
            int resultado = valorUm / ValorDois;
            Console.WriteLine(resultado);

            double varDouble = 2.0;
            double varDouble2 = 5.0;
            double resInteiro = valorUm / ValorDois;
            double resDouble = valorUm / varDouble;
            double resDouble2 = varDouble2 / varDouble;

            Console.WriteLine("Resultado inteiro é " + resInteiro);
            Console.WriteLine("Resultado double é " + resDouble);
            Console.WriteLine("Resultado doble" + resDouble2);
            Console.ReadKey();

        }
    }
}
