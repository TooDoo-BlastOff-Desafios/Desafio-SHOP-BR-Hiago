namespace ShopBr.Model
{
    public class Cliente
    {
        public Cliente()
        {
            Cpf = "";
            Nome = "";
            Endereco = "";
            Telefone = "";
            Cep = "";
            Email = "";
            Senha= "";
            Nivel = "Nivel 1";

        }
        public Cliente(string cpf, string nome, string endereco,  string cep, string email, string senha,string nivel, string telefone= "")
        {
            Cpf = cpf;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cep = cep;
            Email = email;
            Senha = senha;
            Nivel = nivel; 
        }

        public string Cpf { get; set; }
        public string  Nome { get; set; }
        public string  Endereco { get; set; }
        public string  Telefone { get; set; }
        public string Cep  { get; set; }
        public string  Email { get; set; }
        public string Senha {get; set;}
        public string Nivel { get; set; }

    }
}