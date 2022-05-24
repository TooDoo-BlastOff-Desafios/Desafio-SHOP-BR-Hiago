using System.Data.SqlClient;
using ShopBrServices;

namespace ShopBr.Model
{
    //ANCHOR tornar a classe estatica
    public class ManipulaCorreio
    {
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        public string mensagem = "";
        public ManipulaCorreio(Correio correio){
            cmd.CommandText = "insert into Correio ( Prazo, CustoFrete) values (@Prazo, @CustoFrete)";
            cmd.Parameters.AddWithValue("@Prazo",correio.Prazo);
            cmd.Parameters.AddWithValue("@CustoFrete",correio.Custo);


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