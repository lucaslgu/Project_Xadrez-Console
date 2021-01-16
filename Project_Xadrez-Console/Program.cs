using System;
using System.Linq;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var cores = Enum.GetValues(typeof(Cor)).Cast<Cor>();
            int menu = 100;
            Cor jogador1;
            Cor jogador2;

            Console.WriteLine("---  Seja bem vindo ao XADREZ ONLINE  ---");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|               Iniciar partida                 |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|                   Sair                        |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("| Digite 0 para sair e 1 para iniciar a partida |");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("> ");
            menu = int.Parse(Console.ReadLine());

            while (menu != 0)
            {
                try
                {
                    Console.WriteLine();
                    if (menu == 1)
                    {
                        Console.WriteLine("Selecione uma das cores abaixo:");
                        Console.WriteLine();

                        foreach (Cor c in cores)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine($"|   Cor: {c}");
                            Console.WriteLine("------------------------");
                        }
                        Console.WriteLine();
                        Console.Write("Digite a cor para o primeiro jogador: ");
                        jogador1 = Enum.Parse<Cor>(Console.ReadLine());

                        foreach (Cor c in cores)
                        {
                            if (c != jogador1)
                            {
                                Console.WriteLine("------------------------");
                                Console.WriteLine($"|   Cor: {c}");
                                Console.WriteLine("------------------------");
                            }
                        }
                        Console.WriteLine();
                        Console.Write("Digite a cor para o segundo jogador: ");
                        jogador2 = Enum.Parse<Cor>(Console.ReadLine());

                        try
                        {
                            PartidaDeXadrez partida = new PartidaDeXadrez(jogador1, jogador2);

                            while (!partida.terminada)
                            {

                                try
                                {
                                    Console.Clear();
                                    Tela.imprimirPartida(partida, jogador1, jogador2);

                                    Console.WriteLine();
                                    Console.Write("Origem: ");
                                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                                    partida.validarPosicaoDeOrigem(origem);

                                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                                    Console.Clear();
                                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                                    Console.WriteLine();
                                    Console.Write("Destino: ");
                                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                                    partida.validarPosicaoDeDestino(origem, destino);

                                    partida.realizaJogada(origem, destino);
                                }
                                catch (TabuleiroException e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.ReadLine();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Erro inexperado: " + e.Message);
                                    Console.WriteLine("Pressione enter para continuar...");
                                    Console.ReadLine();
                                }
                            }
                            Console.Clear();
                            Tela.imprimirPartida(partida, jogador1, jogador2);
                        }
                        catch (TabuleiroException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro inexperado: " + e.Message);
                }

                Console.ReadLine();
            }
        }
    }
}
