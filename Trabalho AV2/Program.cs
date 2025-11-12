using System;
using System.Text;

namespace AV2
{
    internal class Programa
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n=== MENU AV2 - DECIDIBILIDADE, RECONHECIMENTO E MODELOS ===\n");
                Console.WriteLine("1 - Problema × Instância");
                Console.WriteLine("2 - Decisores (L_fim_b / L_mult3_b)");
                Console.WriteLine("3 - Reconhecedor não determinístico");
                Console.WriteLine("4 - Detector ingênuo de loop");
                Console.WriteLine("5 - Simulador de AFD");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha: ");

                string? opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1": Item1_ProblemaInstancia.Executar(); break;
                    case "2": Item2_Decisores.Executar(); break;
                    case "3": Item3_Reconhecedor.Executar(); break;
                    case "4": Item4_DetectorLoop.Executar(); break;
                    case "5": Item5_SimuladorAFD.Executar(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
