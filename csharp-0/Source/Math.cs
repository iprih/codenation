using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public static void Main(string[] args)
        {
            
        }
        public List<int> Fibonacci()
        {
            int numero1 = 0;
            int numero2 = 1;
            int numeroFibonacci = 0;

            List<int> lista = new List<int>();

            lista.Add(numero1);
            lista.Add(numero2);

            for (int i = 0; numeroFibonacci < 350; i++)
            {

                numeroFibonacci = numero1 + numero2;
                numero1 = numero2;
                numero2 = numeroFibonacci;
                if (numeroFibonacci < 350)
                {
                    lista.Add(numeroFibonacci);
                }
            }
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            return lista;
            throw new NotImplementedException();
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}
