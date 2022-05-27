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
                        produto = new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(decimal)reader["Preco"],(int)reader["Quantidade"]);
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
        public List<Produto> Get()
        {
            Cmd.Parameters.Clear();
            var produtos= new List<Produto>();
            Cmd.CommandText = "SELECT Id, Nome, Marca, Tipo, Preco, Quantidade FROM Produto ";
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        produtos.Add(new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(decimal)reader["Preco"],(int)reader["Quantidade"]));
                }
            }
            desconectar();
            return produtos;
        }
        public List<Produto> GetSemLoja(Guid lojaId)
        {
            Cmd.Parameters.Clear();
            var produtos= new List<Produto>();
            Cmd.CommandText = "SELECT [Produto].Id, [Produto].Nome, [Produto].Marca, [Produto].Tipo, [Produto].Preco, [Produto].Quantidade FROM Produto  LEFT JOIN [ProdutoEmLoja] ON Produto.Id != [ProdutoEmLoja].ProdutoId WHERE [ProdutoEmLoja].LojaId = @LojaI5d OR [ProdutoEmLoja].LojaId is Null";
            Cmd.Parameters.AddWithValue("@LojaId",lojaId);  
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        produtos.Add(new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(decimal)reader["Preco"],(int)reader["Quantidade"]));
                }
            }
            desconectar();
            return produtos;

        }
        public List<Produto> GetNaLoja(Guid lojaId)
        {
            Cmd.Parameters.Clear();
            var produtos= new List<Produto>();
            Cmd.CommandText = "SELECT [Produto].Id, [Produto].Nome, [Produto].Marca, [Produto].Tipo, [Produto].Preco, [Produto].Quantidade FROM Produto LEFT JOIN [ProdutoEmLoja] ON Produto.Id = [ProdutoEmLoja].ProdutoId WHERE [ProdutoEmLoja].LojaId = @LojaId   ";
            Cmd.Parameters.AddWithValue("@LojaId",lojaId);  
            Cmd.Connection = conectar();

            using(SqlDataReader reader = Cmd.ExecuteReader())
            {
                while(reader.Read()){
                        produtos.Add(new Produto((Guid)reader["Id"],(string)reader["Nome"],(string)reader["Marca"],(string)reader["Tipo"],(decimal)reader["Preco"],(int)reader["Quantidade"]));
                }
            }
            desconectar();
            return produtos;

        }
        public void RemoveDaLoja( Guid lojaId, Guid produtoId)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM ProdutoEmLoja WHERE ProdutoId = @Id AND LojaId = @Loja";
            Cmd.Parameters.AddWithValue("@id",produtoId);
            Cmd.Parameters.AddWithValue("@loja",lojaId);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }
        public void adcionarNaLoja(Guid lojaId, Guid produtoId){
            Cmd.Parameters.Clear();
            Cmd.CommandText = "insert into ProdutoEmLoja ( LojaId, ProdutoId) values (@IdLoja, @IdProd)";
            Cmd.Parameters.AddWithValue("@IdLoja",lojaId);
            Cmd.Parameters.AddWithValue("@IdProd", produtoId);
            Cmd.Connection = conectar();
            Cmd.ExecuteNonQuery();
            desconectar();
        }
    }
}