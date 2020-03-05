using System;

namespace _5___CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caracteres e textos");

            char primeiraLetra = 'a'; //aspas simples somente para caracter

            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)(primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);

            string titulo = "Codenation C# Women Itau";
            Console.WriteLine(titulo);

            string modulos = 
@"Variaveis
Orientação Objeto
Clean Code";

            Console.WriteLine(modulos);
        }
    }
}
