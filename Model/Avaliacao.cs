namespace ShopBr.Model
{
    public class Avaliacao
    {
        public Avaliacao(Guid clienteId, Guid produtoId, byte nota)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nota = nota;
        }

        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public byte Nota  { get; set; }
    }
}