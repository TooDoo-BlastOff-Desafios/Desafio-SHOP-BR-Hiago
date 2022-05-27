//ANCHOR fazer funções 
using ShopBr.Controller;
using ShopBr.Model;
using UserSolicitor;

namespace ShopBr.View
{
    public class ClienteView
    {

        public ClienteView()
        {
            cliente = new Cliente();
            manipulator = new CCliente();
        }
        private Cliente cliente { get; set; }
        private CCliente manipulator { get; set; }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Seja bem vindo!");
            Console.WriteLine("1- Ja é um cliente");
            Console.WriteLine("2- Quero me tornar cliente");
            Console.WriteLine("3- Sair para o menu");
            byte option = Solicitor.GetByteInterval(1,3);
            switch(option){
                case 1:
                    ConsultaCLiente();
                    break;
                case 2:
                    CadastrarCLiente();
                    break;
            }
        }
        public void CadastrarCLiente()
        {
            Console.Clear();
            Console.WriteLine("Vamos lá, para efetuar seu cadastro vou precisar de Alguns dados");
            Console.WriteLine("Primeiro vou precisar que você informe seu CPF");
            Console.WriteLine("Siga o formato: 000.000.000-00");
            cliente.Cpf = Solicitor.GetValidCPF();
            Console.WriteLine("Insira seu nome");
            cliente.Nome = Solicitor.GetValidName();
            Console.WriteLine("Insira seu telefone:");
            //ANCHOR criar solicitor para validar a entrada do telefone
            cliente.Telefone = Solicitor.GetValidString();
            //ANCHOR criar solicitor para validar a entrada do cep
            Console.WriteLine("Insira seu Cep");
            cliente.Cep = Solicitor.GetValidString();
            //ANCHOR criar solicitor para validar a entrada do email
            Console.WriteLine("Insira seu Email");
            cliente.Email = Solicitor.GetValidString();
            //ANCHOR criar solicitor para validar a entrada da senha
            Console.WriteLine("Insira sua senha");
            Console.WriteLine("A senha deve conter: ");
            Console.WriteLine("8 caracteres no mínimo");
            Console.WriteLine("1 Letra Maiúscula no mínimo");
            Console.WriteLine("1 Número no mínimo");
            Console.WriteLine("1 Símbolo no mínimo: $*&@#");
            cliente.Senha = Solicitor.GetValidString();//ANCHOR fazer função get senha
            manipulator.Adicionar(cliente);
            MenuCliente();
        }

        private void  ConsultaCLiente()
        {
            Console.WriteLine("Para fazer o login fazor insira seu CPF");
            Console.WriteLine("Siga o formato: 000.000.000-00");
            cliente.Cpf = Solicitor.GetValidCPF();
            Console.WriteLine("Favor insira sua senha");
            cliente.Senha = Solicitor.GetValidString();//ANCHOR fazer função get senha
            if(manipulator.Validar(cliente.Cpf, cliente.Senha)){
                MenuCliente();
            }


        }
        private void MenuCliente()
        {
            Console.Clear();
            Console.WriteLine($"Bem Vindo {cliente.Nome}");
            Console.WriteLine("1- Para fazer uma compra");
            Console.WriteLine("2- Para avaliar uma Compra");
            Console.WriteLine("3- Verificar compras");
            Console.WriteLine("4- Voltar ao Menu");
            byte  option = Solicitor.GetByteInterval(1,4);
            switch(option)
            {
                case 1:
                    var compra = new ClienteCompras(cliente.Cpf);
                    compra.MenuCompra();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

        }
    }
}