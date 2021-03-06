﻿using RNADemo.Business;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace RNADemo.Design
{
    public partial class frmTreinamento : Form
    {
        private MLP _redeNeural;
        private int indiceAmostraAssociada, numPadroesFornecidos, numPadroesRestantes;
        private bool _editar;
        string pathLogTreinamento = Path.Combine(Environment.CurrentDirectory, "training.log");
        ReaderWriterLock rwl;

        delegate void SetDadosProgressoTreinamento(ProgressBar bar, Label lblProgress);

        public frmTreinamento(MLP neuralNet, bool carregouAmostras)
        {
            InitializeComponent();
            _redeNeural = neuralNet;
            FormClosing += Utils.FecharFormulario;
            rwl = new ReaderWriterLock();

            numPadroesRestantes = _redeNeural.NumeroAmostrasTreinamento;
            txtQtdAmostrasRestantes.Text = _redeNeural.NumeroAmostrasTreinamento.ToString();
            txtQtdAmostrasFornecidas.Text = "0";
            ActiveControl = lblCntPadrao;
            txtIndiceImagem.Enabled = false;
            _editar = false;

            txtIndiceImagem.Leave += (s, e) => txtIndiceImagem.Text = "Digite o índice:";
            txtIndiceImagem.Enter += (s, e) => txtIndiceImagem.Text = "";
            txtIndiceImagem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int valorAntigoIndice = indiceAmostraAssociada;
                    try
                    {
                        indiceAmostraAssociada = int.Parse(txtIndiceImagem.Text) - 1;

                        if (indiceAmostraAssociada == 0)
                        {
                            RealizarCliqueBtnPrimeiro();
                        }
                        else if (indiceAmostraAssociada == numPadroesFornecidos)
                        {

                            RealizarCliqueBtnUltimo();
                        }
                        else if (indiceAmostraAssociada > numPadroesFornecidos)
                        {
                            indiceAmostraAssociada = valorAntigoIndice;
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            btnPrimeiro.Enabled = true;
                            btnProximo.Enabled = true;
                            btnAnterior.Enabled = true;
                            btnUltimo.Enabled = true;
                            AtualizarControlesClasses(true);
                        }
                        txtIndiceImagem.Text = "Digite o índice:";
                    }

                    catch (Exception ex)
                    {
                        if (ex is FormatException || ex is ArgumentNullException || ex is OverflowException || ex is IndexOutOfRangeException)
                        {
                            MessageBox.Show(string.Format("Digite um índice válido entre 1 e {0}", numPadroesFornecidos + 1), "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        txtIndiceImagem.Text = "";
                        txtIndiceImagem.Focus();
                    }
                }
            };

            foreach (PictureBox pixel in grpAmostra.Controls.OfType<PictureBox>())
            {
                pixel.Click += Utils.MudarCorPixel;
            }

            foreach (RadioButton radio in grpClasses.Controls.OfType<RadioButton>())
            {
                radio.Click += Radio_Click;
            }

            if (carregouAmostras)
            {
                numPadroesFornecidos = _redeNeural.NumeroAmostrasTreinamento;
                numPadroesRestantes = 0;

                txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
                txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();

                btnTreinarRede.Enabled = true;
                btnUltimo.Enabled = true;
                btnProximo.Enabled = true;
                _editar = true;
                txtIndiceImagem.Enabled = true;

                indiceAmostraAssociada = 0;
            }
            AtualizarControlesClasses();
        }

        private void AtualizarControlesClasses(bool txtIndiceAmostras = false)
        {
            try
            {
                grpAmostra.PreencherGrid(_redeNeural.AmostrasTreinamento.Row(indiceAmostraAssociada));
                lblCntPadrao.AlterarLabelNavegacaoAmostras(indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
                grpClasses.AtualizarContadorAmostrasPorClasse(_redeNeural.ClassesTreinamento);
                var rdButton = grpClasses.Controls.OfType<RadioButton>().First(rb => rb.Name == "rb" + _redeNeural.ClassesTreinamento[indiceAmostraAssociada]);
                txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
                rdButton.Checked = true;
                ActiveControl = lblCntPadrao;
            }
            catch (InvalidOperationException)
            {
                grpClasses.DesmarcarSelecaoRadioButtonsClasses();
                txtAmostraEnsinada.Text = "";
                ActiveControl = lblCntPadrao;
            }
            catch (IndexOutOfRangeException)
            {
                if (!txtIndiceAmostras)
                    RealizarCliqueBtnUltimo();
                
                else throw;
                ActiveControl = lblCntPadrao;
            }
        }

        private void Radio_Click(object sender, EventArgs e)
        {
            RadioButton rdButton = (sender as RadioButton);
            txtAmostraEnsinada.Text = rdButton.Text.Substring(rdButton.Text.IndexOf(' '));
        }

        private void btnAssociar_Click(object sender, EventArgs e)
        {
            if (!_editar)
            {
                numPadroesFornecidos++;
                numPadroesRestantes--;
                txtQtdAmostrasFornecidas.Text = numPadroesFornecidos.ToString();
                txtQtdAmostrasRestantes.Text = numPadroesRestantes.ToString();
            }

            int i = 0;
            foreach (var pb in grpAmostra.Controls.OfType<PictureBox>().OrderBy((x) => x.Name))
            {
                _redeNeural.AmostrasTreinamento[indiceAmostraAssociada, i] = (pb.BackColor == Color.White ? 0.0 : 1.0);
                i++;
            }
            try
            {
                _redeNeural.ClassesTreinamento[indiceAmostraAssociada] = double.Parse(txtAmostraEnsinada.Text);
                lblCntPadrao.AlterarLabelNavegacaoAmostras(++indiceAmostraAssociada + 1, _redeNeural.NumeroAmostrasTreinamento);
                grpClasses.AtualizarContadorAmostrasPorClasse(_redeNeural.ClassesTreinamento);

                btnAnterior.Enabled = true;
                btnPrimeiro.Enabled = true;

                if (numPadroesFornecidos == _redeNeural.NumeroAmostrasTreinamento)
                {
                    btnSalvarAmostras.Enabled = true;
                    btnTreinarRede.Enabled = true;
                    _editar = true;
                }
                else
                {
                    txtAmostraEnsinada.Text = "";
                    grpClasses.DesmarcarSelecaoRadioButtonsClasses();
                }
                if (!txtIndiceImagem.Enabled) txtIndiceImagem.Enabled = true;
                RealizarCliqueBtnUltimo();
            }
            catch (FormatException)
            {
                MessageBox.Show("Atribua uma classe para a amostra!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPadroesFornecidos--;
                numPadroesRestantes++;
            }
        }

        private void LerArquivoLog()
        {
            FileStream fs = File.Open(pathLogTreinamento, FileMode.Open, FileAccess.Read, FileShare.Write);
            StreamReader sr = new StreamReader(fs);
            string iteracao = "";
            rwl.AcquireReaderLock(Timeout.Infinite);

            while (true)
            {
                string linha = sr.ReadLine().Replace(" ", "");

                if (linha == "END") break;

                if (linha.StartsWith("Iteration"))
                {
                    int i1 = linha.IndexOf(':') + 1;
                    int i2 = linha.IndexOf('-');
                    iteracao = linha.Substring(i1, i2 - i1);

                    var dadosPT = new SetDadosProgressoTreinamento((progressBar, lblProgresso) =>
                    {
                        progressBar.Value = int.Parse(iteracao);
                        lblProgresso.Text = lblProgresso.Text = string.Format("{0}/{1}", int.Parse(iteracao), _redeNeural.NumEpocas);
                    });

                    this.Invoke(dadosPT, progressBar, lblProgresso);
                }
            }
            rwl.ReleaseReaderLock();
            sr.Close();
            fs.Close();
        }

        private void btnTreinarRede_Click(object sender, EventArgs e)
        {
            btnProsseguirTeste.Enabled = true;
            progressBar.Maximum = _redeNeural.NumEpocas;

            if (!File.Exists(pathLogTreinamento))
                File.Create(pathLogTreinamento);

            Trace.Listeners.Add(new TextWriterTraceListener(pathLogTreinamento));
            try
            {
                var thread = new Thread(new ThreadStart(() => LerArquivoLog()));
                thread.Start();

                Trace.AutoFlush = true;

                rwl.AcquireWriterLock(Timeout.Infinite);
                _redeNeural.TreinarRede();
                Trace.WriteLine("END");
                rwl.ReleaseWriterLock();

                Trace.Flush();
                MessageBox.Show("Rede treinada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                thread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao treinar a rede neural: {0}", ex.Message), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Trace.Close();
                File.Delete(pathLogTreinamento);
            }
        }

        private void btnSalvarAmostras_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Selecione um local para salvamento:";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string sSelectedPath = fbd.SelectedPath;
                    _redeNeural.SalvarAmostras(sSelectedPath);
                    MessageBox.Show("Amostras salvas com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ocorreu o seguinte erro ao salvar as amostras: {0}", ex.Message), "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProsseguirTeste_Click(object sender, EventArgs e)
        {
            new frmTeste(_redeNeural).Show();
            Hide();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            RealizarCliqueBtnPrimeiro();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            _editar = true;

            indiceAmostraAssociada--;
            if (indiceAmostraAssociada == 0)
            {
                btnAnterior.Enabled = false;
                btnPrimeiro.Enabled = false;
            }
            else if (indiceAmostraAssociada < 0)
                RealizarCliqueBtnPrimeiro();

            AtualizarControlesClasses();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;

            indiceAmostraAssociada++;
            if (indiceAmostraAssociada >= numPadroesFornecidos)
            {
                btnProximo.Enabled = false;
                btnUltimo.Enabled = false;
                _editar = true;
                RealizarCliqueBtnUltimo();
            }

            else AtualizarControlesClasses();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            RealizarCliqueBtnUltimo();
        }

        private void RealizarCliqueBtnPrimeiro()
        {
            btnProximo.Enabled = true;
            btnUltimo.Enabled = true;
            btnPrimeiro.Enabled = false;
            btnAnterior.Enabled = false;
            _editar = true;

            indiceAmostraAssociada = 0;
            AtualizarControlesClasses();
        }

        private void RealizarCliqueBtnUltimo()
        {
            btnAnterior.Enabled = true;
            btnPrimeiro.Enabled = true;
            btnProximo.Enabled = false;
            btnUltimo.Enabled = false;

            if (numPadroesRestantes > 0)
            {
                indiceAmostraAssociada = numPadroesFornecidos;
                _editar = false;
            }
            else
            {
                indiceAmostraAssociada = numPadroesFornecidos - 1;
                _editar = true;
            }
            AtualizarControlesClasses();
        }
    }
}