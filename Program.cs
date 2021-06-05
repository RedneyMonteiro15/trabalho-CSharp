﻿using System;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
            AlugAuto a = new AlugAuto(50);
            a.adicionarCliente("Redney", "C1");
            a.adicionarCliente("Taís", "C2");
            a.adicionarCliente("Kiki", "C3");
            a.adicionarCliente("Pedro", "C4");
            a.adicionarViaturaLuxo("L1", 10);
            a.adicionarViaturaLuxo("L2", 30);
            a.adicionarViaturaLuxo("L3", 20);
            a.adicionarViaturaUtilitaria("U1");
            a.adicionarViaturaUtilitaria("U2");
            a.adicionarViaturaUtilitaria("U3");
            a.adicionarViaturaUtilitaria("U4");
            a.registrarAluguer("C2", "L1", 4);
            a.registrarAluguer("C1", "L1", 2);
            a.registrarAluguer("C3", "L3", 2);

            while (true)
            {
                titulo("AlugAuto");
                int op;
                header("Adicionar Veiculo", "Adicionar Cliente", "Registrar Aluguer", "Monstrar", "Estatisticas");
                op = leiaOp(5);
                if (op == 1)
                {
                    Console.Clear();
                    titulo("Adicionar Veiculo");
                    header("Luxo", "Utilitario");
                    op = leiaOp(2);
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Adicionar Veiculo Luxo");
                        linha();
                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();
                        Console.Write("Taxa: ");
                        decimal taxa = Convert.ToDecimal(Console.ReadLine());
                        bool resp = a.adicionarViaturaLuxo(matricula, taxa);
                        if (!resp)
                        {
                            corMensagem("ERRO!!! Não foi possível adicionar Viatura", "vermelho");
                        }
                        else
                        {
                            corMensagem("Viatura adicionada com sucesso:)", "verde");
                        }
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Adicionar Veiculo Utilitaria");
                        linha();
                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();
                        bool resp = a.adicionarViaturaUtilitaria(matricula);
                        if (!resp)
                        {
                            corMensagem("ERRO!!! Não foi possível adicionar Viatura", "vermelho");
                        }
                        else
                        {
                            corMensagem($"Viatura «{matricula}» adicionada com sucesso:)", "verde");
                        }
                    }
                }
                else if (op == 2)
                {
                    Console.Clear();
                    titulo("Adicionar Cliente");
                    linha();
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Carta: ");
                    string carta = Console.ReadLine();
                    bool resp = a.adicionarCliente(nome, carta);
                    if (!resp)
                        {
                            corMensagem("ERRO!!! Não foi possível adicionar Cliente", "vermelho");
                        }
                        else
                        {
                            corMensagem($"Cliente «{nome}» adicionada com sucesso:)", "verde");
                        }
                }
                else if (op == 3)
                {
                    Console.Clear();
                    titulo("Registrar Aluguer");
                    linha();
                    Console.Write("Carta: ");
                    string carta = Console.ReadLine();
                    Console.Write("Matricula: ");
                    string matricula = Console.ReadLine();
                    Console.Write("Dias: ");
                    int dias = Convert.ToInt32(Console.ReadLine());
                    int resp = a.registrarAluguer(carta, matricula, dias);
                    if (resp > 0)
                    {
                        corMensagem($"Aluguer registrado com sucesso. \nID do aluguer: {resp}", "verde");
                    }
                }
                else if (op == 4)
                {
                    Console.Clear();
                    titulo("Monstrar");
                    header("Lista de Cliente", "Lista de Viatura", "Alugueis","Cliente", "Veiculo");
                    op = leiaOp(3);
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Lista de Cliente");
                        linha();
                        a.listarCliente();
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Lista de Viatura");
                        linha();
                        a.listarViatura();
                    }
                    else if(op == 3)
                    {
                
                    }
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Monstar Aluguer de Cliente");
                        Console.Write("Carta: ");
                        string carta = Console.ReadLine();
                        a.listarAlugueresCliente(carta);
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Monstar Aluguer de Viatura");
                        Console.Write("Carta: ");
                        string matricula = Console.ReadLine();
                        a.listarAlugueresViatura(matricula);
                    }
                    
                }
                else if (op == 5)
                {
                    Console.Clear();
                    titulo("Monstar");
                    header("Total Faturado", "Total Faturado por Veiculo", "Top");
                    op = leiaOp(3);
                    else if (op == 1)
                    {
                        Console.Clear();
                        titulo("Total Faturado");
                        linha();
                        a.monstrarTotalFaturado();
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Total Faturado por Veiculo");
                        linha();
                        Console.Write("Matricula: ");
                        string matricula = Console.ReadLine();
                        a.monstrarTotalFaturadoViatura(matricula);
                    }
                    else if (op == 3)
                    {
                        Console.Clear();
                        Console.Write("Número: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if (n > 0)
                        {
                            a.monstrarTop(n);
                        }
                        else
                        {
                            corMensagem("Número inválido...", "vermelho");
                        }
                    }
                }
                linha();
                bool cont = continuar();
                if (!cont)
                {
                    break;
                }
                Console.Clear();
            }
        }
        static void linha()
        {
            Console.WriteLine("------------------------------");
        }
        static void header(params string[] lista)
        {
            linha();
            int i = 1;
            foreach (string str in lista)
            {
                Console.WriteLine($"[{i}] - {str}");
                i++;
            }
            linha();
        }
        static int leiaOp(int i)
        {
            while (true)
            {
                int n;
                Console.Write("Sua Opção: ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= i && n > 0)
                {
                    return n;
                }
                corMensagem($"Opção Inválida. Digite um opção entre [1, {i}]", "vermelho");
            }
        }
        static void titulo(string txt)
        {
            linha();
            center(txt, 30);
        }
        static bool continuar()
        {
            while (true)
            {
                Console.WriteLine("Quer Continuar? [S/N] ");
                string resp = (Console.ReadLine()).ToUpper();
                char res = resp[0];
                if (res == 'S')
                {
                    return true;
                }
                else if(res == 'N')
                {
                    return false;
                }
                else
                {
                    corMensagem("Opção Invalída... Digote apneas Sim ou Não.", "vermelho");
                }
            }
        }
        static void corMensagem(string msg, string cor)
        {
            if(cor == "azul")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else if(cor == "vermelho")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            else if(cor == "verde")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
        }
        static void center(string teste, int num){
            int total, esquerda, direita;
            string test = "";
            total = num - teste.Length;
            direita = (total / 2) + teste.Length;
            esquerda = num - direita;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}{1}", teste.PadLeft(direita, ' '), test.PadRight(esquerda-1, ' '));
            Console.ResetColor();
        }
    }
}