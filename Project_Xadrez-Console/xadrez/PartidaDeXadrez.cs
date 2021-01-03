using System;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        private Cor jogador1;
        private Cor jogador2;
        public bool terminada { get; set; }
        public PartidaDeXadrez(Cor jogadorAtual, Cor corJogador1, Cor corJogador2)
        {
            if (jogadorAtual != corJogador1 && jogadorAtual != corJogador2)
            {
                throw new TabuleiroException("A cor digita não existe na partida atual!");
            }
            if(corJogador1 == corJogador2)
            {
                throw new TabuleiroException("Não pode repetir a mesma cor!");
            }
            tab = new Tabuleiro(8, 8);
            turno = 1;
            this.jogadorAtual = jogadorAtual;
            terminada = false;
            jogador1 = corJogador1;
            jogador2 = corJogador2;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça selecionada não é sua");
            }
            if(!tab.peca(pos).existiMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça selecionada!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == jogador1)
            {
                jogadorAtual = jogador2;
            }
            else
            {
                jogadorAtual = jogador1;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, jogador1), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, jogador2), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Rei(tab, jogador2), new PosicaoXadrez('h', 5).toPosicao());
            tab.colocarPeca(new Rei(tab, jogador1), new PosicaoXadrez('h', 6).toPosicao());
        }
    }
}
