
using ShopBr.Model;
using ShopBr.Controller;
using ShopBr.View;
namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            Administrador adm = new Administrador();
            adm.Menu();
            CCorreio man = new CCorreio();
            Correio correio = new Correio(1,50);
            man.adcionar(correio);
            //Correio correio = man.getById(Guid.Parse("03c25211-86c1-4a00-82cb-d07154c0a5bb"));
            //Console.WriteLine(correio.Custo);

            ClienteView client = new ClienteView();
            //client.Menu();
            foreach(Correio cor in man.get()){
                Console.WriteLine(cor.Id);
            }
        }
    }
}