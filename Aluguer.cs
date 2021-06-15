//Redney Monteiro a46398
using System;
namespace trabalho
{
    public class Aluguer
    {
        static int idSeguinte = 1;
        int dias, id;
        decimal valor;
        Viatura v;
        Cliente c;
        public Aluguer(int dias, decimal valor, Cliente c, Viatura v)
        {
            id = idSeguinte++;
            this.dias = dias;
            this.valor = valor * dias;
            this.c = c;
            this.v = v;
        }
        public void monstrarAluguer(int op)
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Dias: {dias}");
            Console.WriteLine($"Valor: {valor}$");
            if (op == 1)
            {
                Console.WriteLine($"Viatura: {v.getMatricula()}");
            }
            else if(op == 2)
            {
                Console.WriteLine($"Cliente: {c.getCarta()}");
            }
        }
        public decimal getValor()
        {
            return this.valor;
        }
        public int getID()
        {
            return this.id;
        }
    }
}