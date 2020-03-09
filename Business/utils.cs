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

        public static void LimparGrid(this GroupBox groupBox)
        {
            foreach (PictureBox pixel in groupBox.Controls)
                pixel.BackColor = Color.White;
        }

        public static void MudarCorPixel(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;

            if (pb.BackColor == Color.Black)
                pb.BackColor = Color.White;
            else
                pb.BackColor = Color.Black;
        }
    }
}
