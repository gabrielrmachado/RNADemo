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
            MessageBox.Show(string.Format("{0}\n{1}\n{2}\n{3}", _redeNeural[0], _redeNeural[1], _redeNeural[2], _redeNeural[3]));
        }

        private void ChangeColor(object sender)
        {
            var pb = (PictureBox)sender;

            if (pb.BackColor == Color.Black)
                pb.BackColor = Color.White;
            else
                pb.BackColor = Color.Black;
        }

        private void pb11_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb19_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb18_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb17_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb16_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb15_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb14_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb13_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb12_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb20_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb10_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb9_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb8_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb7_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb6_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }

        private void pb5_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }
    }
}
