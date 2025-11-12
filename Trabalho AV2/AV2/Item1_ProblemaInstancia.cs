using System;
using System.Collections.Generic;
using System.Text.Json;

namespace AV2
{
    internal static class Item1_ProblemaInstancia
    {
        private class Frase
        {
            public string Texto { get; set; } = string.Empty;
            public string Tipo { get; set; } = string.Empty;
        }

        public static void Executar()
        {
            Console.WriteLine("Classificação: Problema (P) ou Instância (I)");
            Console.WriteLine("--------------------------------------------");

            List<Frase>? frases = JsonSerializer.Deserialize<List<Frase>>(ObterJson());

            if (frases == null || frases.Count == 0)
            {
                Console.WriteLine("Erro: Nenhum item encontrado no JSON.");
                return;
            }

            int acertos = 0;
            int erros = 0;

            foreach (Frase f in frases)
            {
                Console.WriteLine($"\nFrase: {f.Texto}");
                Console.Write("Digite P ou I: ");

                string? resposta = Console.ReadLine()?.Trim().ToUpper();

                while (resposta != "P" && resposta != "I")
                {
                    Console.Write("Entrada inválida. Use apenas P ou I: ");
                    resposta = Console.ReadLine()?.Trim().ToUpper();
                }

                if (resposta == f.Tipo.ToUpper())
                {
                    Console.WriteLine("✔ Correto!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"✖ Errado. Resposta correta: {f.Tipo}");
                    erros++;
                }
            }

            Console.WriteLine($"\nResultado final: {acertos} acertos e {erros} erros.");
        }

        private static string ObterJson()
        {
            return """
            [
                {"Texto": "Determinar se um número é primo", "Tipo": "P"},
                {"Texto": "Número 17", "Tipo": "I"},
                {"Texto": "Verificar se uma palavra termina com 'b'", "Tipo": "P"},
                {"Texto": "Cadeia 'aabb'", "Tipo": "I"}
            ]
            """;
        }
    }
}
