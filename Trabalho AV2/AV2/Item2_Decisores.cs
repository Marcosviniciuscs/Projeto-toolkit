using System;

namespace AV2
{
    internal static class Item2_Decisores
    {
        public static void Executar()
        {
            Console.WriteLine("1 - L_fim_b = { w in {a,b}* | w termina com 'b' }");
            Console.WriteLine("2 - L_mult3_b = { w in {a,b}* | número de 'b' é múltiplo de 3 }");
            Console.Write("Escolha o decisor: ");

            string? escolha = Console.ReadLine();

            Console.Write("Digite uma cadeia sobre {a,b}: ");
            string? cadeia = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("Cadeia vazia. Nada a decidir.");
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

            if (escolha == "1")
                DecidirFimB(cadeia);
            else if (escolha == "2")
                DecidirMult3B(cadeia);
            else
                Console.WriteLine("Opção inválida.");
        }

        private static void DecidirFimB(string cadeia)
        {
            bool aceita = cadeia.EndsWith('b');
            Console.WriteLine(aceita ? "SIM — termina com 'b'." : "NÃO — não termina com 'b'.");
        }

        private static void DecidirMult3B(string cadeia)
        {
            int qtdB = 0;
            foreach (char c in cadeia)
                if (c == 'b') qtdB++;

            bool aceita = (qtdB % 3 == 0);
            Console.WriteLine(aceita ? "SIM — número de 'b' é múltiplo de 3." : "NÃO — número de 'b' não é múltiplo de 3.");
        }
    }
}
