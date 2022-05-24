namespace ShopBr.Model
{
    public class Correio
    {
        public Correio(byte prazo, double custo)
        {
            Id = new Guid();
            Prazo = prazo;
            Custo = custo;
        }

        public Correio(Guid id, byte prazo, double custo)
        {
            Id = id;
            Prazo = prazo;
            Custo = custo;
        }

        public Guid Id { get; set; }
        public byte Prazo { get; set; }
        public double Custo { get; set; }
    }
}