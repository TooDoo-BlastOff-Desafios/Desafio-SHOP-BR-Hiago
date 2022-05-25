namespace ShopBr.Model
{
    public class Produto
    {
        //ANCHOR fazer sobrecarga de construtor para receber o id em consultas ao banco
        public Produto(string nome, string marca, string tipo, decimal preco, int quantidade)
        {
            Id = new Guid();
            Nome = nome;
            Marca = marca;
            Tipo = tipo;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto(Guid id, string nome, string marca, string tipo, decimal preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Marca = marca;
            Tipo = tipo;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca {get; set;}
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade{ get; set; }
    }
}