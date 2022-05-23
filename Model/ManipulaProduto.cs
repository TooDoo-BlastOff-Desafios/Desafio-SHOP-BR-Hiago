using System.Data.SqlClient;
using ShopBrServices;

namespace ShopBr.Model
{
    public class ManipulaProduto
    {
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        public string mensagem = "";
        public ManipulaProduto(Produto prod){
            cmd.CommandText = "insert into Correio ( Prazo, CustoFrete) values (@Prazo, @CustoFrete)";
            cmd.Parameters.AddWithValue("@Prazo",prod.Prazo);
            cmd.Parameters.AddWithValue("@CustoFrete",prod.Custo);


            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Cadastrado com sucesso!!";
            }catch(SqlException e)
            {
                this.mensagem = "Erro ao se conectar ao banco";
            }
            Console.WriteLine(this.mensagem);
        }
    }
}