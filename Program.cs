
using ShopBr.Model;
using ShopBr.Controller;
using ShopBr.View;
using UserSolicitor;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Menu();
            
        }
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("ShopBr");
            Console.WriteLine("1- Logar ou se cadastrar como cliente");
            Console.WriteLine("2- Logar como administrador");
            Console.WriteLine("3- Sair ");
            var option = Solicitor.GetByteInterval(1,3);
            switch(option)
            {
                case 1:
                    ClienteView client = new ClienteView();
                    client.Menu();
                    break;
                case 2:
                    Administrador adm = new Administrador();
                    adm.Menu();
                    break;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
            Menu();
        }
    }
}