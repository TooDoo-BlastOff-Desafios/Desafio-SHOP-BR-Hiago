using System;
using System.Data.SqlClient;
using System.Text;
using ShopBr.Model;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
           Produto prod = new Produto(1, 22);
           ManipulaProduto man = new ManipulaProduto(prod);
        }
    }
}