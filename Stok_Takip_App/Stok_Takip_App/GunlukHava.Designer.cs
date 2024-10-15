namespace Stok_Takip_App
{
    partial class GunlukHava
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

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lblDT = new System.Windows.Forms.Label();
            this.lblCond = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(3, 3);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(68, 62);
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDT.Location = new System.Drawing.Point(77, 3);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(53, 16);
            this.lblDT.TabIndex = 1;
            this.lblDT.Text = "Sunday";
            // 
            // lblCond
            // 
            this.lblCond.AutoSize = true;
            this.lblCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCond.Location = new System.Drawing.Point(77, 27);
            this.lblCond.Name = "lblCond";
            this.lblCond.Size = new System.Drawing.Size(39, 16);
            this.lblCond.TabIndex = 2;
            this.lblCond.Text = "Clear";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDescription.Location = new System.Drawing.Point(77, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // GunlukHava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCond);
            this.Controls.Add(this.lblDT);
            this.Controls.Add(this.pbIcon);
            this.Name = "GunlukHava";
            this.Size = new System.Drawing.Size(301, 75);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbIcon;
        public System.Windows.Forms.Label lblDT;
        public System.Windows.Forms.Label lblCond;
        public System.Windows.Forms.Label lblDescription;
    }
}
