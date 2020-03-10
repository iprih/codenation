using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("01 - Byte Bank");

            //string nomeTitular = "Gabriela";
            //int numeroAgencia = 123;
            //int numeroConta = 789456;
            //double saldo = 100;

            //string nomeTitular2= "Tais";
            //int numeroAgencia2 = 321;
            //int numeroConta2 = 45788;
            //double saldo2 = 199;

            Console.WriteLine();

            ContaCorrente contaGabriela = new ContaCorrente();

            contaGabriela.titular = "Gabriela";
            contaGabriela.agencia = 123;
            contaGabriela.numero = 456789;
            contaGabriela.saldo = 100;

            Console.WriteLine("Saldo " + contaGabriela.saldo);

            contaGabriela.saldo += 100;
            Console.WriteLine("Saldo atual " + contaGabriela.saldo);
    

            Console.ReadKey();
        }
    }
}
