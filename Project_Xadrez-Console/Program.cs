using System;
using tabuleiro;
using xadrez;

namespace Project_Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Digite a cor do primeiro jogador: ");
                Cor corJogador1 = Enum.Parse<Cor>(Console.ReadLine());
                Console.Write("Digite a cor do segundo jogador: ");
                Cor corJogador2 = Enum.Parse<Cor>(Console.ReadLine());
                
                Console.Write("Digite a cor do jogador que vai começa primeiro: ");
                Cor corJogadorInicio = Enum.Parse<Cor>(Console.ReadLine());

                PartidaDeXadrez partida = new PartidaDeXadrez(corJogadorInicio, corJogador1, corJogador2);
                
                while(!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida, corJogador1, corJogador2);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Erro: Valor não encontrado");
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
        }
    }
}
