using System;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("04 - Byte Bank");

            ContaCorrente contaBruna = new ContaCorrente();
            contaBruna.titular = "Bruna";

            Console.WriteLine("saldo original " + contaBruna.saldo);

            bool resultadoSaque = contaBruna.Sacar(1);
            Console.WriteLine("Resultado metodo sacar: " + resultadoSaque + " e o saldo ficou " + contaBruna.saldo);

            contaBruna.Depositar(500);
            Console.WriteLine("Apos depoisto " + contaBruna.saldo);

            ContaCorrente contaGabriela = new ContaCorrente();
            Console.WriteLine("Saldo bruna: " + contaBruna.saldo);
            Console.WriteLine("Saldo Gabriela: " + contaGabriela.saldo);

            bool resultadoTransferencia = contaBruna.Transferir(100, contaGabriela);
            Console.WriteLine("Resultado da transferencia: " + resultadoTransferencia);
            Console.WriteLine("Saldo bruna após: " + contaBruna.saldo);
            Console.WriteLine("Saldo Gabriela após: " + contaGabriela.saldo);
        }
    }
}
