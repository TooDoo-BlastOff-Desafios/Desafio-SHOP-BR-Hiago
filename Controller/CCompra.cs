using System.Data.SqlClient;
using ShopBrServices;
using ShopBr.Model;
namespace ShopBr.Controller
{
    public class CCompra : Conexao
    {
        public CCompra()
        {
        }
        public string Adicionar(Compra compra)
        {
            Cmd.CommandText = "EXEC dbo.spAddCompra @Cpf, @ProdutoId, @Quantidade, @Valor, @TipoPagamento, @CodigoCorreio ";
            Cmd.Parameters.AddWithValue("@Cpf",  compra.Cpf);
            Cmd.Parameters.AddWithValue("@ProdutoId",compra.IdProduto);
            Cmd.Parameters.AddWithValue("@Quantidade",compra.Quantidade);
            Cmd.Parameters.AddWithValue("@Valor",(float)compra.Valor);
            Cmd.Parameters.AddWithValue("@TipoPagamento",compra.TipoPagamento);
            Cmd.Parameters.AddWithValue("@CodigoCorreio", compra.CodigoRastreio);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read()){
                    return (string)reader["retorno"];
                }
            }
            return "Erro ao adicionar compra";
        }
        public void RemoveByIds(string clienteid, Guid produtoid)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM Compra WHERE ClientId = @Id AND ProdutoId = @Produto";
            Cmd.Parameters.AddWithValue("@id",clienteid);
            Cmd.Parameters.AddWithValue("@Produto",produtoid);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public List<Compra> Get()
        {
            Cmd.Parameters.Clear();
            var compras= new List<Compra>();
            Cmd.CommandText = "SELECT ClienteId, ProdutoId, CorreioId, Valor, Quantidade, TipoPagamento FROM Compra ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        compras.Add(new Compra((string)reader["ClienteId"], (Guid)reader["ProdutoId"], (int)reader["Quantidade"], (string)reader["TipoPagamento"], (Guid)reader["CorreioId"], (decimal)reader["valor"]));
                }
            }
            desconectar();
            return compras ;
        }

        public void RemoveById(string id)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM Compra WHERE ClienteId = @Id";
            Cmd.Parameters.AddWithValue("@id",id);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        } 

    }
}