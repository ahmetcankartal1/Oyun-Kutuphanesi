namespace oyunkutuphanesi
{
    partial class formyilan
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
            this.panelGame = new System.Windows.Forms.Panel();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.rbkolay = new System.Windows.Forms.RadioButton();
            this.rbzor = new System.Windows.Forms.RadioButton();
            this.rborta = new System.Windows.Forms.RadioButton();
            this.btnbasla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelGame.Location = new System.Drawing.Point(12, 12);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(684, 537);
            this.panelGame.TabIndex = 0;
            this.panelGame.TabStop = true;
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonuc.ForeColor = System.Drawing.Color.Crimson;
            this.lblSonuc.Location = new System.Drawing.Point(811, 311);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(86, 29);
            this.lblSonuc.TabIndex = 1;
            this.lblSonuc.Text = "Sonuc";
            this.lblSonuc.Visible = false;
            // 
            // lblPuan
            // 
            this.lblPuan.AutoSize = true;
            this.lblPuan.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPuan.Location = new System.Drawing.Point(792, 138);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(105, 27);
            this.lblPuan.TabIndex = 2;
            this.lblPuan.Text = "Puan :   0";
            // 
            // rbkolay
            // 
            this.rbkolay.AutoSize = true;
            this.rbkolay.Checked = true;
            this.rbkolay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbkolay.Location = new System.Drawing.Point(737, 64);
            this.rbkolay.Name = "rbkolay";
            this.rbkolay.Size = new System.Drawing.Size(71, 22);
            this.rbkolay.TabIndex = 3;
            this.rbkolay.TabStop = true;
            this.rbkolay.Text = "Kolay";
            this.rbkolay.UseVisualStyleBackColor = true;
            // 
            // rbzor
            // 
            this.rbzor.AutoSize = true;
            this.rbzor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbzor.Location = new System.Drawing.Point(899, 64);
            this.rbzor.Name = "rbzor";
            this.rbzor.Size = new System.Drawing.Size(55, 22);
            this.rbzor.TabIndex = 4;
            this.rbzor.Text = "Zor";
            this.rbzor.UseVisualStyleBackColor = true;
            // 
            // rborta
            // 
            this.rborta.AutoSize = true;
            this.rborta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rborta.Location = new System.Drawing.Point(820, 64);
            this.rborta.Name = "rborta";
            this.rborta.Size = new System.Drawing.Size(62, 22);
            this.rborta.TabIndex = 5;
            this.rborta.Text = "Orta";
            this.rborta.UseVisualStyleBackColor = true;
            // 
            // btnbasla
            // 
            this.btnbasla.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbasla.Location = new System.Drawing.Point(810, 198);
            this.btnbasla.Name = "btnbasla";
            this.btnbasla.Size = new System.Drawing.Size(95, 53);
            this.btnbasla.TabIndex = 6;
            this.btnbasla.Text = "Başla";
            this.btnbasla.UseVisualStyleBackColor = true;
            this.btnbasla.Click += new System.EventHandler(this.btnbasla_Click);
            // 
            // formyilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 665);
            this.Controls.Add(this.btnbasla);
            this.Controls.Add(this.rborta);
            this.Controls.Add(this.rbzor);
            this.Controls.Add(this.rbkolay);
            this.Controls.Add(this.lblPuan);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.panelGame);
            this.Name = "formyilan";
            this.Text = "formyilan";
            this.Load += new System.EventHandler(this.formyilan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.Label lblPuan;
        private System.Windows.Forms.RadioButton rbkolay;
        private System.Windows.Forms.RadioButton rbzor;
        private System.Windows.Forms.RadioButton rborta;
        private System.Windows.Forms.Button btnbasla;
    }
}