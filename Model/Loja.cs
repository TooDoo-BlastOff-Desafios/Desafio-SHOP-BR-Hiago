namespace ShopBr.Model
{
    public class Loja
    {
        public Loja(string nome, string endereco, string telefone, string email)
        {
            Id = new Guid();
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string  Telefone { get; set; }
        public string Email { get; set; }


    }
}