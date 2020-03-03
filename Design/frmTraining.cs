using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNADemo.Business;

namespace RNADemo
{
    public partial class frmTraining : Form
    {
        private MLP _redeNeural;

        public frmTraining(MLP neuralNet)
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
                _redeNeural.AmostrasTreinamento[numPadroesFornecidos-1, i] = pb.BackColor == Color.White ? 0 : 1;
            }

            _redeNeural.AmostrasTreinamento[numPadroesFornecidos - 1, 20] = int.Parse(txtAmostraEnsinada.Text);

            LimparControles();            

            if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
            {
                btnAssociar.Enabled = false;
                btnProsseguirTeste.Enabled = true;
            }

            txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
            txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
        }
    }
}
