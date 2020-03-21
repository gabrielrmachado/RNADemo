using SharpLearning.Containers.Matrices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNADemo.Business
{
    public static class Utils
    {
        public static void AlterarLabelNavegacaoAmostras(this Label labelCntAmostras, int padraoAtual, int totalPadroes)
        {
            if (labelCntAmostras.Name == "lblCntPadrao")
            {
                var formato = string.Format("{0}/{1}", padraoAtual, totalPadroes);
                labelCntAmostras.Text = formato;
            }
            else
            {
                throw new Exception("Esta funcionalidade muda apenas o label 'lblCntPadrao', que realiza de contagem de amostras do formulário de treinamento.");
            }
        }

        public static void MensagemErro(this TextBox txtComponente, double menor)
        {
            var sMenor = string.Format("{0:0.000}", menor);

            if (sMenor.EndsWith("000"))
                sMenor = ((int)menor).ToString();

            try
            {
                if (Convert.ToDouble(txtComponente.Text) < menor)
                {
                    MessageBox.Show(string.Format("Escolha um valor para o parâmetro maior ou igual a {0}.", sMenor), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComponente.Focus();
                    txtComponente.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Escolha um valor para o parâmetro maior ou igual a {0}.", sMenor), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComponente.Focus();
                txtComponente.SelectAll();
            }
        }
        public static void MensagemErro(this TextBox txtComponente, double menor, double maior)
        {
            var sMenor = string.Format("{0:0.000}", menor);
            var sMaior = string.Format("{0:0.000}", maior);

            if (sMenor.EndsWith("000"))
                sMenor = ((int)menor).ToString();

            if (sMaior.EndsWith("000"))
                sMaior = ((int)maior).ToString();

            try
            {
                if (Convert.ToDouble(txtComponente.Text) < menor || Convert.ToDouble(txtComponente.Text) > maior)
                {
                    MessageBox.Show(string.Format("Escolha um valor para o parâmetro entre {0} e {1}.", sMenor, sMaior), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComponente.Focus();
                    txtComponente.SelectAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Escolha um valor para o parâmetro entre {0} e {1}.", sMenor, sMaior), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComponente.Focus();
                txtComponente.SelectAll();
            }
        }

        public static void FecharFormulario(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Deseja realmente fechar o RNADemo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        public static void LimparGrid(this GroupBox groupBox)
        {
            foreach (PictureBox pixel in groupBox.Controls.OfType<PictureBox>())
                pixel.BackColor = Color.White;
        }

        public static void PreencherGrid(this GroupBox groupBox, double[] amostras)
        {
            if (groupBox.Name == "grpAmostra")
            {
                int i = 0;
                foreach (var pb in groupBox.Controls.OfType<PictureBox>().OrderBy(x => x.Name))
                {
                    pb.BackColor = (amostras[i] == 0.0 ? Color.White : pb.BackColor = Color.Black);
                    i++;
                }
            }
            else throw new Exception("Esta funcionalidade é destinada apenas para o GroupBox 'grpAmostra', responsável por exibir as amostras de treinamento.");

        }

        public static void MudarCorPixel(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;

            if (pb.BackColor == Color.Black)
                pb.BackColor = Color.White;
            else
                pb.BackColor = Color.Black;
        }

        public static void AtualizarContadorAmostrasPorClasse(this GroupBox groupBox, string amostraEnsinada, bool inc)
        {
            var label = groupBox.Controls.Find("lblCnt" + amostraEnsinada.Trim(), true)[0];

            if (inc) 
                label.Text = (int.Parse(label.Text) + 1).ToString();
            else 
                label.Text = (int.Parse(label.Text) - 1).ToString();
        }

        public static void DesmarcarSelecaoRadioButtonsClasses(this GroupBox grp)
        {
            foreach (var rb in grp.Controls.OfType<RadioButton>())
                rb.Checked = false;
        }

        public static void AtualizarContadorAmostrasPorClasse(this GroupBox groupBox, double[] classesTreinamento)
        {
            foreach (var lbl in groupBox.Controls.OfType<Label>())
                lbl.Text = "0";

            var query = classesTreinamento.GroupBy(x => x).Where(g => g.Count() >= 0)
                    .Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();

            foreach (var item in query)
            {
                if (item.Element != -1)
                {
                    groupBox.Controls.Find("lblCnt" + item.Element.ToString(), true)[0].Text = item.Counter.ToString();
                }
            }                
        }
    }
}
