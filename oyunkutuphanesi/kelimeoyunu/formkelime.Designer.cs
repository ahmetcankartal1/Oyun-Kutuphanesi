namespace oyunkutuphanesi.kelimeoyunu
{
    partial class formkelime
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
            this.lblKelime = new System.Windows.Forms.Label();
            this.lblHak = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.txtTahmin = new System.Windows.Forms.TextBox();
            this.btnKolay = new System.Windows.Forms.Button();
            this.btnOrta = new System.Windows.Forms.Button();
            this.btnZor = new System.Windows.Forms.Button();
            this.btnTahmin = new System.Windows.Forms.Button();
            this.lblSkor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblKelime
            // 
            this.lblKelime.AutoSize = true;
            this.lblKelime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKelime.Location = new System.Drawing.Point(61, 75);
            this.lblKelime.Name = "lblKelime";
            this.lblKelime.Size = new System.Drawing.Size(259, 69);
            this.lblKelime.TabIndex = 0;
            this.lblKelime.Text = "_ _ _ _ _";
            // 
            // lblHak
            // 
            this.lblHak.AutoSize = true;
            this.lblHak.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHak.Location = new System.Drawing.Point(610, 75);
            this.lblHak.Name = "lblHak";
            this.lblHak.Size = new System.Drawing.Size(120, 31);
            this.lblHak.TabIndex = 1;
            this.lblHak.Text = "Hak : 0/0";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(630, 153);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 27);
            this.lblDurum.TabIndex = 2;
            // 
            // txtTahmin
            // 
            this.txtTahmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTahmin.Location = new System.Drawing.Point(135, 176);
            this.txtTahmin.MaxLength = 1;
            this.txtTahmin.Multiline = true;
            this.txtTahmin.Name = "txtTahmin";
            this.txtTahmin.Size = new System.Drawing.Size(75, 34);
            this.txtTahmin.TabIndex = 3;
            // 
            // btnKolay
            // 
            this.btnKolay.Location = new System.Drawing.Point(554, 214);
            this.btnKolay.Name = "btnKolay";
            this.btnKolay.Size = new System.Drawing.Size(75, 49);
            this.btnKolay.TabIndex = 4;
            this.btnKolay.Text = "Kolay";
            this.btnKolay.UseVisualStyleBackColor = true;
            // 
            // btnOrta
            // 
            this.btnOrta.Location = new System.Drawing.Point(635, 214);
            this.btnOrta.Name = "btnOrta";
            this.btnOrta.Size = new System.Drawing.Size(75, 49);
            this.btnOrta.TabIndex = 5;
            this.btnOrta.Text = "Orta";
            this.btnOrta.UseVisualStyleBackColor = true;
            // 
            // btnZor
            // 
            this.btnZor.Location = new System.Drawing.Point(716, 214);
            this.btnZor.Name = "btnZor";
            this.btnZor.Size = new System.Drawing.Size(75, 49);
            this.btnZor.TabIndex = 6;
            this.btnZor.Text = "Zor";
            this.btnZor.UseVisualStyleBackColor = true;
            // 
            // btnTahmin
            // 
            this.btnTahmin.Location = new System.Drawing.Point(135, 264);
            this.btnTahmin.Name = "btnTahmin";
            this.btnTahmin.Size = new System.Drawing.Size(75, 49);
            this.btnTahmin.TabIndex = 7;
            this.btnTahmin.Text = "Tahmin Et";
            this.btnTahmin.UseVisualStyleBackColor = true;
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSkor.Location = new System.Drawing.Point(612, 34);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(58, 24);
            this.lblSkor.TabIndex = 8;
            this.lblSkor.Text = "Skor :";
            // 
            // formkelime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(916, 488);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.btnTahmin);
            this.Controls.Add(this.btnZor);
            this.Controls.Add(this.btnOrta);
            this.Controls.Add(this.btnKolay);
            this.Controls.Add(this.txtTahmin);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.lblHak);
            this.Controls.Add(this.lblKelime);
            this.Name = "formkelime";
            this.Text = "formkelime";
            this.Load += new System.EventHandler(this.formkelime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKelime;
        private System.Windows.Forms.Label lblHak;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.TextBox txtTahmin;
        private System.Windows.Forms.Button btnKolay;
        private System.Windows.Forms.Button btnOrta;
        private System.Windows.Forms.Button btnZor;
        private System.Windows.Forms.Button btnTahmin;
        private System.Windows.Forms.Label lblSkor;
    }
}