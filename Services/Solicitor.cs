using System.Text.RegularExpressions;

namespace UserSolicitor{
    public class Solicitor{
        public static short GetShortInterval(short start, short end ){
            short option = 0;
            try{
                option = short.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetShortInterval(start, end );
            }
            if(option >= start && option <= end){
                return option;
            }else{
                Console.WriteLine("O valor não corresponde a nenhuma opção, Tente novamente");
                return GetShortInterval(start, end ); 
            }
        }
        public static byte GetByteInterval(byte start, byte end ){
            byte option = 0;
            try{
                option = byte.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetByteInterval(start, end );
            }
            if(option >= start && option <= end){
                return option;
            }else{
                Console.WriteLine("O valor não corresponde a nenhuma opção, Tente novamente");
                return GetByteInterval(start, end ); 
            }
        }
        public static int GetIntInterval(int start, int end ){
            int option = 0;
            try{
                option = int.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetIntInterval(start, end );
            }
            if(option >= start && option <= end){
                return option;
            }else{
                Console.WriteLine("O valor não corresponde a nenhuma opção, Tente novamente");
                return GetIntInterval(start, end ); 
            }
        }
        public static double GetValidpositiveDouble()
        {
            double value = GetValidDouble();
            if(value>0){
                return value;
            }else{
                Console.WriteLine("Insira um valor positivo, Tente novamente");
                return GetValidpositiveDouble();
            }
        }
        public static int GetValidpositiveInt()
        {
            int value = GetValidInt();
            if(value>0){
                return value;
            }else{
                Console.WriteLine("Insira um valor positivo, Tente novamente");
                return GetValidpositiveInt();
            }
        }
        public static string GetValidCPF()
        {
            string name = GetValidString();
            var reg = new Regex(@"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$");
            if(reg.IsMatch(name)){
                return name;
            }
            Console.WriteLine("cpf Invalido, tente novamente");
            return GetValidCPF();
        }
        public static double GetValidDouble()
        {
          double value = 0;
            try{
                value = double.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetValidDouble();
            }  
            return value;

        }
        public static float GetValidFloat()
        {
          float value = 0;
            try{
                value = float.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetValidFloat();
            }  
            return value;

        }
        public static int GetValidInt()
        {
          int value = 0;
            try{
                value = int.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetValidInt();
            }  
            return value;

        }

        public static uint GetValidUint()
        {
          uint value = 0;
            try{
                value = uint.Parse(Console.ReadLine());
            }catch{
                Console.WriteLine("Valor invalido tente novamente");
                return GetValidUint();
            }  
            return value;

        }

        public static string GetValidString()
        {
            string value = "";
            value = Console.ReadLine();
            if(value != null){
                return value;
            }
            Console.WriteLine("Insira uma string valida");
            return GetValidString();
        }

        public static string GetValidName()
        {
            string leitura = GetValidString();
            var reg = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇ]{2,}$");
            string[] nomecompleto  = leitura.Split(' '); 
            bool valido = true;
            foreach(string nome in nomecompleto)
            {
                if(!reg.IsMatch(nome)){
                    valido = false;
                }
            }
            if(valido)
            {
                return leitura;
            }
            Console.WriteLine("Nome Invalido, tente novamente");
            return GetValidName();
        }
        public static DateTime getValidDate()
        {
            string date = GetValidString();
            DateTime birthDate; 
            try{
                birthDate = DateTime.Parse(date);
            }catch{
                Console.WriteLine("Favor insira uma data valida");
                return getValidDate();
            }
            //ANCHOR melhorar tramento de data e limitar espaço de tempo
            return birthDate;
        }
    } 

}