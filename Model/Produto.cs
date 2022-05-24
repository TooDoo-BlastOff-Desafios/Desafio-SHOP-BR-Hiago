namespace ShopBr.Model
{
    public class Produto
    {
        //ANCHOR fazer sobrecarga de construtor para receber o id em consultas ao banco
        public Produto(string nome, string marca, string tipo, float preco)
        {
            Id = new Guid();
            Nome = nome;
            Marca = marca;
            Tipo = tipo;
            Preco = preco;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca {get; set;}
        public string Tipo { get; set; }
        public float Preco { get; set; }
    }
}