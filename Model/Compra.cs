namespace ShopBr.Model
{
    public class Compra
    {
        public Compra(string cpf, Guid idProduto, int quantidade, string tipoPagamento, Guid codigoRastreio, double valor)
        {
            Cpf = cpf;
            IdProduto = idProduto;
            Quantidade = quantidade;
            TipoPagamento = tipoPagamento;
            CodigoRastreio = codigoRastreio;
            Valor = valor;
        }

        public string Cpf  { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string  TipoPagamento { get; set; }
        public Guid CodigoRastreio { get; set; }
        public double Valor  { get; set; }
    }
}