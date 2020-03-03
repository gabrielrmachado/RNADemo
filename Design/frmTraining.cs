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
            grpClasses.MouseClick += GrpClasses_MouseClick;

            foreach (PictureBox pixel in grpAmostra.Controls)
            {
                pixel.Click += Pixel_Click; 
            }
        }

        private void Pixel_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void GrpClasses_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                RadioButton rdButton = grpClasses.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
            }
            catch
            {
                txtAmostraEnsinada.Text = "0";
            }
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
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {

        }
    }
}
