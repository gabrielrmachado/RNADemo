namespace RNADemo.Design
{
    partial class frmNumeroPadroes
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnProsseguirPadroes = new System.Windows.Forms.Button();
            this.btnCarregarPadroes = new System.Windows.Forms.Button();
            this.txtNumPadroes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº de amostras para treinamento:";
            // 
            // btnProsseguirPadroes
            // 
            this.btnProsseguirPadroes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProsseguirPadroes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProsseguirPadroes.Image = global::RNADemo.Properties.Resources.check;
            this.btnProsseguirPadroes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProsseguirPadroes.Location = new System.Drawing.Point(191, 148);
            this.btnProsseguirPadroes.Name = "btnProsseguirPadroes";
            this.btnProsseguirPadroes.Size = new System.Drawing.Size(100, 52);
            this.btnProsseguirPadroes.TabIndex = 1;
            this.btnProsseguirPadroes.Text = "Prosseguir";
            this.btnProsseguirPadroes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProsseguirPadroes.UseVisualStyleBackColor = true;
            this.btnProsseguirPadroes.Click += new System.EventHandler(this.btnProsseguirPadroes_Click);
            // 
            // btnCarregarPadroes
            // 
            this.btnCarregarPadroes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCarregarPadroes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarPadroes.Image = global::RNADemo.Properties.Resources.load;
            this.btnCarregarPadroes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCarregarPadroes.Location = new System.Drawing.Point(16, 148);
            this.btnCarregarPadroes.Name = "btnCarregarPadroes";
            this.btnCarregarPadroes.Size = new System.Drawing.Size(100, 52);
            this.btnCarregarPadroes.TabIndex = 2;
            this.btnCarregarPadroes.Text = "Carregar ";
            this.btnCarregarPadroes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCarregarPadroes.UseVisualStyleBackColor = true;
            // 
            // txtNumPadroes
            // 
            this.txtNumPadroes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumPadroes.Location = new System.Drawing.Point(77, 70);
            this.txtNumPadroes.Name = "txtNumPadroes";
            this.txtNumPadroes.Size = new System.Drawing.Size(149, 26);
            this.txtNumPadroes.TabIndex = 3;
            this.txtNumPadroes.Text = "10";
            this.txtNumPadroes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumPadroes.Leave += new System.EventHandler(this.txtNumPadroes_Leave);
            // 
            // frmNumeroPadroes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 221);
            this.Controls.Add(this.txtNumPadroes);
            this.Controls.Add(this.btnCarregarPadroes);
            this.Controls.Add(this.btnProsseguirPadroes);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumeroPadroes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Número de Padrões";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProsseguirPadroes;
        private System.Windows.Forms.Button btnCarregarPadroes;
        private System.Windows.Forms.TextBox txtNumPadroes;
    }
}