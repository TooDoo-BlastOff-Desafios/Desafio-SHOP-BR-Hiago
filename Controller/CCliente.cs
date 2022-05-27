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
            Cmd.Parameters.Clear();
            Cmd.CommandText = "insert into Cliente ( CPF, Nome, Telefone, CEP, Email, Senha, Nivel) values (@CPF, @Nome, @Telefone, @CEP, @Email, @Senha, @Nivel)";
            Cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
            Cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
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
            Cmd.Parameters.Clear();
            Cmd.CommandText = "Select CPF FROM Cliente WHERE CPF = @CPF AND Senha = @Senha";
            Cmd.Parameters.AddWithValue("@CPF", cpf);
            Cmd.Parameters.AddWithValue("@Senha", senha);
            Cmd.Connection = conectar();
            using (SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read())
                    return true;
            }
            return false;
        }
        public List<Cliente> Get()
        {
            Cmd.Parameters.Clear();
            var clientes= new List<Cliente>();
            Cmd.CommandText = "SELECT CPF, Nome, Telefone, CEP, Email, Senha, Nivel FROM Cliente ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                    clientes.Add(new Cliente((string)reader["CPF"],(string)reader["Nome"],(string)reader["CEP"], (string)reader["Email"], (string)reader["Senha"], (string) reader["Nivel"]));
                }
            }
            desconectar();
            return clientes;
        }
            
        public void RemoveById(string cpf)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM Avaliacao WHERE ClienteId = @Id";
            Cmd.Parameters.AddWithValue("@id",cpf);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM Compra WHERE ClienteId = @Id";
            Cmd.Parameters.AddWithValue("@id",cpf);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
            Cmd.Parameters.Clear();           
            Cmd.CommandText = "DELETE FROM Cliente WHERE CPF = @Id";
            Cmd.Parameters.AddWithValue("@id",cpf);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();

        }

    }
}