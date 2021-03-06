//Redney Monteiro a46398
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
            if (garantir(preco))
            {
                definirPreco(preco);
            }
            else
            {
                definirPreco(100);
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
                linha();
                c.monstrarCliente(); 
            }
        }
        public void definirPreco(decimal preco)
        {
            Viatura v = new Utilitario(null);
            v.setPrecoDia(preco);
        }
        public bool garantir(decimal numero)
        {
            if (numero > 0)
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
                listaViatura.Add(v);
                return true;
            }
            return false;
        }
        public bool adicionarViaturaLuxo(string matricula, decimal taxa)
        {
            if (!garantir(taxa) && taxa != 0)
            {
                corMensagem("Taxa inv??lida:(", "vermelho");
                return false;
            }
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                v = new Luxo(matricula);
                v.setTaxa(taxa);
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
        public bool removerViatura(string matricula)
        {
            Viatura v = encontrarViatura(matricula);
            if(v == null)
            {
                corMensagem($"Viatura ??{matricula}?? n??o existe.", "vermelho");
                return false;
            }
            listaViatura.Remove(v);
            return true;
        }
        public bool removerCliente(string carta)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                corMensagem("Cliente ??{carta}?? n??o existe.", "vermelho");
                return false;
            }
            listaClientes.Remove(c);
            return true;
        }
        public void listarViatura()
        {
            foreach (Viatura v in listaViatura)
            {
                Thread.Sleep(500);
                linha();
                v.monstarViatura();
            }
        }
        public int registrarAluguer(string carta, string matricula, int dias)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                corMensagem($"Cliente ??{carta}?? n??o existe:(", "vermelho");
                return -1;
            }
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                corMensagem($"Viatura ??{matricula}?? n??o existe:(", "vermelho");
                return -1;
            }
            if (!garantir(dias))
            {
                corMensagem("N??mero de dias inv??lidos:(", "vermelho");
                return -1;
            }
            Aluguer a = new Aluguer(dias, v.getPreco(), c, v);
            c.adicionarAluguer(a);
            v.adicionarAluguer(a);
            return a.getID();
        }
        public void listarAlugueresCliente(string carta)
        {
            Cliente c = encontrarCliente(carta);
            if (c == null)
            {
                corMensagem($"Cliente ??{carta}?? n??o existe:(", "vermelho");
                return;
            }
            c.monstrarAlugueres();
        }
        public void listarAlugueresViatura(string matricula)
        {
            Viatura v = encontrarViatura(matricula);
            if (v == null)
            {
                corMensagem($"Viatura ??{matricula}?? n??o existe:(", "vermelho");
                return;
            }
            v.listarAlugueres();
        }
        public void monstrarTotalFaturado()
        {
            decimal total = 0;
            foreach (Viatura v in listaViatura)
            {
                total += v.totalFaturado();
            }
            corMensagem($"Total Faturado: {total}$", "verde");
        }
        public void monstrarTotalFaturadoViatura(string matricula)
        {
            Viatura v = encontrarViatura(matricula);
            if(v == null)
            {
                corMensagem($"Viatura ??{matricula}?? n??o existe:(", "vermelho");
                return;
            }
            corMensagem($"Total Faturado: {v.totalFaturado()}$", "verde");
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
                if (v.totalFaturado() != 0)
                {
                    listaTotal.Add(v.totalFaturado());
                }
                if (v.getQuant() != 0)
                {
                    listaQuant.Add(v.getQuant());
                }
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
                if (c.getMaiorAluguer() != 0)
                {
                    listaMaiorCliente.Add(c.getMaiorAluguer());   
                }
                listaMaiorCliente.Sort();
                listaMaiorCliente.Reverse();
            }
            if (n > (listaTotal.Count))
            {
                n = listaTotal.Count;
            }
            titulo("Ve??culos com maior Fatura");
            linha();
            for (int i = 0; i < n; i++)
            {
                max = listaTotal[i];
                foreach (Viatura v in listaViatura)
                {
                    if (!(v.totalFaturado() == max))
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
                    if (!(v.getQuant() == max))
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
                    if (!(c.getMaiorAluguer() == max))
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
        static void center(string msg, int num)
        {
            int total, espaco;
            total = num - msg.Length;
            espaco = (total / 2) + msg.Length;
            corMensagem(msg.PadLeft(espaco, ' '), "azul");
        }
        static void corMensagem(string msg, string cor)
        {
            if (cor == "azul")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(msg);
            }
            else if (cor == "vermelho")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
            }
            else if (cor == "verde")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
            }
            Console.ResetColor();
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