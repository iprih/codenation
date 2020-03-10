public class ContaCorrente
{

    public string titular;
    public int agencia;
    public int numero;
    public double saldo = 100;


    //funcao <- retorna valor
    public bool Sacar(double valor)
    {
        if (this.saldo >= valor)
        {
            saldo -= valor;
            return true;
        }
        else
        {
            return false;
        }

    }
    //metodo <- nao retorna valor
    public void Depositar(double valor)
    {
        this.saldo += valor;
    }

    public bool Transferir(double valor, ContaCorrente contaDestino)
    {
        if(this.saldo < valor)
        {
            return false;
        }
        else
        {
            this.saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
        
    }
}