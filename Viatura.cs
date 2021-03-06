//Redney Monteiro a46398
using System;
using System.Collections.Generic;
using System.Threading;
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
        public static void definirPreco(decimal preco)
        {
            precoDia = preco;
        }
        public string getMatricula()
        {
            return matricula;
        }
        public virtual void monstarViatura()
        {
            Console.WriteLine($"Matrícula: { matricula}");
            Console.WriteLine($"Preço Dia: {precoDia}$");
        }
        public void listarAlugueres()
        {
            foreach (Aluguer a in listaAluguer)
            {
                Console.WriteLine("------------------------------");
                Thread.Sleep(500);
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
        public int getQuant()
        {
            return listaAluguer.Count;
        }
        public void setPrecoDia(decimal preco)
        {
            definirPreco(preco);
        }
        public virtual void setTaxa(decimal taxa)
        {}
    }
}