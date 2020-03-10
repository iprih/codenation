using System;

namespace _02_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("02 - Byte Bank");

            ContaCorrente conta = new ContaCorrente();

            conta.titular = "Gabriela";
            Console.WriteLine(conta.saldo);
            Console.WriteLine(conta.agencia);
            conta.saldo = 200;
            Console.WriteLine(conta.saldo);


            Console.ReadKey();
        }
    }
}
