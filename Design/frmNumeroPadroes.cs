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
        private bool _carregouAmostras;

        public frmNumeroPadroes(MLP network)
        {
            InitializeComponent();
            _redeNeural = network;
            _carregouAmostras = false;
        }

        private void txtNumPadroes_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).MensagemErro(1);
        }

        private void btnProsseguirPadroes_Click(object sender, EventArgs e)
        {
            _redeNeural.NumeroAmostrasTreinamento = short.Parse(txtNumPadroes.Text);
            
            if (!_carregouAmostras) 
                _redeNeural.ConstruirRede();

            this.Hide();
            new frmTraining(_redeNeural, _carregouAmostras).ShowDialog();
            this.Close();
        }

        private void btnCarregarPadroes_Click(object sender, EventArgs e)
        {
            try
            {
                _redeNeural.NumeroAmostrasTreinamento = short.Parse(txtNumPadroes.Text);
                _redeNeural.ConstruirRede();
                _redeNeural.CarregarAmostras();
                _carregouAmostras = true;

                MessageBox.Show("Amostras carregadas com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                new frmTraining(_redeNeural, _carregouAmostras).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao carregar as amostras: {0}.\nPilha de Chamadas: {1}", ex.Message, ex.StackTrace), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
