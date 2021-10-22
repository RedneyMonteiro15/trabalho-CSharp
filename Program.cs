//Redney Monteiro a46398
using System;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            AlugAuto a = new AlugAuto(50);
            a.adicionarCliente("Redney", "C1");
            a.adicionarCliente("Taís", "C2");
            a.adicionarCliente("Kiki", "C3");
            a.adicionarCliente("Pedro", "C4");
            a.adicionarViaturaLuxo("L1", 20);
            a.adicionarViaturaLuxo("L2", 30);
            a.adicionarViaturaLuxo("L3", 10);
            a.adicionarViaturaUtilitaria("U1");
            a.adicionarViaturaUtilitaria("U2");
            a.adicionarViaturaUtilitaria("U3");
            a.adicionarViaturaUtilitaria("U4");
            a.registrarAluguer("C2", "U1", 4);
            a.registrarAluguer("C1", "U1", 4);
            a.registrarAluguer("C2", "L2", 2);
            a.registrarAluguer("C3", "L3", 2);
            a.registrarAluguer("C2", "L2", 6);

            while (true)
            {
                titulo("AlugAuto");
                int op;
                header("Adicionar ", "Remover", "Registrar Aluguer", "Monstrar", "Estatisticas", "Sair");
                op = leiaOp(6);
                if (op == 1)
                {
                    Console.Clear();
                    titulo("Adicionar");
                    header("Cliente", "Viatura");
                    op = leiaOp(2);
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Adicionar Cliente");
                        linha();
                        Console.Write("Nome: ");
                        string nome = (Console.ReadLine()).ToUpper();
                        Console.Write("Carta: ");
                        string carta = (Console.ReadLine()).ToUpper();
                        bool resp = a.adicionarCliente(nome, carta);
                        if (!resp)
                        {
                            corMensagem("ERRO!!! Não foi possível adicionar Cliente:(", "vermelho");
                        }
                        else
                        {
                            corMensagem($"Cliente «{nome}» adicionada com sucesso:)", "verde");
                        }
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Adicionar Viatura");
                        header("Luxo", "Utilitario");
                        op = leiaOp(2);
                        if (op == 1)
                        {
                            Console.Clear();
                            titulo("Adicionar Viatura Luxo");
                            linha();
                            Console.Write("Matrícula: ");
                            string matricula = (Console.ReadLine()).ToUpper();
                            Console.Write("Taxa: ");
                            decimal taxa = Convert.ToDecimal(Console.ReadLine());
                            bool resp = a.adicionarViaturaLuxo(matricula, taxa);
                            if (!resp)
                            {
                                corMensagem("ERRO!!! Não foi possível adicionar Viatura:(", "vermelho");
                            }
                            else
                            {
                                corMensagem($"Viatura «{matricula}» adicionada com sucesso:)", "verde");
                            }
                        }
                        else if (op == 2)
                        {
                            Console.Clear();
                            titulo("Adicionar Viatura Utilitaria");
                            linha();
                            Console.Write("Matrícula: ");
                            string matricula = (Console.ReadLine()).ToUpper();
                            bool resp = a.adicionarViaturaUtilitaria(matricula);
                            if (!resp)
                            {
                                corMensagem("ERRO!!! Não foi possível adicionar Viatura:(", "vermelho");
                            }
                            else
                            {
                                corMensagem($"Viatura «{matricula}» adicionada com sucesso:)", "verde");
                            }
                        }
                    }
                }
                else if (op == 2)
                {
                    Console.Clear();
                    titulo("Remover");
                    header("Cliente", "Viatura");
                    op = leiaOp(2);
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Remover Cliente");
                        linha();
                        Console.Write("Nome: ");
                        string carta = (Console.ReadLine()).ToUpper();
                        bool resp = a.removerCliente(carta);
                        if (!resp)
                        {
                            corMensagem("ERRO!!! Não foi possível remover Cliente:(", "vermelho");
                        }
                        else
                        {
                            corMensagem($"Cliente «{carta}» removido com sucesso:)", "verde");
                        }
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Remover Viatura");
                            linha();
                            Console.Write("Matrícula: ");
                            string matricula = (Console.ReadLine()).ToUpper();
                            bool resp = a.removerViatura(matricula);
                            if (!resp)
                            {
                                corMensagem("ERRO!!! Não foi possível adicionar Viatura:(", "vermelho");
                            }
                            else
                            {
                                corMensagem($"Viatura «{matricula}» adicionada com sucesso:)", "verde");
                            }
                    }
                }
                else if (op == 3)
                {
                    Console.Clear();
                    titulo("Registrar Aluguer");
                    linha();
                    Console.Write("Carta: ");
                    string carta = (Console.ReadLine()).ToUpper();
                    Console.Write("Matricula: ");
                    string matricula = (Console.ReadLine()).ToUpper();
                    Console.Write("Dias: ");
                    int dias = Convert.ToInt32(Console.ReadLine());
                    int resp = a.registrarAluguer(carta, matricula, dias);
                    if (resp > 0)
                    {
                        corMensagem($"Aluguer registrado com sucesso:) \nID do aluguer: {resp}", "verde");
                    }
                }
                else if (op == 4)
                {
                    Console.Clear();
                    titulo("Monstrar");
                    header("Lista de Cliente", "Lista de Viatura", "Alugueis");
                    op = leiaOp(3);
                    if (op == 1)
                    {
                        Console.Clear();
                        titulo("Lista de Cliente");
                        a.listarCliente();
                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        titulo("Lista de Viatura");
                        a.listarViatura();
                    }
                    else if (op == 3)
                    {
                        Console.Clear();
                        titulo("Monstrar Alugueis");
                        header("Cliente", "Veiculo");
                        op = leiaOp(3);
                        if (op == 1)
                        {
                            Console.Clear();
                            titulo("Monstar Aluguer de Cliente");
                            linha();
                            Console.Write("Carta: ");
                            string carta = (Console.ReadLine()).ToUpper();
                            titulo($"Lista de Aluguer de {carta}");
                            a.listarAlugueresCliente(carta);
                        }
                        else if (op == 2)
                        {
                            Console.Clear();
                            titulo("Monstar Aluguer de Viatura");
                            linha();
                            Console.Write("Matrícula: ");
                            string matricula = (Console.ReadLine()).ToUpper();
                            titulo($"Lista de Aluguer de {matricula}");
                            a.listarAlugueresViatura(matricula);
                        }
                    }
                }
                else if (op == 5)
                {
                    Console.Clear();
                    titulo("Monstrar");
                    header("Total Fatudo", "Total Fatudo por Veículo", "Top n");
                    op = leiaOp(3);
                    if (op == 1)
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
                        string matricula = (Console.ReadLine()).ToUpper();
                        a.monstrarTotalFaturadoViatura(matricula);
                    }
                    else if (op == 3)
                    {
                        Console.Clear();
                        titulo("Monstrar Top n");
                        linha();
                        Console.Write("Número: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if (n > 0)
                        {
                            a.monstrarTop(n);
                        }
                        else
                        {
                            corMensagem("Número inválido:(", "vermelho");
                        }
                    }
                }
                else if (op == 6)
                {
                    break;
                }
                linha();
                bool cont = continuar();
                if (!cont)
                {
                    break;
                }
                Console.Clear();
            }
            titulo("FIM DO PROGRAMA");
            linha();
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
                corMensagem($"Opção Inválida:( Digite um opção entre [1, {i}]", "vermelho");
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
                Console.Write("Quer Continuar? [S/N] ");
                char res = ((Console.ReadLine()).ToUpper().Trim())[0];
                if (res == 'S')
                {
                    return true;
                }
                else if (res == 'N')
                {
                    return false;
                }
                corMensagem("Opção Invalída:( Digite apenas Sim ou Não.", "vermelho");
            }
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
        static void center(string msg, int num)
        {
            int total, espaco;
            total = num - msg.Length;
            espaco = (total / 2) + msg.Length;
            corMensagem(msg.PadLeft(espaco, ' '), "azul");
        }
    }
}