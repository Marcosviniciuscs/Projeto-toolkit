using System;
using System.Collections.Generic;

namespace AV2
{
    internal static class Item4_DetectorLoop
    {
        public static void Executar()
        {
            Console.Write("Digite um número inicial para Collatz: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Entrada inválida.");
                return;
            }

            Console.Write("Limite de passos: ");
            if (!int.TryParse(Console.ReadLine(), out int limite) || limite <= 0)
            {
                Console.WriteLine("Limite inválido. Usando 1000.");
                limite = 1000;
            }

            HashSet<int> visitados = new();
            int passos = 0;

            while (n != 1 && passos < limite)
            {
                if (visitados.Contains(n))
                {
                    Console.WriteLine($"Possível laço detectado no valor {n}.");
                    break;
                }

                visitados.Add(n);
                n = (n % 2 == 0) ? n / 2 : 3 * n + 1;
                passos++;
            }

            Console.WriteLine($"Execução encerrada após {passos} passos.");

            Console.WriteLine("\nReflexão: a repetição de estados pode indicar um laço, mas nem sempre garante não terminação. " +
                              "No caso de Collatz, pode haver falsos positivos e negativos, pois não sabemos se a sequência sempre chega a 1.");
        }
    }
}
