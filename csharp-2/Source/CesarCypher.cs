using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {


        public string Crypt(string message)
        {
            var mensagem = "";
            int inicio = 97;
            int fimDeAlfabeto = 122;

            if (message == null)
            {
                throw new ArgumentNullException();

            }
            else if (!message.ToCharArray().All(x => (char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)) && x < 127))
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (message == "")
            {
                return "";
            }
            else
            {
                foreach (var percorre in message.ToLower())
                {
                    //se for uma letra
                    if (char.IsLetter(percorre))
                    {
                        var letra = percorre;
                        var criptografando = letra + 3;

                        if (criptografando > fimDeAlfabeto)
                        {
                            criptografando = inicio;
                        }

                        mensagem += (char)criptografando;
                    }
                    else
                    {
                        mensagem += percorre;
                    }
                }
            }
            return mensagem;
        }

      
        //public string Decrypt(string cryptMessage)
        //{
        //    var message = "";
        //    int inicio = 97;

        //    if (cryptMessage == null)
        //    {
        //        throw new ArgumentNullException();
        //    }
        //    else if (!cryptMessage.ToCharArray().All(x => (char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)) && (int)x < 127))
        //    {
        //        throw new ArgumentOutOfRangeException();
        //    }
        //    else
        //    {
        //        foreach (var varrer in cryptMessage.ToLower())
        //        {
        //            if (char.IsLetter(varrer))
        //            {
        //                var letra = varrer;
        //                var descriptografando = letra - 3;

        //                if (descriptografando <= inicio)
        //                {
        //                    descriptografando += 22;
        //                }

        //                message += (char)descriptografando;
        //            }
        //            else
        //            {
        //                message += varrer;
        //            }
        //        }
        //    }

        //    return message;
        //}


    }


}


//using System;
//using System.Text;
//using System.Linq;

//using System.Text.RegularExpressions;


//namespace Codenation.Challenge
//{
//    public class CesarCypher : ICrypt, IDecrypt
//    {
//        //variaveis
//        private const string iLetras = "abcdefghijklmnopqrstuvwxyz";
//        private const string iNumeros = " 0123456789";
//        private const int iCasas = 3;



//        public string Crypt(string message)
//        {
//            //tratamento em caso de mensagemm vazia
//            if (message == null)
//            {
//                throw new ArgumentNullException();
//            }


//            //o uso da classe StringBuilder pode melhorar o desempenho ao concatenar várias cadeias de caracteres em um loop.
//            StringBuilder iResultado = new StringBuilder();
//            char[] iTexto;
//            iTexto = message.ToLower().ToCharArray();



//            foreach (char i in iTexto)
//            {
//                //inStr => Retorna um inteiro que especifica a posição inicial da primeira ocorrência de uma cadeia de caracteres dentro de outra.
//                if (inStr(i, iLetras))
//                {
//                    iResultado.Append(Avanca(i));
//                }
//                else if (inStr(i, iNumeros))
//                {
//                    iResultado.Append(i);
//                }
//                else
//                {
//                    throw new ArgumentOutOfRangeException();
//                }
//            }
//            return iResultado.ToString();
//        }
//        public string Decrypt(string cryptedMessage)
//        {
//            if (cryptedMessage == null)
//            {
//                throw new ArgumentNullException();
//            }


//            StringBuilder iResultado = new StringBuilder();
//            char[] iTexto;
//            iTexto = cryptedMessage.ToLower().ToCharArray();



//            foreach (char i in iTexto)
//            {

//                if (inStr(i, iLetras))
//                {
//                    iResultado.Append(Volta(i));
//                }
//                else if (inStr(i, iNumeros))
//                {
//                    iResultado.Append(i);
//                }
//                else
//                {
//                    throw new ArgumentOutOfRangeException();
//                }

//            }

//            return iResultado.ToString();
//        }
//        private char Avanca(char i)
//        {
//            int vAscii = Convert.ToInt32(i) + iCasas;

//            if (vAscii > Convert.ToInt32(iLetras[iLetras.Length-1]))
//            {
//                vAscii = vAscii - iLetras.Length;
//            }

//            return Convert.ToChar(vAscii);

//        }
//        private char Volta(char i)
//        {
//            int vAscii = Convert.ToInt32(i) - iCasas;

//            if (vAscii < Convert.ToInt32(iLetras[0]))
//            {
//                vAscii = vAscii + iLetras.Length;
//            }

//            return Convert.ToChar(vAscii);
//        }

//        //inStr => Retorna um inteiro que especifica a posição inicial da primeira ocorrência de uma cadeia de caracteres dentro de outra.
//        private bool inStr(char pLetra, string pTexto)
//        {

//            for (int a = 0; a < pTexto.Length; a++)
//            {
//                if (pLetra == pTexto[a])
//                {
//                    return true;
//                }
//            }

//            return false;
//        }
//    }

//}

