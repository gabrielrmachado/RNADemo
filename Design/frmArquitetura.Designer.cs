namespace RNADemo.Design
{
    partial class frmArquitetura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArquitetura));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNumCamadas = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCamada4 = new System.Windows.Forms.TextBox();
            this.txtCamada3 = new System.Windows.Forms.TextBox();
            this.txtCamada2 = new System.Windows.Forms.TextBox();
            this.txtCamada1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbOtimizacao = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMomento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAprendizado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEpocas = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº de Camadas Escondidas:";
            // 
            // cmbNumCamadas
            // 
            this.cmbNumCamadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumCamadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNumCamadas.FormattingEnabled = true;
            this.cmbNumCamadas.Location = new System.Drawing.Point(213, 32);
            this.cmbNumCamadas.Name = "cmbNumCamadas";
            this.cmbNumCamadas.Size = new System.Drawing.Size(84, 26);
            this.cmbNumCamadas.TabIndex = 1;
            this.cmbNumCamadas.SelectedIndexChanged += new System.EventHandler(this.cmbNumCamadas_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNumCamadas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Topologia da Rede";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCamada4);
            this.groupBox2.Controls.Add(this.txtCamada3);
            this.groupBox2.Controls.Add(this.txtCamada2);
            this.groupBox2.Controls.Add(this.txtCamada1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nº de Processadores por Camada Escondida";
            // 
            // txtCamada4
            // 
            this.txtCamada4.Enabled = false;
            this.txtCamada4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamada4.Location = new System.Drawing.Point(303, 87);
            this.txtCamada4.Name = "txtCamada4";
            this.txtCamada4.Size = new System.Drawing.Size(100, 24);
            this.txtCamada4.TabIndex = 9;
            this.txtCamada4.Text = "15";
            this.txtCamada4.Leave += new System.EventHandler(this.txtCamada4_Leave);
            // 
            // txtCamada3
            // 
            this.txtCamada3.Enabled = false;
            this.txtCamada3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamada3.Location = new System.Drawing.Point(303, 41);
            this.txtCamada3.Name = "txtCamada3";
            this.txtCamada3.Size = new System.Drawing.Size(100, 24);
            this.txtCamada3.TabIndex = 8;
            this.txtCamada3.Text = "15";
            this.txtCamada3.Leave += new System.EventHandler(this.txtCamada3_Leave);
            // 
            // txtCamada2
            // 
            this.txtCamada2.Enabled = false;
            this.txtCamada2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamada2.Location = new System.Drawing.Point(95, 87);
            this.txtCamada2.Name = "txtCamada2";
            this.txtCamada2.Size = new System.Drawing.Size(100, 24);
            this.txtCamada2.TabIndex = 7;
            this.txtCamada2.Text = "15";
            this.txtCamada2.Leave += new System.EventHandler(this.txtCamada2_Leave);
            // 
            // txtCamada1
            // 
            this.txtCamada1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCamada1.Location = new System.Drawing.Point(96, 41);
            this.txtCamada1.Name = "txtCamada1";
            this.txtCamada1.Size = new System.Drawing.Size(100, 24);
            this.txtCamada1.TabIndex = 6;
            this.txtCamada1.Text = "15";
            this.txtCamada1.Leave += new System.EventHandler(this.txtCamada1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Camada 4:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Camada 3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Camada 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Camada 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nº de épocas:";
            // 
            // btnCarregar
            // 
            this.btnCarregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregar.Image = ((System.Drawing.Image)(resources.GetObject("btnCarregar.Image")));
            this.btnCarregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCarregar.Location = new System.Drawing.Point(12, 473);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(113, 58);
            this.btnCarregar.TabIndex = 2;
            this.btnCarregar.Text = "Carregar Rede";
            this.btnCarregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnContinuar.Location = new System.Drawing.Point(315, 473);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(113, 58);
            this.btnContinuar.TabIndex = 2;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbOtimizacao);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtMomento);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtAprendizado);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtEpocas);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 185);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parâmetros da Rede";
            // 
            // cmbOtimizacao
            // 
            this.cmbOtimizacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOtimizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOtimizacao.FormattingEnabled = true;
            this.cmbOtimizacao.Location = new System.Drawing.Point(195, 144);
            this.cmbOtimizacao.Name = "cmbOtimizacao";
            this.cmbOtimizacao.Size = new System.Drawing.Size(158, 26);
            this.cmbOtimizacao.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "Algoritmo de Otimização:";
            // 
            // txtMomento
            // 
            this.txtMomento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMomento.Location = new System.Drawing.Point(195, 110);
            this.txtMomento.Name = "txtMomento";
            this.txtMomento.Size = new System.Drawing.Size(91, 24);
            this.txtMomento.TabIndex = 10;
            this.txtMomento.Text = "0,9";
            this.txtMomento.Leave += new System.EventHandler(this.txtMomento_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Momento:";
            // 
            // txtAprendizado
            // 
            this.txtAprendizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAprendizado.Location = new System.Drawing.Point(195, 77);
            this.txtAprendizado.Name = "txtAprendizado";
            this.txtAprendizado.Size = new System.Drawing.Size(91, 24);
            this.txtAprendizado.TabIndex = 8;
            this.txtAprendizado.Text = "0,01";
            this.txtAprendizado.Leave += new System.EventHandler(this.txtAprendizado_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Taxa de Aprendizado:";
            // 
            // txtEpocas
            // 
            this.txtEpocas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpocas.Location = new System.Drawing.Point(195, 44);
            this.txtEpocas.Name = "txtEpocas";
            this.txtEpocas.Size = new System.Drawing.Size(91, 24);
            this.txtEpocas.TabIndex = 6;
            this.txtEpocas.Text = "10";
            this.txtEpocas.Leave += new System.EventHandler(this.txtEpocas_Leave);
            // 
            // frmArquitetura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 542);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArquitetura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arquitetura da Rede Neural";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNumCamadas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCamada4;
        private System.Windows.Forms.TextBox txtCamada3;
        private System.Windows.Forms.TextBox txtCamada2;
        private System.Windows.Forms.TextBox txtCamada1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMomento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAprendizado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEpocas;
        private System.Windows.Forms.ComboBox cmbOtimizacao;
        private System.Windows.Forms.Label label11;
    }
}