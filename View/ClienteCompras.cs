using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class ClienteCompras
    {
        public ClienteCompras(string cpf)
        {
            Cpf =cpf;
            GerenciaProdutos = new CProduto();
            Gerenciador = new CCompra();
            Carrinho = new List<Produto>();
        }
        private CProduto GerenciaProdutos { get; set; }
        private List<Produto> Carrinho { get; set; }
        private CCompra Gerenciador { get; set; }
        private string Cpf { get; set; }
        public void MenuCompra()
        {
            Console.Clear();
            Console.WriteLine("Menu de compras");
            List<Produto> produtos = GerenciaProdutos.get();
            int contador = 0;
            foreach(Produto produto in  produtos)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador!=0){
                Console.WriteLine("1- Para adicionar um produto ao Carrinho");
                Console.WriteLine("2- Para comprar um produto");
                Console.WriteLine("3- Para ver o carrinho de compras");
                Console.WriteLine("4- Para sair");
                var option = Solicitor.GetByteInterval(1,4);
                switch(option)
                {
                    case 1:
                        Console.WriteLine("Insira o numero do produto que deseja adicionar");
                        int numProduto = Solicitor.GetIntInterval(0, contador-1);
                        Carrinho.Add(produtos[numProduto]);
                        break;
                    case 2:
                        Console.WriteLine("Insira o numero do produto que deseja comprar");
                        int numProdutoCompra = Solicitor.GetIntInterval(0, contador-1);
                        RealizarCompra(produtos[numProdutoCompra]);
                        break;
                    case 3:
                        MenuCarrinho();
                        break;
                }
                if(option != 4)
                    MenuCompra();
            }else{
                Console.Clear();
                Console.WriteLine("Não é possivel fazer uma compra  nenhum produto foi cadastrado");
                Solicitor.Parada();
                MenuCompra();
            }

        }
        public void MenuCarrinho()
        {
            Console.Clear();
            Console.WriteLine("Carrinho de Compras");
            int contador =0;
            foreach(Produto produto in Carrinho)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador != 0){
                Console.WriteLine("1- Para comprar um item");
                Console.WriteLine("2- Para voltar ao menu");
                byte option = Solicitor.GetByteInterval(1,2);
                if(option ==1){
                    Console.WriteLine("Insira qual produto deseja compra");
                    int comprar = Solicitor.GetIntInterval(0, contador-1);
                    RealizarCompra(Carrinho[comprar]);
                }
            }else{
                Console.WriteLine("Você ainda não tem itens no carrinho");
                Solicitor.Parada();
            }
        }
        private void RealizarCompra(Produto produto)
        {
            Compra compra = new Compra();
            compra.Cpf = Cpf;
            compra.IdProduto = produto.Id;
            compra.CodigoRastreio = GetCorreio();
            compra.Quantidade = GetQuantidade(produto.Quantidade); 
            compra.Valor= compra.Quantidade * produto.Preco;
            CCompra controlaCompra = new CCompra();
            Console.WriteLine(controlaCompra.Adicionar(compra));
            Solicitor.Parada();
        }
        private int GetQuantidade(int max)
        {
            Console.WriteLine("Insira quantos prodcutos deseja comprar");
            Console.WriteLine("Voce pode comprar no maximo "+ max);
            return Solicitor.GetIntInterval(0,max);
        }
        private Guid GetCorreio(){
            var controlacorreios = new CCorreio();
            var correios = controlacorreios.Get();
            int contador = 0;
            foreach(Correio correio in correios)
            {
                Console.WriteLine($"{contador} {correio}");
                contador+=1;
            }
            if(contador != 0)
            {
                Console.WriteLine("Favor insira o numero do correio desejado");
                var numCorreio = Solicitor.GetIntInterval(0, contador-1);
                return correios[numCorreio].Id;
            }
            else
            {
                throw new Exception("Nenhum correio cadastrado impossivel fazer uma compra");
            }
        }
    }
}