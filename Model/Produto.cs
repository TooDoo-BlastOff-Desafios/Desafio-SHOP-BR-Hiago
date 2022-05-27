namespace ShopBr.Model
{
    public class Produto
    {
        //ANCHOR fazer sobrecarga de construtor para receber o id em consultas ao banco
        public Produto()
        {
            Id = Guid.NewGuid();
            Nome = "";
            Marca = "";
            Tipo = "";

        }
        public Produto(string nome, string marca, string tipo, double preco, int quantidade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Marca = marca;
            Tipo = tipo;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto(Guid id, string nome, string marca, string tipo, double preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Marca = marca;
            Tipo = tipo;
            Preco = preco;
            Quantidade = quantidade;
        }
        public override string ToString()
        {
            return $"Nome: {Nome} Marca:{Marca} Tipo:{Tipo} Preço:{Preco} Quantidade disponivel: {Quantidade}";
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Marca {get; set;}
        public string Tipo { get; set; }
        public double Preco { get; set; }
        public int Quantidade{ get; set; }
    }
}