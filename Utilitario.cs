using System;
namespace trabalho 
{
    public class Utilitario : Viatura
    {
        public Utilitario(string matricula) : base(matricula)
        {}
        public override void adicionarAluguer(Aluguer a)
        {
            base.listaAluguer.Add(a);
        }
        public override decimal getPreco()
        {
            return base.getPreco();
        }
    }
}