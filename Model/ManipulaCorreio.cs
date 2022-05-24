using System.Data.SqlClient;
using ShopBrServices;

namespace ShopBr.Model
{
    //ANCHOR tornar a classe estatica
    public  class ManipulaCorreio : Conexao
    {
        public SqlCommand Cmd { get; set; }
        public ManipulaCorreio()
        {
            Cmd = new SqlCommand();
        }
        public void adcionar(Correio correio){
            Cmd.CommandText = "insert into Correio ( Prazo, CustoFrete) values (@Prazo, @CustoFrete)";
            Cmd.Parameters.AddWithValue("@Prazo",correio.Prazo);
            Cmd.Parameters.AddWithValue("@CustoFrete",correio.Custo);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public void remove(Guid id)
        {
            Cmd.CommandText = "DELETE FROM Correio WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }

        public Correio getById(Guid id)
        {
            Cmd.CommandText = "SELECT Id, Prazo, CustoFrete FROM Correio WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);  
            Cmd.Connection = conectar();

            Correio correio;
            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read()){
                    if((Guid)reader["Id"]== id){
                        correio = new Correio((Guid)reader["Id"],(byte)reader["Prazo"],(double)reader["CustoFrete"]);
                        desconectar();
                        return correio;
                    }
                }
            }
            desconectar();
            throw new Exception("Não foi possivel encontrar este correio");
        }

        public List<Correio> get()
        {
            var correios= new List<Correio>();
            Cmd.CommandText = "SELECT Id, Prazo, CustoFrete FROM Correio ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        correios.Add(new Correio((Guid)reader["Id"],(byte)reader["Prazo"],(double)reader["CustoFrete"]));
                }
                }
            desconectar();
            return correios;
        }
    }
}