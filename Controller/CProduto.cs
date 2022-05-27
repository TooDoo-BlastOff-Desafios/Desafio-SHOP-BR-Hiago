using System.Data.SqlClient;
using ShopBrServices;
using ShopBr.Model;

namespace ShopBr.Controller
{
    //ANCHOR tornar a classe estatica
    public  class CProduto : Conexao
    {
        public CProduto()
        {
            
        }
        public void adcionar(Produto produto){
            Cmd.Parameters.Clear();
            Cmd.CommandText = "insert into Produto ( Id, Nome, Marca, Tipo, Preco, Quantidade) values (@IdProd, @Nome, @Marca, @Tipo, @Preco, @Quantidade)";
            Cmd.Parameters.AddWithValue("@IdProd",produto.Id);
            Cmd.Parameters.AddWithValue("@Nome",produto.Nome);
            Cmd.Parameters.AddWithValue("@Marca",produto.Marca);
            Cmd.Parameters.AddWithValue("@Tipo",produto.Tipo);
            Cmd.Parameters.AddWithValue("@Preco",produto.Preco);
            Cmd.Parameters.AddWithValue("@Quantidade",produto.Quantidade);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }
        public void remove(Guid id)
        {
            //ANCHOR IMPLEMTENTAR FUNÇÃO PARA ISSO NO BANCO
           
        }
        public Produto getById(Guid id)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT Id, Nome, Marca, Tipo, Preco, Quantidade FROM Produto WHERE Id = @Id";
            Cmd.Parameters.AddWithValue("@id",id);  
            Cmd.Connection = conectar();

            Produto produto;
            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                if(reader.Read()){
                    if((Guid)reader["Id"]== id){
                        produto = new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(double)reader["Preco"],(int)reader["Quantidade"]);
                        desconectar();
                        return produto;
                    }
                }
            }
            desconectar();
            throw new Exception("Não foi possivel encontrar este correio");
        }
        //ANCHOR adicionar funcoes para fazer buscas por tipo
        //ANCHOR adicionar funcão no banco para buscar por tipos
        public List<Produto> get()
            {
                var produtos= new List<Produto>();
                Cmd.CommandText = "SELECT Id, Nome, Marca, Tipo, Preco, Quantidade FROM Produto ";
                Cmd.Connection = conectar();

                using(SqlDataReader reader = Cmd.ExecuteReader())
                {
                    while(reader.Read()){
                            produtos.Add(new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(double)reader["Preco"],(int)reader["Quantidade"]));
                    }
                }
                desconectar();
                return produtos;
            }
    }
}