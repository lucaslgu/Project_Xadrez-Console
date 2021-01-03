using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Project_Xadrez_Console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida, Cor jogador1, Cor jogador2)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida, jogador1, jogador2);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida, Cor jogador1, Cor jogador2)
        {
            Console.WriteLine();
            Console.WriteLine("Peças capturadas:");
            Console.Write(jogador1 + ": ");
            ConsoleColor aux = Console.ForegroundColor;
            trocarCor(jogador1);
            imprimirConjunto(partida.pecasCapturadas(jogador1));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.Write(jogador2 + ": ");
            trocarCor(jogador2);
            imprimirConjunto(partida.pecasCapturadas(jogador2));
            Console.ForegroundColor = aux;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

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

        public static void trocarCor(Cor cor)
        {
            switch (cor)
            {
                case Cor.Amarelo:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Cor.Azul:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Cor.Verde:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Cor.Laranja:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Cor.Vermelho:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Cor.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    break;
            }
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                trocarCor(peca.cor);
                Console.Write(peca);
                Console.ForegroundColor = aux;
                Console.Write(" ");
            }
        }
    }
}
