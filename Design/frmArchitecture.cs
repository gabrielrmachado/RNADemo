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
    public partial class frmArchitecture : Form
    {
        private MLP redeNeural;
        public frmArchitecture()
        {
            redeNeural = new MLP();
            InitializeComponent();
            cmbNumCamadas.Items.AddRange(new object[] { 1, 2, 3, 4 });
            cmbNumCamadas.SelectedIndex = 0;
        }

        private void MensagemErro(TextBox txtComponente)
        {
            try
            {
                if (Convert.ToInt16(txtComponente.Text) < 1 || Convert.ToInt16(txtComponente.Text) > 50)
                {
                    MessageBox.Show("Escolha um número de processadores entre 1 e 50.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComponente.Focus();
                    txtComponente.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Escolha um número de processadores entre 1 e 50.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComponente.Focus();
                txtComponente.SelectAll();
            }            
        }

        private void cmbNumCamadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            redeNeural.NumCamadasEscondidas = Convert.ToInt16(cmbNumCamadas.SelectedItem);
            switch (redeNeural.NumCamadasEscondidas)
            {
                case 1:
                    txtCamada2.Enabled = false;
                    txtCamada3.Enabled = false;
                    txtCamada4.Enabled = false;
                    break;
                case 2:
                    txtCamada2.Enabled = true;
                    txtCamada3.Enabled = false;
                    txtCamada4.Enabled = false;
                    break;
                case 3:
                    txtCamada2.Enabled = true;
                    txtCamada3.Enabled = true;
                    txtCamada4.Enabled = false;
                    break;
                case 4:
                    txtCamada2.Enabled = true;
                    txtCamada3.Enabled = true;
                    txtCamada4.Enabled = true;
                    break;
            }
        }

        private void txtCamada2_Leave(object sender, EventArgs e)
        {
            MensagemErro(txtCamada2);
        }

        private void txtCamada3_Leave(object sender, EventArgs e)
        {
            MensagemErro(txtCamada3);
        }

        private void txtCamada4_Leave(object sender, EventArgs e)
        {
            MensagemErro(txtCamada4);
        }

        private void txtCamada1_Leave(object sender, EventArgs e)
        {
            MensagemErro(txtCamada1);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (txtCamada1.Enabled) redeNeural[0] = short.Parse(txtCamada1.Text);
            if (txtCamada2.Enabled) redeNeural[1] = short.Parse(txtCamada2.Text);
            if (txtCamada3.Enabled) redeNeural[2] = short.Parse(txtCamada3.Text);
            if (txtCamada4.Enabled) redeNeural[3] = short.Parse(txtCamada4.Text);

            this.Hide();
            new frmTraining(redeNeural).ShowDialog();            
            this.Close();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {

        }
    }
}
