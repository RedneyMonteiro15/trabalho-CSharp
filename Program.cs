using System;
using System.Collections.Generic;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
    
            AlugAuto a = new AlugAuto(10);
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
            a.listarAlugueresViatura("L1");
            a.listarAlugueresViatura("L3");
            a.monstrarTotalFaturado();
            a.monstrarTotalFaturadoViatura("L1");
        }
        
    }
}
