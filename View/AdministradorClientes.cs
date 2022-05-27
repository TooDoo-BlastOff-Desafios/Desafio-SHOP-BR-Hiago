using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdministradorClientes
    {
        public AdministradorClientes()
        {
            Gerenciador = new CCliente();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Clientes");
            List<Cliente> clientes = Gerenciador.Get();
            int contador = 0;
            foreach(Cliente cliente in clientes)
            {
                Console.WriteLine($"{contador} {cliente}");
                contador+=1;
            } 
            if(contador >0){
                Console.WriteLine("1- Para excluir um cliente ");
                Console.WriteLine("2- Para sair para o menu");
                var option = Solicitor.GetByteInterval(1,2);
                if(option == 1 || option == 2)
                {
                    Console.WriteLine("Insira o numero do cliente ");
                    int numCLiente = Solicitor.GetIntInterval(0, contador-1);
                    if(option == 1)
                    {
                        CCliente controlaCliente=  new CCliente();
                        controlaCliente.RemoveById(clientes[numCLiente].Cpf);
                    }
                }
                

            }
        }
        
        public CCliente Gerenciador { get; set; }
    }
}