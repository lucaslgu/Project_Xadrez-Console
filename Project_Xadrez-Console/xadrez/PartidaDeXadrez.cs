using System;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; set; }
        public PartidaDeXadrez(Cor jogadorAtual, Cor corJogador1)
        {
            if(jogadorAtual != corJogador1)
            {
                throw new TabuleiroException("A cor digita não existe na partida atual");
            }
            tab = new Tabuleiro(8, 8);
            turno = 1;
            this.jogadorAtual = jogadorAtual;
            terminada = false;
            colocarPecas(corJogador1);
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas(Cor corJogador1)
        {
            tab.colocarPeca(new Rei(tab, corJogador1), new PosicaoXadrez('c', 1).toPosicao());
         
        }
    }
}
