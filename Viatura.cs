using System;
using System.Collections.Generic;
namespace trabalho
{
    public class Viatura
    {
        List<Aluguer> listaAluguer;
        string matricula;
        static decimal precoDia;
        public Viatura(string matricula)
        {
            this.matricula = matricula;
            listaAluguer = new List<Aluguer>();
        }
        public Viatura()
        {}
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
        public void adicionarAluguer(Aluguer a)
        {
            listaAluguer.Add(a);
        }
        public void monstrarAlugueres()
        {
            foreach (Aluguer a in listaAluguer)
            {
                a.monstrarAluguer();
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
    }
}