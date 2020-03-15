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
            this.FormClosing += Utils.FecharFormulario;
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

            new frmTreinamento(_redeNeural, _carregouAmostras).Show();
            this.Hide();
        }

        private void btnCarregarPadroes_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "CSV Files (*.csv)|*.csv";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = true;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    string[] arrAllFiles = choofdlog.FileNames; 
                    _redeNeural.CarregarAmostras(arrAllFiles);
                    _carregouAmostras = true;

                    _redeNeural.ConstruirRede();

                    MessageBox.Show(string.Format("{0} amostras carregadas com sucesso!", _redeNeural.NumeroAmostrasTreinamento),
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new frmTreinamento(_redeNeural, _carregouAmostras).ShowDialog();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao carregar as amostras: {0}", ex.Message), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
