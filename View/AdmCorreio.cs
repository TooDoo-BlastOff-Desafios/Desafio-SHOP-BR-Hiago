using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class AdmCorreio
    {
        public AdmCorreio()
        {
            Gerenciador = new CCorreio();
        }
        public CCorreio Gerenciador { get; set; }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Correios");
            Console.WriteLine("1- Para cadastrar um novo Correio");
            Console.WriteLine("2- Para Excluir um correio");
            Console.WriteLine("3- Para editar um correio");
            Console.WriteLine("4- Para sair para o menu");
            var option = Solicitor.GetByteInterval(1,4);
            switch(option)
            {
                case 1:

                    break;
                case 2:
                    ExcluirCorreios();
                    break;
                case 3: 
                    break;
            }
            if(option!= 4)
                Menu();

        }
        private void ExcluirCorreios()
        {
            Console.Clear();
            Console.WriteLine("Correios");
            var correios = Gerenciador.Get();
            int contador = 0;
            foreach(Correio correio in correios)
            {
                Console.WriteLine($"{contador} {correio}");
                contador+=1;
            }
            if(contador>0){
                Console.WriteLine("Insira o numero do correio que deseja excluir");
                int numeroCorreio = Solicitor.GetIntInterval(0, contador-1);
                Gerenciador.Remove(correios[numeroCorreio].Id);
                Solicitor.Parada();
            }

        }
        private void CadastrarCorreio()
        {
            Correio correio = new Correio();
            Console.Clear();
            Console.WriteLine("Cadastrar novo correio");
            Console.WriteLine("Insira o prazo de entrega do correio");
            correio.Prazo = Solicitor.GetValidpositiveInt();
            Console.WriteLine("Insira o custo de entrega deste correio");
            correio.Custo = Solicitor.GetValidpositiveDouble();
            Gerenciador.Adcionar(correio);
        } 
    }
}
