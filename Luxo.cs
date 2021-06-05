namespace trabalho
{
    public class Luxo : Viatura
    {
        decimal taxa;
        public Luxo(string matricula, decimal taxa) : base(matricula)
        {
            this.taxa = taxa;
        }
        public override void adicionarAluguer(Aluguer a)
        {
            base.listaAluguer.Add(a);
        }
        public override decimal getPreco()
        {
            return (base.getPreco() + (base.getPreco() * this.taxa / 100));
        }
    }
}