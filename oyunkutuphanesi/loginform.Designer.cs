namespace OyunKutuphane
{
    partial class loginform
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtkadi = new System.Windows.Forms.TextBox();
            this.btngir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(172, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ad:";
            // 
            // txtkadi
            // 
            this.txtkadi.Location = new System.Drawing.Point(215, 121);
            this.txtkadi.Name = "txtkadi";
            this.txtkadi.Size = new System.Drawing.Size(130, 22);
            this.txtkadi.TabIndex = 2;
            // 
            // btngir
            // 
            this.btngir.Location = new System.Drawing.Point(215, 180);
            this.btngir.Name = "btngir";
            this.btngir.Size = new System.Drawing.Size(130, 37);
            this.btngir.TabIndex = 3;
            this.btngir.Text = "Giriş";
            this.btngir.UseVisualStyleBackColor = true;
            this.btngir.Click += new System.EventHandler(this.btngir_Click);
            // 
            // loginform
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(548, 365);
            this.Controls.Add(this.btngir);
            this.Controls.Add(this.txtkadi);
            this.Controls.Add(this.label3);
            this.Name = "loginform";
            this.Load += new System.EventHandler(this.loginform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtsoyad;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtkadi;
        private System.Windows.Forms.Button btngir;
    }
}

