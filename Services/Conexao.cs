using System.Data.SqlClient;

namespace ShopBrServices{
    public class Conexao
    {
        SqlConnection con  = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString= "Server=localhost,1433;Database=SHOPBR;User ID=sa;Password=1q2w3e4r@#$";

        }

        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }
    }

}