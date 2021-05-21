using System;
using System.Collections.Generic;

namespace trabalho
{
    public class AlugAuto
    {
        List<Cliente> listaClientes;
        List<Viatura> listaViatura;
        public AlugAuto(decimal preco)
        {
            listaClientes = new List<Cliente>();
            listaViatura = new List<Viatura>();
            if (garantirPreco(preco))
            {
                definirPreco(preco);
            }
            else
            {
                definirPreco(5);
            }
        }
        public void adicionarCliente(string nome, string carta)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                c = new Cliente(nome, carta);
                listaClientes.Add(c);
                return;
            }
            Console.WriteLine("Cliente já está cadastrado");
        }
        public Cliente encontrarCliente(string carta)
        {
            foreach (Cliente c in listaClientes)
            {
                if(carta == c.getCarta())
                {
                    return c;
                }
            }
            return null;
        }
        public void listarCliente()
        {
            foreach (Cliente c in listaClientes)
            {
                c.monstrarCliente();
            }
        }
        public void definirPreco(decimal preco)
        {
            Viatura v = new Viatura();
            v.definirPreco(preco);
        }
        public bool garantirPreco(decimal preco)
        {
            if (preco > 0)
            {
                return true;
            }
            return false;
        }
        public void adicionarViaturaUtilitaria(string matricula)
        {
            Viatura v = encontrarViatura(matricula);
            if(v == null)
            {
                v = new Viatura(matricula);
                listaViatura.Add(v);
                return;
            }
            Console.WriteLine("Viatura já existe");
        }
        public void adicionarViaturaLuxo(string matricula, decimal taxa)
        {
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                v = new Viatura(matricula);
                listaViatura.Add(v);
                return;
            }
            Console.WriteLine("Viatura já existe");
        }
        public Viatura encontrarViatura(string matricula)
        {
            foreach (Viatura v in listaViatura)
            {
                if(matricula == v.getMatricula())
                {
                    return v;
                }
            }
            return null;
        }
        public void listarViatura()
        {
            foreach (Viatura v in listaViatura)
            {
                v.monstarViatura();
            }
        }
        public void registrarAluguer(string carta, string matricula, int dias)
        {
            Cliente c = encontrarCliente(carta);
            if(c == null)
            {
                Console.WriteLine("Cliente não existe.");
                return;
            }
            Viatura v = encontrarViatura(matricula);
            if(v == null)
            {
                Console.WriteLine("Viatura não existe.");
                return;
            } 
            Aluguer a = new Aluguer(dias, 19, c, v);
            c.adicionarAluguer(a);
            v.adicionarAluguer(a);
        }
        public void listarAlugueresCliente(string carta)
        {
            foreach (Cliente c in listaClientes)
            {
                if (carta == c.getCarta())
                {
                    c.monstrarAlugueres();
                }   
            }
        }
        public void listarAlugueresViatura(string matricula)
        {
            foreach (Viatura v in listaViatura)
            {
                if (matricula == v.getMatricula())
                {
                    v.monstrarAlugueres();
                }
            }
        }
        public void monstrarTotalFaturado()
        {
            decimal total = 0;
            foreach (Viatura v in listaViatura)
            {
                total += v.totalFaturado();
            }
            Console.WriteLine($"Total Faturado: {total}");
        }
        public void monstrarTotalFaturadoViatura(string matricula)
        {
            decimal total = 0;
            foreach (Viatura v in listaViatura)
            {
                if (v.getMatricula() == matricula)
                {
                    total += v.totalFaturado();
                }
            }
            Console.WriteLine($"Total Fatura: {total}");
        }
    }
}