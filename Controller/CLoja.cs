using System.Data.SqlClient;
using ShopBrServices;
using ShopBr.Model;

namespace ShopBr.Controller
{
    public class CLoja : Conexao
    {
        public CLoja()
        {
            
        }
        public void Adcionar(Loja loja){
            Cmd.Parameters.Clear();
            Cmd.CommandText = "insert into Loja ( Id, Nome, Endereco, Telefone, Email) values (@Id, @Nome, @Endereco, @Telefone, @Email)";
            Cmd.Parameters.AddWithValue("@id",loja.Id);
            Cmd.Parameters.AddWithValue("@Nome",loja.Nome);
            Cmd.Parameters.AddWithValue("@Endereco",loja.Endereco);
            Cmd.Parameters.AddWithValue("@Telefone",loja.Telefone);
            Cmd.Parameters.AddWithValue("@Email",loja.Email);

            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public void Remove(Guid id)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM ProdutoEmLoja WHERE LojaId = @Id";
            Cmd.Parameters.AddWithValue("@id",id);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM Loja WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public Loja getById(Guid id)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT Id, Nome, Endereco, Telefone, Email FROM loja WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);  
            Cmd.Connection = conectar();

            Loja loja;
            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read()){
                    if((Guid)reader["Id"]== id){
                        loja = new Loja((Guid)reader["Id"],(string)reader["Nome"], (string)reader["Endereco"], (string)reader["Telefone"], (string)reader["Email"]);
                        desconectar();
                        return loja;
                    }
                }
            }
            desconectar();
            throw new Exception("Não foi possivel encontrar este loja");
        }
        public List<Loja> Get()
        {
            var loja= new List<Loja>();
            Cmd.CommandText = "SELECT Id, Nome, Endereco, Telefone, Email FROM loja ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        loja.Add(new Loja((Guid)reader["Id"],(string)reader["Nome"], (string)reader["Endereco"], (string)reader["Telefone"], (string)reader["Email"]));
                }
            }
            desconectar();
            return loja;
        }




    }
}