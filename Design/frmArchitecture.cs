using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNADemo.Design
{
    public partial class frmArchitecture : Form
    {
        public frmArchitecture()
        {
            InitializeComponent();
            cmbNumCamadas.Items.AddRange(new object[] { 1, 2, 3, 4 });
            cmbNumCamadas.SelectedIndex = 0;
        }

        private void cmbNumCamadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            short numCamadas = Convert.ToInt16(cmbNumCamadas.SelectedItem);
            switch (numCamadas)
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
    }
}
