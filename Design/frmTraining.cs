using RNADemo.Business;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RNADemo
{
    public partial class frmTraining : Form
    {
        private MLP redeNeural;

        public frmTraining(MLP neuralNet)
        {
            InitializeComponent();
            redeNeural = neuralNet;
            txtQtdAmostrasRestantes.Text = redeNeural.NumeroAmostrasTreinamento.ToString();
            txtQtdAmostrasFornecidas.Text = "0";

            foreach (PictureBox pixel in grpAmostra.Controls)
            {
                pixel.Click += Pixel_Click;
            }

            foreach (RadioButton radio in grpClasses.Controls)
            {
                radio.Click += Radio_Click;
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
                redeNeural.AmostrasTreinamento[numPadroesFornecidos - 1, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
            }

            redeNeural.ClassesTreinamento[numPadroesFornecidos - 1] = double.Parse(txtAmostraEnsinada.Text);

            LimparControles();

            if (numPadroesFornecidos == redeNeural.NumeroAmostrasTreinamento)
            {
                btnAssociar.Enabled = false;
                btnTreinarRede.Enabled = true;
            }

            txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
            txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
        }

        private void btnTreinarRede_Click(object sender, EventArgs e)
        {
            btnCarregasAmostras.Enabled = false;
            btnProsseguirTeste.Enabled = true;
            redeNeural.TreinarRede();
        }

        private void btnSalvarAmostras_Click(object sender, EventArgs e)
        {
            redeNeural.SalvarAmostras();
        }       

        private void btnCarregarAmostras_Click(object sender, EventArgs e)
        {

        }
    }
}
