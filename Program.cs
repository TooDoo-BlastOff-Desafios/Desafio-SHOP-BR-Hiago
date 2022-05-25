
using ShopBr.Model;
using ShopBr.Controller;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            CCorreio man = new CCorreio();
            Correio correio = new Correio(1,50);
            man.adcionar(correio);
            //Correio correio = man.getById(Guid.Parse("03c25211-86c1-4a00-82cb-d07154c0a5bb"));
            //Console.WriteLine(correio.Custo);
            foreach(Correio cor in man.get()){
                Console.WriteLine(cor.Id);
            }
        }
    }
}