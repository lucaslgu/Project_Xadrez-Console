using System;
using tabuleiro;
using xadrez;

namespace Project_Xadrez_Console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  A B C D E F G H ");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                switch (peca.cor)
                {
                    case Cor.Branco:
                        Console.Write(peca);
                        break;
                    case Cor.Amarelo:
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    case Cor.Azul:
                        aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    case Cor.Verde:
                        aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    case Cor.Laranja:
                        aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    case Cor.Vermelho:
                        aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    case Cor.Magenta:
                        aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(peca);
                        Console.ForegroundColor = aux;
                        break;
                    default:
                        Console.Write(peca);
                        break;
                }
                Console.Write(" ");
            }
        }
    }
}
