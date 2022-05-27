using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdmLoja
    {
        public AdmLoja()
        {
            Gerenciador = new CLoja();
        }
        public CLoja Gerenciador { get; set; }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Correios");
            Console.WriteLine("1- Para cadastrar um nova Loja");
            Console.WriteLine("2- Para Excluir uma Loja");
            Console.WriteLine("3- Para editar uma loja");
            Console.WriteLine("4- Adicionar Produtos");
            Console.WriteLine("5- Para remover Produtos");
            Console.WriteLine("6- Para sair para o menu");
            var option = Solicitor.GetByteInterval(1,6);
            switch(option)
            {
                case 1:
                    CadastrarLoja();
                    break;
                case 2:
                    ExcluirLoja();
                    //ANCHOR tratar em produto em loja
                    break;
                case 3: 
                    //ANCHOR adicionar função de editar Loja
                    break;
                case 4:
                    try{
                        AddProduto(SelectLoja());
                    }catch(Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 5:
                    try{
                        RemoveProduto(SelectLoja());
                    }catch(Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                    break;

            }
            if(option!= 6)
                Menu();

        }
        private void CadastrarLoja()
        {
            var loja = new Loja();
            Console.Clear();
            Console.WriteLine("Cadastrar nova loja");
            Console.WriteLine("Insira o nome da loja");
            loja.Nome = Solicitor.GetValidName();
            Console.WriteLine("Insira endereco da loja");
            loja.Endereco = Solicitor.GetValidString();
            Console.WriteLine("Insira o telefone da loja");
            Console.WriteLine("Siga o padrão 75-988917791");
            loja.Telefone = Solicitor.GetValidTelefone();
            Console.WriteLine("Insira o email da loja");
            loja.Email = Solicitor.GetValidEmail();
            Gerenciador.Adcionar(loja);
        } 

        private void ExcluirLoja()
        {
            Console.Clear();
            Console.WriteLine("Lojas");
            var lojas = Gerenciador.Get();
            int contador = 0;
            foreach(Loja loja in lojas)
            {
                Console.WriteLine($"{contador} {loja}");
                contador+=1;
            }

            if(contador!=0){
                Console.WriteLine("Insira o numero do correio que deseja excluir");
                int numeroCorreio = Solicitor.GetIntInterval(0, contador-1);
                Gerenciador.Remove(lojas[numeroCorreio].Id);
                Solicitor.Parada();
            }else{
                Console.WriteLine("Nenhuma loja cadastrada");
                Solicitor.Parada();
            }

        }
        public Loja SelectLoja()
        {
            Console.Clear();
            Console.WriteLine("Lojas");
            var lojas = Gerenciador.Get();
            int contador = 0;
            foreach(Loja loja in lojas)
            {
                Console.WriteLine($"{contador} {loja}");
                contador+=1;
            }

            if(contador!=0){
                Console.WriteLine("Insira o numero do correio que deseja escolher");
                int numeroLoja = Solicitor.GetIntInterval(0, contador-1);
                return lojas[numeroLoja];
            }
            else
            {
                throw new Exception("Nenhuma loja cadastrada");
            }
        }
        private void AddProduto(Loja loja)
        {
            CProduto manipulaProduto = new CProduto();
            List<Produto> produtos = manipulaProduto.GetSemLoja(loja.Id);
            int contador = 0;
            Console.Clear();
            Console.WriteLine("Adicionar produtos na loja");
            foreach(Produto produto in  produtos)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador!=0){
                Console.WriteLine("Insira o numero do produto que quer cadastrar:");
                int numeroProduto = Solicitor.GetIntInterval(0, contador-1);
                manipulaProduto.adcionarNaLoja(loja.Id, produtos[numeroProduto].Id);
                Console.WriteLine("Produto adicionado a loja");
            }else{
                Console.WriteLine("Impossivel cadastrar um produto nessa loja");
            }
            Solicitor.Parada();
        }
        private void RemoveProduto(Loja loja)
        {
            CProduto manipulaProduto = new CProduto();
            List<Produto> produtos = manipulaProduto.GetNaLoja(loja.Id);
            int contador = 0;
            Console.Clear();
            Console.WriteLine("Remover produto da loja");
            foreach(Produto produto in  produtos)
            {
                Console.WriteLine($"{contador}: {produto}");
                contador+=1;
            }
            if(contador!=0){
                Console.WriteLine("Insira o numero do produto que quer remover:");
                int numeroProduto = Solicitor.GetIntInterval(0, contador-1);
                manipulaProduto.RemoveDaLoja(loja.Id, produtos[numeroProduto].Id);
                Console.WriteLine("Produto removido da loja");
            }else{
                Console.WriteLine("Impossivel remover um produto dessa loja");
            }
            Solicitor.Parada();
        }
    }
}