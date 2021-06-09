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
            Console.WriteLine($"Dias: {this.dias}");
            Console.WriteLine($"Valor: {this.valor}$");
            if (op == 1)
            {
                Console.WriteLine($"Viatura: {this.v.getMatricula()}");
            }
            else if(op == 2)
            {
                Console.WriteLine($"Cliente: {this.getCarta()}");
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
        public string getMatricula()
        {
            return v.getMatricula();
        }
        public string getCarta()
        {
            return c.getCarta();
        }
    }
}