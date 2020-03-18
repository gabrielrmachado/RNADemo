using RNADemo.Business;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RNADemo.Design
{
    public partial class frmTreinamento : Form
    {
        private MLP _redeNeural;
        private int indiceAmostraAssociada;

        public frmTreinamento(MLP neuralNet, bool carregouAmostras)
        {
            InitializeComponent();
            _redeNeural = neuralNet;
            this.FormClosing += Utils.FecharFormulario;

            txtQtdAmostrasRestantes.Text = _redeNeural.NumeroAmostrasTreinamento.ToString();
            txtQtdAmostrasFornecidas.Text = "0";

            foreach (PictureBox pixel in grpAmostra.Controls.OfType<PictureBox>())
            {
                pixel.Click += Utils.MudarCorPixel;
            }

            foreach (RadioButton radio in grpClasses.Controls.OfType<RadioButton>())
            {
                radio.Click += Radio_Click;
            }

            if (carregouAmostras)
            {
                txtQtdAmostrasFornecidas.Text = _redeNeural.AmostrasTreinamento.RowCount.ToString();
                txtQtdAmostrasRestantes.Text = "0";
                btnTreinarRede.Enabled = true;
                indiceAmostraAssociada = 0;

                btnUltimo.Enabled = true;
                btnProximo.Enabled = true;

                AtualizarControlesClasses();
            }
        }

        private void AtualizarControlesClasses()
        {
            grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
            lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, int.Parse(txtQtdAmostrasFornecidas.Text));
            grpClasses.AtualizaClasses(_redeNeural.ClassesTreinamento, (int)_redeNeural.ClassesTreinamento[indiceAmostraAssociada]);
            txtAmostraEnsinada.Text = ((int)_redeNeural.ClassesTreinamento[indiceAmostraAssociada]).ToString();
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            int numPadroesFornecidos = int.Parse(txtQtdAmostrasFornecidas.Text) + 1;
            int numPadroesRestantes = int.Parse(txtQtdAmostrasRestantes.Text) - 1;

            int i = 0;
            foreach (var pb in grpAmostra.Controls.OfType<PictureBox>().OrderBy((x) => x.Name))
            {
                _redeNeural.AmostrasTreinamento[numPadroesFornecidos - 1, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
                i++;
            }

            _redeNeural.ClassesTreinamento[numPadroesFornecidos - 1] = double.Parse(txtAmostraEnsinada.Text);

            if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
            {
                btnAssociar.Enabled = false;
                btnTreinarRede.Enabled = true;
                btnSalvarAmostras.Enabled = true;
            }
            var label = grpClasses.Controls.Find("lblCnt" + txtAmostraEnsinada.Text.Trim(), true)[0];
            label.Text = (int.Parse(label.Text) + 1).ToString();

            txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
            txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
            grpAmostra.LimparGrid();
            rb0.Checked = true;
            txtAmostraEnsinada.Text = "0";
        }

        private void btnTreinarRede_Click(object sender, EventArgs e)
        {
            btnProsseguirTeste.Enabled = true;
            try
            {
                _redeNeural.TreinarRede();
                MessageBox.Show("Rede treinada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao treinar a rede neural: {0}", ex.Message), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarAmostras_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Selecione um local para salvamento:";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string sSelectedPath = fbd.SelectedPath;
                    _redeNeural.SalvarAmostras(sSelectedPath);
                    MessageBox.Show("Amostras salvas com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao salvar as amostras: {0}", ex.Message), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProsseguirTeste_Click(object sender, EventArgs e)
        {
            new frmTeste(_redeNeural).Show();
            this.Hide();
        }


        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            btnPrimeiro.Enabled = false;
            btnAnterior.Enabled = false;

            indiceAmostraAssociada = 0;
            AtualizarControlesClasses();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            
            indiceAmostraAssociada--;
            if (indiceAmostraAssociada == 0)
            {
                btnAnterior.Enabled = false;
                btnPrimeiro.Enabled = false;
            }

            AtualizarControlesClasses();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;

            indiceAmostraAssociada++;
            if (indiceAmostraAssociada == _redeNeural.AmostrasTreinamento.RowCount-1)
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
            }

            AtualizarControlesClasses();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;

            indiceAmostraAssociada = _redeNeural.AmostrasTreinamento.RowCount - 1;
            AtualizarControlesClasses();
        }
    }
}
