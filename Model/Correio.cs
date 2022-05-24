namespace ShopBr.Model
{
    public class Correio
    {
        public Correio(byte prazo, float custo)
        {
            Id = new Guid();
            Prazo = prazo;
            Custo = custo;
        }
        
        public Guid Id { get; set; }
        public byte Prazo { get; set; }
        public float Custo { get; set; }
    }
}