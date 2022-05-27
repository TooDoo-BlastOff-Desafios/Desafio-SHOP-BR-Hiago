using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdmCompras
    {
        public AdmCompras()
        {
            Gerenciador = new CCompra();
        }
        public CCompra Gerenciador { get; set; }
        public void Menu()
        {
            Console.Clear();
            int contador = 0;
            List<Compra> compras = Gerenciador.Get();
            foreach(Compra compra in compras)
            {
                Console.WriteLine($"{contador} {compra}");
                contador+=1;
            }
            if(contador>0)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("1- Para excluir uma avaliacao");
                Console.WriteLine("2- Para sair");
                byte option = Solicitor.GetByteInterval(1,2);
                if(option == 1){
                    Console.WriteLine("Insira o numero da compra que deseja remover");
                    int remover = Solicitor.GetIntInterval(0, contador-1);
                    Gerenciador.RemoveByIds(compras[remover].Cpf, compras[remover].IdProduto);
                }   
            }
            else
            {
                Console.WriteLine("Nenhuma Compra foi realizada");
                Solicitor.Parada();
            }
        }
    }
}