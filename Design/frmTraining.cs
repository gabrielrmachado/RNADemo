using RNADemo.Business;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RNADemo
{
    public partial class frmTraining : Form
    {
        private MLP _redeNeural;

        public frmTraining(MLP neuralNet, bool carregouAmostras)
        {
            InitializeComponent();
            _redeNeural = neuralNet;

            txtQtdAmostrasRestantes.Text = _redeNeural.NumeroAmostrasTreinamento.ToString();
            txtQtdAmostrasFornecidas.Text = "0";

            foreach (PictureBox pixel in grpAmostra.Controls)
            {
                pixel.Click += Pixel_Click;
            }

            foreach (RadioButton radio in grpClasses.Controls)
            {
                radio.Click += Radio_Click;
            }

            if (carregouAmostras)
            {
                txtQtdAmostrasFornecidas.Text = _redeNeural.AmostrasTreinamento.RowCount.ToString();
                txtQtdAmostrasRestantes.Text = "0";
                btnTreinarRede.Enabled = true;
                btnAssociar.Enabled = false;
            } 
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
        }

        private void Pixel_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void ChangeColor(object sender)
        {
            var pb = (PictureBox)sender;

            if (pb.BackColor == Color.Black)
                pb.BackColor = Color.White;
            else
                pb.BackColor = Color.Black;
        }

        private void LimparControles()
        {
            foreach (PictureBox pixel in grpAmostra.Controls)
                pixel.BackColor = Color.White;

            radioButton1.Checked = true;
            txtAmostraEnsinada.Text = "0";
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            int numPadroesFornecidos = int.Parse(txtQtdAmostrasFornecidas.Text) + 1;
            int numPadroesRestantes = int.Parse(txtQtdAmostrasRestantes.Text) - 1;

            for (int i = 0; i < grpAmostra.Controls.Count; i++)
            {
                PictureBox pb = grpAmostra.Controls[i] as PictureBox;
                _redeNeural.AmostrasTreinamento[numPadroesFornecidos - 1, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
            }

            _redeNeural.ClassesTreinamento[numPadroesFornecidos - 1] = double.Parse(txtAmostraEnsinada.Text);

            LimparControles();

            if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
            {
                btnAssociar.Enabled = false;
                btnTreinarRede.Enabled = true;
                btnSalvarAmostras.Enabled = true;
            }

            txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
            txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
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
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao treinar a rede neural: {0}\nPilha de Chamadas: {1}", ex.Message, ex.StackTrace), "Erro",
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
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao salvar as amostras: {0}\nPilha de Chamadas: {1}", ex.Message, ex.StackTrace), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
