using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdministraAvaliacao{
        public AdministraAvaliacao()
        {
            Gerenciador = new CAvaliacao();
        }
        private CAvaliacao Gerenciador { get; set; }
        public void Menu()
        {
            Console.Clear();
            int contador = 0;
            List<Avaliacao> avaliacoes = Gerenciador.Get();
            foreach(Avaliacao avaliacao in avaliacoes)
            {
                Console.Write($"{contador} {avaliacao.ProdutoId} {avaliacao.Comentario}");
                PrintNota(avaliacao.Nota);
                contador+=1;
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("1- Para excluir uma avaliacao");
            Console.WriteLine("2- Para sair");
            byte option = Solicitor.GetByteInterval(1,2);
            if(contador>0){
                if(option == 1){
                    Console.WriteLine("Insira o numero da avaliacao que deseja remover");
                    int remover = Solicitor.GetIntInterval(0, contador-1);
                    Gerenciador.RemoveByIds(avaliacoes[remover].ClienteId, avaliacoes[remover].ProdutoId);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma avalição foi cadastrada ainda, aguarde um cliente deixar uma avaliacao");
                Console.WriteLine("Pressione qualquer tecla para prosseguir");
                Console.ReadKey();
            }
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