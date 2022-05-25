namespace ShopBr.Model
{
    public class Avaliacao
    {
        public Avaliacao(Guid clienteId, Guid produtoId, byte nota, string comentario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Comentario = comentario;
            Nota = nota;
        }

        public Guid ClienteId { get; set; }
        public string  Comentario { get; set; }
        public Guid ProdutoId { get; set; }
        public byte Nota  { get; set; }
    }
}