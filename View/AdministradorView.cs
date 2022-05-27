using UserSolicitor;

namespace ShopBr.View
{
    public class Administrador
    {
        public Administrador(){

        }
        public void Menu(){
            Console.Clear();
            Console.WriteLine("Favor Insira a sua senha");
            string senha = Solicitor.GetValidSenha();
            if(senha == "Ra#23140304")
            {
                MenuAdministrador();
            }else{
                Console.WriteLine("Senha invalida");
                Console.WriteLine("Pressione qualquer tecla para proseguir");
                Console.ReadKey();
            }
        }
        private void MenuAdministrador()
        {
            Console.Clear();
            Console.WriteLine("1- Para gerenciar os Correios");
            Console.WriteLine("2- Para gerenciar os Clientes");
            Console.WriteLine("3- Para gerenciar as Compras");
            Console.WriteLine("4- Para gerenciar as Lojas ");
            Console.WriteLine("5- Para gerenciar as Avaliações");
            Console.WriteLine("6- Para gerenciar os Produtos");
            Console.WriteLine("7- Para voltar ao Menu");
            byte option = Solicitor.GetByteInterval(1,7);
            switch(option)
            {
                case 1:
                    var admCorreio = new AdmCorreio();
                    admCorreio.Menu();
                    break;
                case 2:
                    var admCliente = new AdministradorClientes();
                    admCliente.Menu(); 
                    break;
                case 3:
                    var AdmCompras = new AdmCompras();
                    AdmCompras.Menu();
                    break;
                case 4:
                    var admLoja = new AdmLoja();
                    admLoja.Menu();
                    break;
                case 5:
                    var administraAvaliacao = new AdministraAvaliacao();
                    administraAvaliacao.Menu();
                    break;
                case 6:
                    var admProdutos = new AdministradorProdutos();
                    admProdutos.Menu();
                    break;
            }
            if(option != 7)
                MenuAdministrador();
            
        }
    }
}