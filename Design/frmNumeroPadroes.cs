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

namespace RNADemo.Design
{
    public partial class frmNumeroPadroes : Form
    {
        private MLP _redeNeural;
        public frmNumeroPadroes(MLP network)
        {
            InitializeComponent();
            _redeNeural = network;
        }

        private void txtNumPadroes_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(1, 1000);
        }

        private void btnProsseguirPadroes_Click(object sender, EventArgs e)
        {
            _redeNeural.NumeroAmostrasTreinamento = short.Parse(txtNumPadroes.Text);
            this.Hide();
            new frmTraining(_redeNeural).ShowDialog();
            this.Close();
        }
    }
}
