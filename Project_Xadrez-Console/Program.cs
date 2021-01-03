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
                Console.Write("Digite a cor do jogador que vai começa primeiro: ");
                Cor corJogadorInicio = Enum.Parse<Cor>(Console.ReadLine());
                PartidaDeXadrez partida = new PartidaDeXadrez(corJogadorInicio, corJogador1);

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
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
