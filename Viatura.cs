using System;
using System.Collections.Generic;
namespace trabalho
{
    public abstract class Viatura
    {
        List<Aluguer> listaAluguer;
        string matricula;
        static decimal precoDia;
        public Viatura(string matricula)
        {
            this.matricula = matricula;
            listaAluguer = new List<Aluguer>();
        }
        public abstract void adicionarAluguer(Aluguer a);
        public void setAluguer(Aluguer a)
        {
            listaAluguer.Add(a);
        }
        public void definirPreco(decimal preco)
        {
            precoDia = preco;
        }
        public string getMatricula()
        {
            return this.matricula;
        }
        public virtual void monstarViatura()
        {
            Console.WriteLine($"Matrícula: {this.matricula}");
            Console.WriteLine($"Preço Dia: {precoDia}$");
        }
        public void listarAlugueres()
        {
            foreach (Aluguer a in listaAluguer)
            {
                Console.WriteLine("------------------------------");
                a.monstrarAluguer(2);
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
        public abstract decimal getPreco();
        public decimal getPrecoDia()
        {
            return precoDia;
        }
        public decimal getTotal(string matricula)
        {
            decimal total = 0;
            foreach (Aluguer a in listaAluguer)
            {
                if(a.getMatricula() == matricula)
                {
                    total += a.getValor();
                }
            }
            return total;
        }
        public int getQuant(string matricula)
        {
            int total = 0;
            foreach (Aluguer a in listaAluguer)
            {
                if(a.getMatricula() == matricula)
                {
                    total++;
                }
            }
            return total;
        }
    }
}