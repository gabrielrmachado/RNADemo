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
        private int indiceAmostraAssociada, numPadroesFornecidos, numPadroesRestantes;

        public frmTreinamento(MLP neuralNet, bool carregouAmostras)
        {
            InitializeComponent();
            _redeNeural = neuralNet;
            this.FormClosing += Utils.FecharFormulario;

            numPadroesRestantes = _redeNeural.NumeroAmostrasTreinamento;
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
                numPadroesFornecidos = _redeNeural.NumeroAmostrasTreinamento;
                
                btnTreinarRede.Enabled = true;
                btnUltimo.Enabled = true;
                btnProximo.Enabled = true;

                indiceAmostraAssociada = 0;
                grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
                grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]).Checked = true;

                txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
                txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
                lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
                grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);
            }
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            numPadroesFornecidos++;
            numPadroesRestantes--;

            int i = 0;
            foreach (var pb in grpAmostra.Controls.OfType<PictureBox>().OrderBy((x) => x.Name))
            {
                _redeNeural.AmostrasTreinamento[indiceAmostraAssociada, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
                i++;
            }

            _redeNeural.ClassesTreinamento[indiceAmostraAssociada] = double.Parse(txtAmostraEnsinada.Text);

            txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
            txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
            lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
            grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);

            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;

            if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
            {
                btnSalvarAmostras.Enabled = true;
                btnTreinarRede.Enabled = true;
            }
            else
            {
                indiceAmostraAssociada++;
                grpAmostra.LimparGrid();
            }
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
            grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
            grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);
            grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]).Checked = true;
            lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
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
            grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
            grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);
            grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]).Checked = true;
            lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;

            indiceAmostraAssociada++;
            if (indiceAmostraAssociada < numPadroesFornecidos)
            {
                grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
                grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);
                grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]).Checked = true;
                lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
            }
            else
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;

            indiceAmostraAssociada = numPadroesFornecidos - 1;
            grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
            grpClasses.AtualizarGroupBoxClasses(_redeNeural.ClassesTreinamento);
            grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]).Checked = true;
            lblCntPadrao.AlterarLabelCntAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
        }
    }
}
