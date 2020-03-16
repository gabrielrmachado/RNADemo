using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNADemo.Design;

namespace RNADemo
{
    static class main
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var splash = new frmSplash();
            splash.Show();
            Application.DoEvents();
            Thread.Sleep(5000);
            splash.Dispose();
            Application.Run(new frmArquitetura());
        }
    }
}
