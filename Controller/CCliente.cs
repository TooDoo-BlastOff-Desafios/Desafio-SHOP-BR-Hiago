using System.Data.SqlClient;
using ShopBrServices;
using ShopBr.Model;
namespace ShopBr.Controller
{
    public class CCliente: Conexao
    {
        public CCliente()
        {
            
        }
        public void Adicionar(Cliente cliente){
            Cmd.CommandText = "insert into Cliente ( CPF, Nome, Endereco, Telefone, CEP, Email, Senha, Nivel) values (@CPF, @Nome, @Endereco, @Telefone, @CEP, @Email, @Senha, @Nivel)";
            Cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            Cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            Cmd.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            Cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            Cmd.Parameters.AddWithValue("@CEP", cliente.Cep);
            Cmd.Parameters.AddWithValue("@Email", cliente.Email);
            Cmd.Parameters.AddWithValue("@Senha", cliente.Senha);
            Cmd.Parameters.AddWithValue("@Nivel", cliente.Nivel);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public bool Validar(string cpf, string senha)
        {
            return true;
            //ANCHOR fazer função de validacao
        }
    }
}