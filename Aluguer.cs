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
        public void monstrarAluguer()
        {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Dias: {this.dias}");
            Console.WriteLine($"Valor: {this.valor}$");
            Console.WriteLine($"Viatura: {this.v.getMatricula()}");
        }
        public decimal getValor()
        {
            return this.valor;
        }
    }
}