namespace ShopBr.Model
{
    public class Correio
    {
        public Correio()
        {
            Id = Guid.NewGuid();
        }
        public Correio(byte prazo, double custo)
        {
            Id =  Guid.NewGuid();
            Prazo = prazo;
            Custo = custo;
        }

        public Correio(Guid id, byte prazo, double custo)
        {
            Id = id;
            Prazo = prazo;
            Custo = custo;
        }

        public override string ToString()
        {
            return $"Prazo:{Prazo} Custo:{Custo}";
        }
        public Guid Id { get; set; }
        public byte Prazo { get; set; }
        public double Custo { get; set; }
    }
}