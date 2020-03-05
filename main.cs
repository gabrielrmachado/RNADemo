using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNADemo.Design;

namespace RNADemo
{
    static class main
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

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmArchitecture());
        }
    }
}
