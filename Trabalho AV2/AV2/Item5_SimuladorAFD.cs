using System;
using System.Collections.Generic;

namespace AV2
{
    internal static class Item5_SimuladorAFD
    {
        public static void Executar()
        {
            Console.WriteLine("Simulador de AFD sobre Σ = {a,b}");
            Console.Write("Digite uma cadeia: ");
            string? cadeia = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia. Rejeitada.");
                return;
            }

            foreach (char c in cadeia)
            {
                if (c != 'a' && c != 'b')
                {
                    Console.WriteLine("Entrada inválida. Use apenas 'a' e 'b'.");
                    return;
                }
            }

            SimularAFD(cadeia);
        }

        // AFD: aceita cadeias que terminam com 'b'
        private static void SimularAFD(string cadeia)
        {
            Dictionary<(string, char), string> transicoes = new()
            {
                { ("q0", 'a'), "q0" },
                { ("q0", 'b'), "q1" },
                { ("q1", 'a'), "q0" },
                { ("q1", 'b'), "q1" }
            };

            string estado = "q0";
            HashSet<string> finais = new() { "q1" };

            foreach (char simbolo in cadeia)
            {
                Console.WriteLine($"Estado: {estado}, lendo: '{simbolo}'");
                estado = transicoes[(estado, simbolo)];
            }

            Console.WriteLine($"Estado final: {estado}");
            Console.WriteLine(finais.Contains(estado) ? "Aceita." : "Rejeitada.");
        }
    }
}
