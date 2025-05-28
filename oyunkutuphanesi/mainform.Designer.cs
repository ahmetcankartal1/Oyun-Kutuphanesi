namespace oyunkutuphanesi
{
    partial class mainform
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
            this.lblhosgeldiniz = new System.Windows.Forms.Label();
            this.btnyilan = new System.Windows.Forms.Button();
            this.btnlab = new System.Windows.Forms.Button();
            this.btnkart = new System.Windows.Forms.Button();
            this.btnkelime = new System.Windows.Forms.Button();
            this.btntop = new System.Windows.Forms.Button();
            this.btncikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblhosgeldiniz
            // 
            this.lblhosgeldiniz.AutoSize = true;
            this.lblhosgeldiniz.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblhosgeldiniz.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblhosgeldiniz.Location = new System.Drawing.Point(314, 88);
            this.lblhosgeldiniz.Name = "lblhosgeldiniz";
            this.lblhosgeldiniz.Size = new System.Drawing.Size(156, 31);
            this.lblhosgeldiniz.TabIndex = 0;
            this.lblhosgeldiniz.Text = "HOŞGELDİN";
            // 
            // btnyilan
            // 
            this.btnyilan.BackColor = System.Drawing.Color.Transparent;
            this.btnyilan.Location = new System.Drawing.Point(122, 220);
            this.btnyilan.Name = "btnyilan";
            this.btnyilan.Size = new System.Drawing.Size(102, 62);
            this.btnyilan.TabIndex = 1;
            this.btnyilan.Text = "Yılan Oyunu";
            this.btnyilan.UseVisualStyleBackColor = false;
            this.btnyilan.Click += new System.EventHandler(this.btnyilan_Click);
            // 
            // btnlab
            // 
            this.btnlab.BackColor = System.Drawing.Color.Transparent;
            this.btnlab.Location = new System.Drawing.Point(230, 220);
            this.btnlab.Name = "btnlab";
            this.btnlab.Size = new System.Drawing.Size(102, 62);
            this.btnlab.TabIndex = 1;
            this.btnlab.Text = "Labirent Oyunu";
            this.btnlab.UseVisualStyleBackColor = false;
            this.btnlab.Click += new System.EventHandler(this.btnlab_Click);
            // 
            // btnkart
            // 
            this.btnkart.BackColor = System.Drawing.Color.Transparent;
            this.btnkart.Location = new System.Drawing.Point(338, 220);
            this.btnkart.Name = "btnkart";
            this.btnkart.Size = new System.Drawing.Size(102, 62);
            this.btnkart.TabIndex = 1;
            this.btnkart.Text = "Kart Eşleştirme Oyunu";
            this.btnkart.UseVisualStyleBackColor = false;
            this.btnkart.Click += new System.EventHandler(this.btnkart_Click);
            // 
            // btnkelime
            // 
            this.btnkelime.BackColor = System.Drawing.Color.Transparent;
            this.btnkelime.Location = new System.Drawing.Point(446, 220);
            this.btnkelime.Name = "btnkelime";
            this.btnkelime.Size = new System.Drawing.Size(113, 62);
            this.btnkelime.TabIndex = 1;
            this.btnkelime.Text = "Kelime Tahmini Oyunu";
            this.btnkelime.UseVisualStyleBackColor = false;
            this.btnkelime.Click += new System.EventHandler(this.btnkelime_Click);
            // 
            // btntop
            // 
            this.btntop.BackColor = System.Drawing.Color.Transparent;
            this.btntop.Location = new System.Drawing.Point(565, 220);
            this.btntop.Name = "btntop";
            this.btntop.Size = new System.Drawing.Size(111, 62);
            this.btntop.TabIndex = 1;
            this.btntop.Text = "Zıplayan Top Oyunu";
            this.btntop.UseVisualStyleBackColor = false;
            this.btntop.Click += new System.EventHandler(this.btntop_Click);
            // 
            // btncikis
            // 
            this.btncikis.BackColor = System.Drawing.Color.Silver;
            this.btncikis.Location = new System.Drawing.Point(623, 370);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(133, 50);
            this.btncikis.TabIndex = 2;
            this.btncikis.Text = "Çıkış Yap";
            this.btncikis.UseVisualStyleBackColor = false;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.btntop);
            this.Controls.Add(this.btnkelime);
            this.Controls.Add(this.btnkart);
            this.Controls.Add(this.btnlab);
            this.Controls.Add(this.btnyilan);
            this.Controls.Add(this.lblhosgeldiniz);
            this.Name = "mainform";
            this.Text = "mainform";
            this.Load += new System.EventHandler(this.mainform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblhosgeldiniz;
        private System.Windows.Forms.Button btnyilan;
        private System.Windows.Forms.Button btnlab;
        private System.Windows.Forms.Button btnkart;
        private System.Windows.Forms.Button btnkelime;
        private System.Windows.Forms.Button btntop;
        private System.Windows.Forms.Button btncikis;
    }
}