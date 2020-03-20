using System;
using System.Collections.Generic;

namespace SequenciaFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //chamando o metodo
            Fibonacci();
                
                //Console.WriteLine("Hello World!");
        }
        public static List<int> Fibonacci()
        {
            int numero1 = 0;
            int numero2 = 1;
            int numeroFibonacci = 0;

            //lista para add a sequencia
            List<int> list = new List<int>();
                      
            //variaveis da lista
            list.Add(numero1);
            list.Add(numero2);

            //condição inicia em 0 e enquanto o calculo for menor que 350 irá adicionar os numeros na lista 
            for (int i = 0; numeroFibonacci < 350; i++)
            {
                
                numeroFibonacci = numero1 + numero2; 

                numero1 = numero2;

                numero2 = numeroFibonacci;
                Console.WriteLine("testando resultado do calculo acima" + numeroFibonacci);

                if (numeroFibonacci < 350)
                {
                    list.Add(numeroFibonacci);
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            return list;
            throw new NotImplementedException();
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    
}
}
