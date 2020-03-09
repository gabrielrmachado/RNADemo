﻿using System;
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
    public partial class frmTeste : Form
    {
        private MLP _redeNeural;
        private double[] _amostraTeste;
        private TextBox maiorTextBox;

        public frmTeste(MLP redeNeural)
        {
            InitializeComponent();
            _redeNeural = redeNeural;
            
            lblNumÉpocas.Text = _redeNeural.NumEpocas.ToString();
            lblTaxaAprendizado.Text = _redeNeural.TaxaAprendizado.ToString();
            lblTaxaMomento.Text = _redeNeural.TaxaMomento.ToString();
            lblAlgoritmoOtimizacao.Text = _redeNeural.getNomeAlgoritmoOtimizacao();
            lblTopologia.Text = _redeNeural.getTopologiaRedeNeural();

            _amostraTeste = new double[20];
            btnNovaAmostra.Enabled = false;

            foreach (PictureBox pixel in grpAmostra.Controls)
            {
                pixel.Click += Utils.MudarCorPixel;
            }
        }

        private void btnAvaliar_Click(object sender, EventArgs e)
        {
            int i = 0;
            btnNovaAmostra.Enabled = true;
            btnAvaliar.Enabled = false;

            foreach (PictureBox pb in grpAmostra.Controls)
            {
                _amostraTeste[i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
                i++;
            }

            var predicoes = _redeNeural.AvaliarAmostra(_amostraTeste);
            var maxChave = predicoes.FirstOrDefault(x => x.Value == predicoes.Values.Max()).Key;
            
            i = 0;
            foreach (var textBox in grpSaidaProcessadores.Controls.OfType<TextBox>().OrderBy(x => x.Name))
            {
                textBox.Text = string.Format("{0:0.00000}", predicoes[i]);

                if (i == maxChave)
                {
                    textBox.ForeColor = Color.Red;
                    maiorTextBox = textBox;
                }
                i++;
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaAmostra_Click(object sender, EventArgs e)
        {
            grpAmostra.LimparGrid();
            maiorTextBox.ForeColor = Color.Blue;
            btnAvaliar.Enabled = true;
            
            foreach (TextBox textBox in grpSaidaProcessadores.Controls.OfType<TextBox>())
                textBox.Text = "";
        }
    }
}
