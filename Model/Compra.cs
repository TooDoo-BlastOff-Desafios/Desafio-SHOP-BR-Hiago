namespace ShopBr.Model
{
    public class Compra
    {
        public Compra()
        {
            Cpf = "";
            TipoPagamento = "Cartao";
        }
        public Compra(string cpf, Guid idProduto, int quantidade, string tipoPagamento, Guid codigoRastreio, decimal valor)
        {
            Cpf = cpf;
            IdProduto = idProduto;
            Quantidade = quantidade;
            TipoPagamento = tipoPagamento;
            CodigoRastreio = codigoRastreio;
            Valor = valor;
        }
        
        public override string ToString()
        {
            return $"Cpf do cliente: {Cpf} Valor: {Valor} Quantidade: {Quantidade} ";
        }

        public string Cpf  { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string  TipoPagamento { get; set; }
        public Guid CodigoRastreio { get; set; }
        public decimal Valor  { get; set; }
    }
}