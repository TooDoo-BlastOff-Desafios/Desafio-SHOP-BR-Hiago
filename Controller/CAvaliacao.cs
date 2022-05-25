using System.Data.SqlClient;
using ShopBrServices;
using ShopBr.Model;
namespace ShopBr.Controller
{
    public class CAvaliacao: Conexao
    {
        public CAvaliacao()
        {
            
        }
        public void adicionar(Avaliacao avaliacao)
        {
            Cmd.CommandText = "insert into Avaliacao ( ClienteId, ProdutoId, Avaliacao, Comentario) values (@ClienteId, @ProdutoID, @Avaliacao, @Comentario)";
            Cmd.Parameters.AddWithValue("@ClienteId", avaliacao.ClienteId);
            Cmd.Parameters.AddWithValue("@ProdutoId",avaliacao.ProdutoId);
            Cmd.Parameters.AddWithValue("@Avaliacao",avaliacao.Nota);
            Cmd.Parameters.AddWithValue("@Comentario",avaliacao.Comentario);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }
        public void remove(Guid id)
        {
            Cmd.CommandText = "DELETE FROM Avaliacao WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }
        
        public Avaliacao getById(Guid id)
        {
            Cmd.CommandText = "SELECT ClienteId, ProdutoId, Avaliacao, Comentario FROM Avaliacao WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);  
            Cmd.Connection = conectar();

            Avaliacao avaliacao;
            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read()){
                    if((Guid)reader["Id"]== id){
                        avaliacao = new Avaliacao((Guid)reader["ClienteId"],(Guid)reader["ProdutoId"], (byte)reader["Avaliacao"],(String)reader["Comentario"]);
                        desconectar();
                        return avaliacao;
                    }
                }
            }
            desconectar();
            throw new Exception("Não foi possivel encontrar este correio");
        }
        public List<Avaliacao> get()
        {
            var avaliacoes= new List<Avaliacao>();
            Cmd.CommandText = "SELECT ClienteId, ProdutoId, Avaliacao, Comentario FROM Avaliacao ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        avaliacoes.Add(new Avaliacao((Guid)reader["ClienteId"],(Guid)reader["ProdutoId"],(byte)reader["Avaliacao"],(String)reader["Comentario"]));
                }
            }
            desconectar();
            return avaliacoes ;
        }
    }

}