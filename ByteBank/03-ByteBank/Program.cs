using System;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("03 - Byte Bank");
            //tipo de referencia - guarda endereço do objeto
            ContaCorrente contaGabriela = new ContaCorrente();
            contaGabriela.titular = "Gabriela";
            contaGabriela.agencia = 123;
            contaGabriela.numero = 78945;
            contaGabriela.saldo = 9;

            ContaCorrente contaGabrielaCosta = new ContaCorrente();
            contaGabrielaCosta.titular = "Gabriela";
            contaGabrielaCosta.agencia = 123;
            contaGabrielaCosta.numero = 78945;
            contaGabrielaCosta.saldo = 9;

            Console.WriteLine("Igualdade de tipo referencia: " + (contaGabriela == contaGabrielaCosta)); // false

            Console.WriteLine("Igualdade de tipo valor campo da classe: " + (contaGabriela.numero == contaGabrielaCosta.numero)); // true

            //tipo de valor
            int idade = 29;
            int idade2 = 29;

            Console.WriteLine("Igualdade de tipo valor: " + (idade == idade2));

            contaGabriela = contaGabrielaCosta;
            Console.WriteLine(contaGabriela == contaGabrielaCosta);

            contaGabriela.saldo = 300;

            if(contaGabrielaCosta.saldo >= 100)
            {
                contaGabrielaCosta.saldo -= 100;
            }




        }
    }
}
