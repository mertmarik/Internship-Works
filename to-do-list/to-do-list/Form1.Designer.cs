namespace to_do_list
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pazartesi = new System.Windows.Forms.ListBox();
            this.Sali = new System.Windows.Forms.ListBox();
            this.Çarşamba = new System.Windows.Forms.ListBox();
            this.Perşembe = new System.Windows.Forms.ListBox();
            this.Cuma = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Pazartesi
            // 
            this.Pazartesi.FormattingEnabled = true;
            this.Pazartesi.Location = new System.Drawing.Point(20, 23);
            this.Pazartesi.Name = "Pazartesi";
            this.Pazartesi.Size = new System.Drawing.Size(158, 342);
            this.Pazartesi.TabIndex = 0;
            // 
            // Sali
            // 
            this.Sali.FormattingEnabled = true;
            this.Sali.Location = new System.Drawing.Point(179, 23);
            this.Sali.Name = "Sali";
            this.Sali.Size = new System.Drawing.Size(157, 342);
            this.Sali.TabIndex = 1;
            // 
            // Çarşamba
            // 
            this.Çarşamba.FormattingEnabled = true;
            this.Çarşamba.Location = new System.Drawing.Point(336, 23);
            this.Çarşamba.Name = "Çarşamba";
            this.Çarşamba.Size = new System.Drawing.Size(157, 342);
            this.Çarşamba.TabIndex = 2;
            // 
            // Perşembe
            // 
            this.Perşembe.FormattingEnabled = true;
            this.Perşembe.Location = new System.Drawing.Point(493, 23);
            this.Perşembe.Name = "Perşembe";
            this.Perşembe.Size = new System.Drawing.Size(157, 342);
            this.Perşembe.TabIndex = 3;
            // 
            // Cuma
            // 
            this.Cuma.FormattingEnabled = true;
            this.Cuma.Location = new System.Drawing.Point(650, 23);
            this.Cuma.Name = "Cuma";
            this.Cuma.Size = new System.Drawing.Size(157, 342);
            this.Cuma.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(179, 383);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(471, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma"});
            this.comboBox1.Location = new System.Drawing.Point(20, 419);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Gönder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(675, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 60);
            this.button2.TabIndex = 8;
            this.button2.Text = "Text\'e Dönüştür";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 514);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Cuma);
            this.Controls.Add(this.Perşembe);
            this.Controls.Add(this.Çarşamba);
            this.Controls.Add(this.Sali);
            this.Controls.Add(this.Pazartesi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Pazartesi;
        private System.Windows.Forms.ListBox Sali;
        private System.Windows.Forms.ListBox Çarşamba;
        private System.Windows.Forms.ListBox Perşembe;
        private System.Windows.Forms.ListBox Cuma;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

