using System;
using System.Collections.Generic;

namespace trabalho
{
    public class Cliente
    {
        List<Aluguer> listaAluguer;
        string carta, nome;
        public Cliente(string nome,string carta)
        {
            this.nome = nome;
            this.carta = carta;
            listaAluguer = new List<Aluguer>();
        }
        public string getCarta()
        {
            return this.carta;
        }
        public void monstrarCliente()
        {
            Console.WriteLine($"Carta: {this.carta}");
            Console.WriteLine($"Nome: {this.nome}");
        }
        public void adicionarAluguer(Aluguer a)
        {
            listaAluguer.Add(a);
        }
        public void monstrarAlugueres()
        {
            foreach (Aluguer a in listaAluguer)
            {
                Console.WriteLine("------------------------------");
                a.monstrarAluguer(1);
            }
        }
        public int getMaiorAluguer(string carta)
        {
            int total = 0;
            foreach (Aluguer a in listaAluguer)
            {
                if (a.getCarta() == carta)
                {
                    total++;
                }
            }
            return total; 
        }
    }
}