namespace JogoTermo
{
    public partial class TermoTelaForms : Form
    {
        private Termo termo;
        Button botaoSelecionado;
        public TermoTelaForms()
        {
            InitializeComponent();
            termo = new Termo();
            termo.SortearPalavra();
            LiberarBlocos();
            botaoSelecionado = this.Controls.Find(termo.PrimeiroBotao(), true).FirstOrDefault() as Button;
            this.ActiveControl = null;
        }

        private void MouseClickLetra(object sender, MouseEventArgs e)
        {
            Button botaoClicado = (Button)sender;
            if (botaoSelecionado != null && termo.VerificarBotao(botaoSelecionado.Name, true))
            {
                botaoSelecionado.Text = botaoClicado.Text;
                PegarProximoBotao();
            }
            this.ActiveControl = null;
        }
        private void MouseClickEnter(object sender, MouseEventArgs e)
        {
            int posicao = 1;
            Button button = this.Controls.Find(termo.PrimeiroBotao(), true).FirstOrDefault() as Button;
            foreach (char letra in termo.ObterPalavraSorteada())
            {
                button.ForeColor = termo.VerificarExistencia(button.Text, posicao);
                posicao++;
                if (button.Name == termo.UltimoBotao())
                {
                    break;
                }
                button = button.Parent.Controls.OfType<Button>().FirstOrDefault(b => b.TabIndex == button.TabIndex + 1);
            }
            termo.IrParaProximaTentativa();
            if (termo.VerificarSeGanhou())
            {
                MessageBox.Show("Você ganhou!");
                BloquearBlocos();
                btnReiniciar.Visible = true;
            }
            else if (termo.TemProximaTentativa())
            {
                LiberarBlocos();
                botaoSelecionado = this.Controls.Find(termo.PrimeiroBotao(), true).FirstOrDefault() as Button;
            }
            else
            {
                btnReiniciar.Visible = true;
                MessageBox.Show($"Você perdeu! \n A palavra era: {termo.ObterPalavraSorteada()}");
            }
        }

        private void MouseClickButton(object sender, MouseEventArgs e)
        {
            botaoSelecionado = (Button)sender;
        }

        public void PegarProximoBotao()
        {
            if (termo.VerificarBotao(botaoSelecionado.Name))
            {
                botaoSelecionado = botaoSelecionado.Parent.Controls.OfType<Button>().FirstOrDefault(b => b.TabIndex == botaoSelecionado.TabIndex + 1);
            }
        }

        private void MouseClickReiniciar(object sender, MouseEventArgs e)
        {
            foreach (Control control in tlpBlocos.Controls)
            {
                if (control is Button)
                {
                    control.Text = "";
                    control.Enabled = false;
                    control.ForeColor = Color.Black;
                }
            }
            termo.SortearPalavra();
            this.botaoSelecionado = this.Controls.Find(termo.PrimeiroBotao(), true).FirstOrDefault() as Button;
            LiberarBlocos();
            btnReiniciar.Visible = false;
        }
        private void BloquearBlocos()
        {
            foreach (Control control in tlpBlocos.Controls)
            {
                if (control is Button)
                {
                    if (termo.VerificarBotao(control.Name, true))
                    {
                        control.Enabled = false;
                    }
                }
            }
        }
        private void LiberarBlocos()
        {
            foreach (Control control in tlpBlocos.Controls)
            {
                if (control is Button)
                {
                    if (termo.VerificarBotao(control.Name, true))
                    {
                        control.Enabled = true;
                    }
                }
            }
        }
    }
}