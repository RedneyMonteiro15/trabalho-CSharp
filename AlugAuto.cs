using System;
using System.Collections.Generic;
using System.Threading;

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
        public bool adicionarCliente(string nome, string carta)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                c = new Cliente(nome, carta);
                listaClientes.Add(c);
                return true;
            }
            return false;
        }
        public Cliente encontrarCliente(string carta)
        {
            foreach (Cliente c in listaClientes)
            {
                if (carta == c.getCarta())
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
                Thread.Sleep(500);
                c.monstrarCliente();
                linha();
            }
        }
        public void definirPreco(decimal preco)
        {
            Viatura v = new Utilitario("u");
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
        public bool adicionarViaturaUtilitaria(string matricula)
        {
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                v = new Utilitario(matricula);
                Utilitario u = new Utilitario(matricula);
                listaViatura.Add(u);
                return true;
            }
            return false;
        }
        public bool adicionarViaturaLuxo(string matricula, decimal taxa)
        {
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                v = new Luxo(matricula, taxa);
                listaViatura.Add(v);
                return true;
            }
            return false;
        }
        public Viatura encontrarViatura(string matricula)
        {
            foreach (Viatura v in listaViatura)
            {
                if (matricula == v.getMatricula())
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
                Thread.Sleep(500);
                v.monstarViatura();
                linha();
            }
        }
        public int registrarAluguer(string carta, string matricula, int dias)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                Console.WriteLine("Cliente não existe.");
                return -1;
            }
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                Console.WriteLine("Viatura não existe.");
                return -1;
            }
            Aluguer a = new Aluguer(dias, v.getPreco(), c, v);
            c.adicionarAluguer(a);
            v.adicionarAluguer(a);
            return a.getID();
        }
        public void listarAlugueresCliente(string carta)
        {
            foreach (Cliente c in listaClientes)
            {
                Thread.Sleep(750);
                if (carta == c.getCarta())
                {
                    c.monstrarAlugueres();
                    linha();
                }
            }
        }
        public void listarAlugueresViatura(string matricula)
        {
            foreach (Viatura v in listaViatura)
            {
                Thread.Sleep(750);
                if (matricula == v.getMatricula())
                {
                    v.listarAlugueres();
                    linha();
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
        public void monstrarTop(int n)
        {
            List<decimal> listaTotal = new List<decimal>();
            List<int> listaQuant = new List<int>();
            List<int> listaMaiorCliente = new List<int>();
            List<decimal> listaMaiorTaxa = new List<decimal>();
            decimal max;
            foreach (Viatura v in listaViatura)
            {
                listaTotal.Add(v.getTotal(v.getMatricula()));
                listaQuant.Add(v.getQuant(v.getMatricula()));
                if (v.getPrecoDia() != v.getPreco())
                {
                    listaMaiorTaxa.Add(v.getPreco());
                }
                listaTotal.Sort();
                listaQuant.Sort();
                listaMaiorTaxa.Sort();
                listaTotal.Reverse();
                listaQuant.Reverse();
                listaMaiorTaxa.Reverse();
            }
            foreach (Cliente c in listaClientes)
            {
                listaMaiorCliente.Add(c.getMaiorAluguer(c.getCarta()));
                listaMaiorCliente.Sort();
                listaMaiorCliente.Reverse();
            }
            if (n > (listaTotal.Count))
            {
                n = listaTotal.Count;
            }
            titulo("Veículos com maior Fatura");
            linha();
            for (int i = 0; i < n; i++)
            {
                max = listaTotal[i];
                foreach (Viatura v in listaViatura)
                {
                    if (!(v.getTotal(v.getMatricula()) == max))
                    {
                        continue;
                    }
                    Thread.Sleep(500);
                    v.monstarViatura();
                    Console.WriteLine($"Total: {max}$");
                    Console.WriteLine("------------------------------");
                    break;
                }
            }
            if (n > (listaQuant.Count))
            {
                n = listaQuant.Count;
            }
            Thread.Sleep(750);
            titulo("Veiculos mais Alugados");
            linha();
            for (int i = 0; i < n; i++)
            {
                max = listaQuant[i];
                foreach (Viatura v in listaViatura)
                {
                    if (!(v.getQuant(v.getMatricula()) == max))
                    {
                        continue;
                    }
                    Thread.Sleep(500);
                    v.monstarViatura();
                    Console.WriteLine($"Total: {max}");
                    Console.WriteLine("------------------------------");
                    break;
                }
            }
            if (n > (listaMaiorCliente.Count))
            {
                n = listaMaiorCliente.Count;
            }
            Thread.Sleep(750);
            titulo("Clientes com mais Alugueis");
            linha();
            for (int i = 0; i < n; i++)
            {
                max = listaMaiorCliente[i];
                foreach (Cliente c in listaClientes)
                {
                    if (!(c.getMaiorAluguer(c.getCarta()) == max))
                    {
                        continue;
                    }
                    Thread.Sleep(500);
                    c.monstrarCliente();
                    Console.WriteLine($"Total: {max}");
                    Console.WriteLine("------------------------------");
                    break;
                }
            }
            if (n > (listaMaiorTaxa.Count))
            {
                n = listaMaiorTaxa.Count;
            }
            Thread.Sleep(750);
            titulo("Viatura com maior Taxa");
            linha();
            for (int i = 0; i < n; i++)
            {
                max = listaMaiorTaxa[i];
                foreach (Viatura v in listaViatura)
                {
                    if (!(v.getPreco() == max))
                    {
                        continue;
                    }
                    Thread.Sleep(500);
                    v.monstarViatura();
                    linha();
                    break;
                }
            }
        }
        static void center(string teste, int num)
        {
            int total, esquerda, direita;
            string test = "";
            total = num - teste.Length;
            direita = (total / 2) + teste.Length;
            esquerda = num - direita;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1}", teste.PadLeft(direita, ' '), test.PadRight(esquerda - 1, ' '));
            Console.ResetColor();
        }
        static void corMensagem(string msg, string cor)
        {
            if (cor == "azul")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else if (cor == "vermelho")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else if (cor == "verde")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
        }
        static void titulo(string txt)
        {
            linha();
            center(txt, 30);
        }
        static void linha()
        {
            Console.WriteLine("------------------------------");
        }
    }
}