namespace ShopBr.Model
{
    public class Cliente
    {
        public Cliente(string cpf, string nome, string endereco,  string cep, string email, string senha,byte nivel =1, string telefone= "")
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
        public string Senha {get;}
        public byte Nivel { get; set; }

    }
}