using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;


namespace ShopBr.View
{
    public class ClienteComprasRealizadas
    {
        public ClienteComprasRealizadas(string cpf)
        {
            this.Cpf = cpf;
            Gerenciador = new CAvaliacao();

        }
        private string Cpf { get; set; }
        public CAvaliacao Gerenciador { get; set; }

        public void Menu()
        {
            Console.WriteLine("Avaliacao de produtos");
            var produtos = Gerenciador.ProdutosComprados(Cpf);
            int contador =0;
            foreach(Produto produto in  produtos)
            {
                Console.WriteLine($"{contador} {produto}");
                contador+=1;
            }
            if(contador >0){
                Console.WriteLine("1- Para fazer uma avaliacao");
                Console.WriteLine("2- Ver avaliacoes");
                Console.WriteLine("3- Para voltar ao menu ");
                byte option = Solicitor.GetByteInterval(1,2);
                if(option ==1){
                    Console.WriteLine("Insira o numero do produto a avaliar");
                    int numero = Solicitor.GetIntInterval(0, contador-1);
                    FazerAvaliacao(produtos[numero].Id);
                }
                if(option !=3)
                    Menu();
            }else{
                Console.WriteLine("Nenhum produto para avaliar nenhum produto");
            }
            Solicitor.Parada();

        }
        private void FazerAvaliacao(Guid idproduto)
        {
            Console.WriteLine("Insira um comentario para sua avaliacao");
            string comentario = Solicitor.GetValidString();
            Console.WriteLine("Insira uma nota de 1 a 5");
            byte nota = Solicitor.GetByteInterval(1,5);
            Avaliacao av = new Avaliacao(Cpf,idproduto, nota,comentario);
            Gerenciador.Adicionar(av);
        }

        private void ViewAvaliacoes()
        {
            Console.Clear();
            Console.WriteLine("Avaliacoes de clientes");
            int contador = 0;
            List<Avaliacao> avaliacoes = Gerenciador.Get();
            foreach(Avaliacao avaliacao in avaliacoes)
            {
                Console.Write($"{contador} {avaliacao.ProdutoId} {avaliacao.Comentario} Nota:");
                PrintNota(avaliacao.Nota);
                contador+=1;
            }
            Solicitor.Parada();
        }

        private void PrintNota(int nota)
        {
            switch(nota)
            {
                case 1:
                    Console.WriteLine('*');
                    break;
                case 2:
                    Console.WriteLine("**");
                    break;
                case 3:
                    Console.WriteLine("***");
                    break;
                case 4:
                    Console.WriteLine("****");
                    break;
                case 5:
                    Console.WriteLine("*****");
                    break;
            }
        }

    }
}