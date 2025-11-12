using System;

namespace AV2
{
    internal static class Item3_Reconhecedor
    {
        public static void Executar()
        {
            Console.WriteLine("Linguagem: L = { aⁱbⁱ | i ≥ 0 }");
            Console.Write("Digite uma cadeia sobre {a,b}: ");
            string? cadeia = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia. Reconhecida (ε ∈ L).");
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

            Console.Write("Limite de passos (ex: 1000): ");
            if (!int.TryParse(Console.ReadLine(), out int limite) || limite <= 0)
            {
                Console.WriteLine("Valor inválido. Usando limite padrão = 1000.");
                limite = 1000;
            }

            Reconhecer(cadeia, limite);
        }

        private static void Reconhecer(string cadeia, int limite)
        {
            string fita = cadeia;
            int passos = 0;

            while (fita.Contains('a'))
            {
                fita = fita.Remove(fita.IndexOf('a'), 1);

                if (fita.Contains('b'))
                    fita = fita.Remove(fita.IndexOf('b'), 1);
                else
                {
                    Console.WriteLine("Rejeitada — há mais 'a' que 'b'.");
                    return;
                }

                passos++;
                if (passos >= limite)
                {
                    Console.WriteLine($"Execução interrompida após {limite} passos (possível não terminação).");
                    return;
                }
            }

            Console.WriteLine(fita.Contains('b') ? "Rejeitada — há mais 'b' que 'a'." : "Aceita.");
        }
    }
}
