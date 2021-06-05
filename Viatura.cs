using System;
using System.Collections.Generic;
namespace trabalho
{
    abstract public class Viatura
    {
        public List<Aluguer> listaAluguer;
        string matricula;
        static decimal precoDia;
        public Viatura(string matricula)
        {
            this.matricula = matricula;
            listaAluguer = new List<Aluguer>();
        }
        public abstract void adicionarAluguer(Aluguer a);
        public void definirPreco(decimal preco)
        {
            precoDia = preco;
        }
        public string getMatricula()
        {
            return this.matricula;
        }
        public void monstarViatura()
        {
            Console.WriteLine($"Matrícula: {this.matricula}");
            Console.WriteLine($"Preço: {precoDia}");
        }
        public void listarAlugueres()
        {
            foreach (Aluguer a in listaAluguer)
            {
                a.monstrarAluguer();
                Console.WriteLine("------------------------------");
            }
        }
        public decimal totalFaturado()
        {
            decimal total = 0;
            foreach (Aluguer a in listaAluguer)
            {
                total += a.getValor();
            }
            return total;
        }
        public virtual decimal getPreco()
        {
            return precoDia;
        }
    }
}