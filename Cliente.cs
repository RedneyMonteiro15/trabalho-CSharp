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
            Console.WriteLine($"Carta: {carta}");
            Console.WriteLine($"Nome: {nome}");
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
        public int getMaiorAluguer()
        {
            return listaAluguer.Count; 
        }
    }
}