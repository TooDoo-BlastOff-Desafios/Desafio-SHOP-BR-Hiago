namespace ShopBr.Model
{
    public class Loja
    {

 
        public Loja()
        {
            Id = Guid.NewGuid();
            Nome = "";
            Endereco = "";
            Telefone = "";
            Email = "";
        }
        public Loja(string nome, string endereco, string telefone, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
        public Loja(Guid id,string nome, string endereco, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
        //ANCHOR criar construtor sem email
        public override string ToString()
        {
            return $"Nome: {Nome} Endereco:{Endereco} Telefone:{Telefone} Email:{Email} ";
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string  Telefone { get; set; }
        public string Email { get; set; }


    }
}