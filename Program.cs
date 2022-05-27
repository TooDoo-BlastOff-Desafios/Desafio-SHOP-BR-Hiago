
using ShopBr.Model;
using ShopBr.Controller;
using ShopBr.View;
namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            CCorreio man = new CCorreio();
            Correio correio = new Correio(1,50);
            man.Adcionar(correio);
            //Correio correio = man.getById(Guid.Parse("03c25211-86c1-4a00-82cb-d07154c0a5bb"));
            //Console.WriteLine(correio.Custo);

            ClienteView client = new ClienteView();
            client.Menu();
            Administrador adm = new Administrador();
            adm.Menu();
            foreach(Correio cor in man.Get()){
                Console.WriteLine(cor.Id);
            }
        }
    }
}