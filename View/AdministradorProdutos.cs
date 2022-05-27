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
                    EditarProduto();
                    break;
                case 3:
                    ExcluirProduto();
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
            produto.Preco = (decimal) Solicitor.GetValidpositiveDouble();
            Console.WriteLine("Insira a quantidade de produtos");
            produto.Quantidade = Solicitor.GetValidpositiveInt();
            Gerenciador.adcionar(produto);
        }
        public void ExcluirProduto()
        {
            var produtos = Gerenciador.Get();
            int contador =0;
            foreach(Produto produto in produtos)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador >0)
            {
                Console.WriteLine("Insira o numero do produto que deseja excluir");
                var numero = Solicitor.GetIntInterval(0, contador-1);
                Gerenciador.Remove(produtos[numero].Id);
            }else{
                Console.WriteLine("Não ha nenhum produto aqui");
            }
        }
        private void EditarProduto()
        {
            var produtos = Gerenciador.Get();
            int contador =0;
            foreach(Produto produto in produtos)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador >0)
            {
                Console.WriteLine("Insira o numero do produto que deseja editar");
                var numero = Solicitor.GetIntInterval(0, contador-1);
                Produto produto = produtos[numero];
                Console.WriteLine("Insira o nome do seu produto");
                produto.Nome  = Solicitor.GetValidString();
                Console.WriteLine("Insira a marca do seu produto");
                produto.Marca = Solicitor.GetValidString();
                Console.WriteLine("Insira o tipo do seu produto");
                produto.Tipo = Solicitor.GetValidString();
                Console.WriteLine("Insira o preço do seu produto");
                produto.Preco = (decimal) Solicitor.GetValidpositiveDouble();
                Console.WriteLine("Insira a quantidade de produtos");
                produto.Quantidade = Solicitor.GetValidpositiveInt();
                Gerenciador.Update(produto);

            }else{
                Console.WriteLine("Não ha nenhum produto aqui");
            }

        }
    }
}