using System;
using System.Data.SqlClient;
using System.Text;
using System.Runtime.InteropServices;
using ShopBr.Model;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipulaCorreio man = new ManipulaCorreio();

            Correio correio = man.getById(Guid.Parse("03c25211-86c1-4a00-82cb-d07154c0a5bb"));
            Console.WriteLine(correio.Custo);
            foreach(Correio cor in man.get()){
                Console.WriteLine(cor.Id);
            }
        }
    }
}