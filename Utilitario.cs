//Redney Monteiro a46398
using System;
namespace trabalho 
{
    public class Utilitario : Viatura
    {
        public Utilitario(string matricula) : base(matricula)
        {}
        public override void adicionarAluguer(Aluguer a)
        {
            base.setAluguer(a);
        }
        public override decimal getPreco()
        {
            return base.getPrecoDia();
        }
    }
}