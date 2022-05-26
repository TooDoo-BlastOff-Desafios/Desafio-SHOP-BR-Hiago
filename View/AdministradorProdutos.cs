using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdministradorProdutos
    {
        public AdministradorProdutos()
        {
            Gerenciador = new CProduto();
        }
        private CProduto Gerenciador { get; set; }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1-Para cadastrar um produto");
            Console.WriteLine("2-Para editar um produto ");
            Console.WriteLine("3-Para excuir um produto");
            Console.WriteLine("4- Para sair para o menu");
            var option = Solicitor.GetByteInterval(1,4);
            switch(option)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            if(option !=4)
                Menu();

        }
        public void CadastrarProduto()
        {
            Produto produto = new Produto();
            Console.WriteLine("Insira o nome do seu produto");
            produto.Nome  = Solicitor.GetValidString();
            Console.WriteLine("Insira a marca do seu produto");
            produto.Marca = Solicitor.GetValidString();
            Console.WriteLine("Insira o tipo do seu produto");
            produto.Tipo = Solicitor.GetValidString();
            Console.WriteLine("Insira o preço do seu produto");
            produto.Preco = (decimal)Solicitor.GetValidpositiveDouble();
            Console.WriteLine("Insira a quantidade de produtos");
            produto.Quantidade = Solicitor.GetValidpositiveInt();
            Gerenciador.adcionar(produto);
        }
    }
}