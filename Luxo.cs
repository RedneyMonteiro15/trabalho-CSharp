//Redney Monteiro a46398
using System;
namespace trabalho
{
    public class Luxo : Viatura
    {
        decimal taxa;
        public Luxo(string matricula) : base(matricula)
        {}
        public override void adicionarAluguer(Aluguer a)
        {
            base.setAluguer(a);
        }
        public override decimal getPreco()
        {
            return (base.getPrecoDia() + (base.getPrecoDia() * this.taxa / 100));
        }
        public override void monstarViatura()
        {
            base.monstarViatura();
            Console.WriteLine($"Taxa: {taxa}%");
        } 
        public override void setTaxa(decimal taxa)
        {
            this.taxa = taxa;
        }
    }
}