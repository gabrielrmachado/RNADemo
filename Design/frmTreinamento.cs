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
        private bool _editar;

        public frmTreinamento(MLP neuralNet, bool carregouAmostras)
        {
            InitializeComponent();
            _redeNeural = neuralNet;
            this.FormClosing += Utils.FecharFormulario;

            numPadroesRestantes = _redeNeural.NumeroAmostrasTreinamento;
            txtQtdAmostrasRestantes.Text = _redeNeural.NumeroAmostrasTreinamento.ToString();
            txtQtdAmostrasFornecidas.Text = "0";
            _editar = false;

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
                numPadroesFornecidos = _redeNeural.NumeroAmostrasTreinamento;
                numPadroesRestantes = 0;

                txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
                txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();

                btnTreinarRede.Enabled = true;
                btnUltimo.Enabled = true;
                btnProximo.Enabled = true;
                _editar = true;

                indiceAmostraAssociada = 0;
            }
            AtualizarControlesClasses();
        }

        private void AtualizarControlesClasses()
        {
            try
            {
                grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
                lblCntPadrao.AlterarLabelNavegacaoAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
                grpClasses.AtualizarContadorAmostrasPorClasse(_redeNeural.ClassesTreinamento);
                var rdButton = grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]);
                txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
                rdButton.Checked = true;
            }
            catch (InvalidOperationException)
            {
                grpClasses.DesmarcarSelecaoRadioButtonsClasses();
                txtAmostraEnsinada.Text = "";
            }
            catch (IndexOutOfRangeException)
            {
                RealizarCliqueBtnUltimo();
            }
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            if (!_editar)
            {
                numPadroesFornecidos++;
                numPadroesRestantes--;
                txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
                txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
            }

            int i = 0;
            foreach (var pb in grpAmostra.Controls.OfType<PictureBox>().OrderBy((x) => x.Name))
            {
                _redeNeural.AmostrasTreinamento[indiceAmostraAssociada, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
                i++;
            }

            try
            {
                _redeNeural.ClassesTreinamento[indiceAmostraAssociada] = double.Parse(txtAmostraEnsinada.Text);
                lblCntPadrao.AlterarLabelNavegacaoAmostras(++indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
                grpClasses.AtualizarContadorAmostrasPorClasse(_redeNeural.ClassesTreinamento);

                btnAnterior.Enabled = true;
                btnPrimeiro.Enabled = true;

                if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
                {
                    btnSalvarAmostras.Enabled = true;
                    btnTreinarRede.Enabled = true;
                    _editar = true;
                }
                else
                {
                    txtAmostraEnsinada.Text = "";
                    grpClasses.DesmarcarSelecaoRadioButtonsClasses();
                }
                RealizarCliqueBtnUltimo();
            }
            catch (FormatException)
            {
                MessageBox.Show("Atribua uma classe para a amostra!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPadroesFornecidos--;
                numPadroesRestantes++;
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
            _editar = true;

            indiceAmostraAssociada = 0;
            AtualizarControlesClasses();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            _editar = true;

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
            if (indiceAmostraAssociada == numPadroesFornecidos)
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
                _editar = true;
            }
            AtualizarControlesClasses();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            RealizarCliqueBtnUltimo();
        }

        private void RealizarCliqueBtnUltimo()
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;

            if (numPadroesRestantes > 0)
            {
                indiceAmostraAssociada = numPadroesFornecidos;
                _editar = false;
            }
            else
            {
                indiceAmostraAssociada = numPadroesFornecidos - 1;
                _editar = true;
            }
            AtualizarControlesClasses();
        }
    }
}