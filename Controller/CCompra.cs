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
            Cmd.CommandText = "EXEC spAddCompra @Cpf, @ProdutoId, @Quantidade, @Valor, @TipoPagamento, @CodigoCorreio ";
            Cmd.Parameters.AddWithValue("@Cpf",  compra.Cpf);
            Cmd.Parameters.AddWithValue("@ProdutoId",compra.IdProduto);
            Cmd.Parameters.AddWithValue("@Quantidade",compra.Quantidade);
            Cmd.Parameters.AddWithValue("@Valor",compra.Valor);
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
    }
}