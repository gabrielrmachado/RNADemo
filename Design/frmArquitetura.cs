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
    public partial class frmArquitetura : Form
    {
        private MLP _redeNeural;
        public frmArquitetura()
        {
            InitializeComponent();
            cmbNumCamadas.Items.AddRange(new object[] { 1, 2, 3, 4 });
            cmbOtimizacao.Items.AddRange(new object[] { "SGD", "Adam", "AdaMax", "Nadam", "Adagrad", "Adadelta", "Netsterov", "RMSProp" });
            cmbNumCamadas.SelectedIndex = 0;
            cmbOtimizacao.SelectedIndex = 0;

            _redeNeural = new MLP();
        }

        private void cmbNumCamadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numCamadasEscondidas = Convert.ToInt16(cmbNumCamadas.SelectedItem);
            switch (numCamadasEscondidas)
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
            (sender as TextBox).MensagemErro(1, 50);
        }

        private void txtCamada3_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(1, 50);
        }

        private void txtCamada4_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(1, 50);
        }

        private void txtCamada1_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(1, 50);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            _redeNeural.NumCamadasEscondidas = Convert.ToInt16(cmbNumCamadas.SelectedItem);

            if (txtCamada1.Enabled) _redeNeural[0] = short.Parse(txtCamada1.Text);
            if (txtCamada2.Enabled) _redeNeural[1] = short.Parse(txtCamada2.Text);
            if (txtCamada3.Enabled) _redeNeural[2] = short.Parse(txtCamada3.Text);
            if (txtCamada4.Enabled) _redeNeural[3] = short.Parse(txtCamada4.Text);

            _redeNeural.NumEpocas = short.Parse(txtEpocas.Text);
            _redeNeural.TaxaAprendizado = double.Parse(txtAprendizado.Text);
            _redeNeural.TaxaMomento = double.Parse(txtMomento.Text);
            _redeNeural.AlgoritmoOtimizador = short.Parse(cmbOtimizacao.SelectedIndex.ToString());

            this.Hide();
            new frmNumeroPadroes(_redeNeural).ShowDialog();            
            this.Close();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "XML Files (*.xml)|*.xml";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;



            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string arrAllFile = choofdlog.FileName; 
                _redeNeural.Modelo = _redeNeural.CarregarRede(arrAllFile);
            }

            MessageBox.Show("Rede carregada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            new frmTeste(_redeNeural).ShowDialog();
            this.Close();
        }

        private void txtEpocas_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(10, 1000);
        }

        private void txtAprendizado_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(0.001, 0.5);
        }

        private void txtMomento_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(0.1, 1);
        }
    }
}
