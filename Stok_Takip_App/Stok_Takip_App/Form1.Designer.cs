namespace Stok_Takip_App
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
            this.label1 = new System.Windows.Forms.Label();
            this.urunTxt = new System.Windows.Forms.TextBox();
            this.rbTek = new System.Windows.Forms.RadioButton();
            this.rbKompleks = new System.Windows.Forms.RadioButton();
            this.rbIc = new System.Windows.Forms.RadioButton();
            this.rbDis = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaliyet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonGetRates = new System.Windows.Forms.Button();
            this.textBoxEuro = new System.Windows.Forms.TextBox();
            this.textBoxYen = new System.Windows.Forms.TextBox();
            this.textBoxDolar = new System.Windows.Forms.TextBox();
            this.textBoxDinar = new System.Windows.Forms.TextBox();
            this.textBoxPound = new System.Windows.Forms.TextBox();
            this.cmbDöviz = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDogum = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBatim = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTemp2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.txtMinTemp = new System.Windows.Forms.TextBox();
            this.txtRuzgar = new System.Windows.Forms.TextBox();
            this.txtNem = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.FLP = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün:";
            // 
            // urunTxt
            // 
            this.urunTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunTxt.Location = new System.Drawing.Point(143, 99);
            this.urunTxt.Name = "urunTxt";
            this.urunTxt.Size = new System.Drawing.Size(180, 26);
            this.urunTxt.TabIndex = 1;
            // 
            // rbTek
            // 
            this.rbTek.AutoSize = true;
            this.rbTek.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbTek.ForeColor = System.Drawing.Color.White;
            this.rbTek.Location = new System.Drawing.Point(18, 19);
            this.rbTek.Name = "rbTek";
            this.rbTek.Size = new System.Drawing.Size(51, 22);
            this.rbTek.TabIndex = 2;
            this.rbTek.TabStop = true;
            this.rbTek.Text = "Tek";
            this.rbTek.UseVisualStyleBackColor = true;
            this.rbTek.CheckedChanged += new System.EventHandler(this.rbTek_CheckedChanged);
            // 
            // rbKompleks
            // 
            this.rbKompleks.AutoSize = true;
            this.rbKompleks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbKompleks.ForeColor = System.Drawing.Color.White;
            this.rbKompleks.Location = new System.Drawing.Point(18, 53);
            this.rbKompleks.Name = "rbKompleks";
            this.rbKompleks.Size = new System.Drawing.Size(93, 22);
            this.rbKompleks.TabIndex = 3;
            this.rbKompleks.TabStop = true;
            this.rbKompleks.Text = "Kompleks";
            this.rbKompleks.UseVisualStyleBackColor = true;
            this.rbKompleks.CheckedChanged += new System.EventHandler(this.rbKompleks_CheckedChanged);
            // 
            // rbIc
            // 
            this.rbIc.AutoSize = true;
            this.rbIc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbIc.ForeColor = System.Drawing.Color.White;
            this.rbIc.Location = new System.Drawing.Point(22, 19);
            this.rbIc.Name = "rbIc";
            this.rbIc.Size = new System.Drawing.Size(85, 22);
            this.rbIc.TabIndex = 4;
            this.rbIc.TabStop = true;
            this.rbIc.Text = "İç Üretim";
            this.rbIc.UseVisualStyleBackColor = true;
            this.rbIc.CheckedChanged += new System.EventHandler(this.rbIc_CheckedChanged);
            // 
            // rbDis
            // 
            this.rbDis.AutoSize = true;
            this.rbDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbDis.ForeColor = System.Drawing.Color.White;
            this.rbDis.Location = new System.Drawing.Point(22, 53);
            this.rbDis.Name = "rbDis";
            this.rbDis.Size = new System.Drawing.Size(80, 22);
            this.rbDis.TabIndex = 5;
            this.rbDis.TabStop = true;
            this.rbDis.Text = "Dış Alım";
            this.rbDis.UseVisualStyleBackColor = true;
            this.rbDis.CheckedChanged += new System.EventHandler(this.rbDis_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(67, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Maliyet:";
            // 
            // txtMaliyet
            // 
            this.txtMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMaliyet.Location = new System.Drawing.Point(143, 165);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.Size = new System.Drawing.Size(180, 26);
            this.txtMaliyet.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(80, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Adet: ";
            // 
            // txtAdet
            // 
            this.txtAdet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdet.Location = new System.Drawing.Point(143, 289);
            this.txtAdet.Name = "txtAdet";
            this.txtAdet.Size = new System.Drawing.Size(180, 26);
            this.txtAdet.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Alım Tarihi:";
            // 
            // txtFirma
            // 
            this.txtFirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFirma.Location = new System.Drawing.Point(143, 353);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(180, 26);
            this.txtFirma.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Alınan Firma:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(159, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 44);
            this.button1.TabIndex = 14;
            this.button1.Text = "Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTek);
            this.groupBox1.Controls.Add(this.rbKompleks);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(586, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 91);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Tipi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbIc);
            this.groupBox2.Controls.Add(this.rbDis);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(344, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 91);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alım Tipi";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(143, 232);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(180, 20);
            this.dtp1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 33);
            this.button2.TabIndex = 19;
            this.button2.Text = "Stok Rapor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(12, 536);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(93, 30);
            this.btnTemizle.TabIndex = 20;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(418, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Komponentler";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(630, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Adet";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.buttonGetRates);
            this.groupBox3.Controls.Add(this.textBoxEuro);
            this.groupBox3.Controls.Add(this.textBoxYen);
            this.groupBox3.Controls.Add(this.textBoxDolar);
            this.groupBox3.Controls.Add(this.textBoxDinar);
            this.groupBox3.Controls.Add(this.textBoxPound);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(840, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 482);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bülten";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(63, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "DİNAR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(250, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "POUND";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(262, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "YEN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(66, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "EURO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(158, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "DOLAR";
            // 
            // buttonGetRates
            // 
            this.buttonGetRates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGetRates.ForeColor = System.Drawing.Color.Black;
            this.buttonGetRates.Location = new System.Drawing.Point(150, 400);
            this.buttonGetRates.Name = "buttonGetRates";
            this.buttonGetRates.Size = new System.Drawing.Size(100, 46);
            this.buttonGetRates.TabIndex = 6;
            this.buttonGetRates.Text = "Dövizi Getir";
            this.buttonGetRates.UseVisualStyleBackColor = true;
            this.buttonGetRates.Click += new System.EventHandler(this.buttonGetRates_ClickAsync);
            // 
            // textBoxEuro
            // 
            this.textBoxEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEuro.Location = new System.Drawing.Point(40, 157);
            this.textBoxEuro.Name = "textBoxEuro";
            this.textBoxEuro.Size = new System.Drawing.Size(100, 26);
            this.textBoxEuro.TabIndex = 4;
            // 
            // textBoxYen
            // 
            this.textBoxYen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxYen.Location = new System.Drawing.Point(230, 157);
            this.textBoxYen.Name = "textBoxYen";
            this.textBoxYen.Size = new System.Drawing.Size(100, 26);
            this.textBoxYen.TabIndex = 3;
            // 
            // textBoxDolar
            // 
            this.textBoxDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxDolar.Location = new System.Drawing.Point(137, 56);
            this.textBoxDolar.Name = "textBoxDolar";
            this.textBoxDolar.Size = new System.Drawing.Size(100, 26);
            this.textBoxDolar.TabIndex = 2;
            // 
            // textBoxDinar
            // 
            this.textBoxDinar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxDinar.Location = new System.Drawing.Point(40, 278);
            this.textBoxDinar.Name = "textBoxDinar";
            this.textBoxDinar.Size = new System.Drawing.Size(100, 26);
            this.textBoxDinar.TabIndex = 1;
            // 
            // textBoxPound
            // 
            this.textBoxPound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPound.Location = new System.Drawing.Point(230, 278);
            this.textBoxPound.Name = "textBoxPound";
            this.textBoxPound.Size = new System.Drawing.Size(100, 26);
            this.textBoxPound.TabIndex = 0;
            // 
            // cmbDöviz
            // 
            this.cmbDöviz.FormattingEnabled = true;
            this.cmbDöviz.Items.AddRange(new object[] {
            "TRY",
            "USD",
            "AUD",
            "DKK",
            "EUR",
            "GBP",
            "CHF",
            "SEK",
            "CAD",
            "KWD",
            "NOK",
            "SAR",
            "JPY",
            "BGN",
            "RON",
            "RUB",
            "IRR",
            "CNY",
            "PKR",
            "QAR",
            "KRW",
            "AZN",
            "AED"});
            this.cmbDöviz.Location = new System.Drawing.Point(12, 167);
            this.cmbDöviz.Name = "cmbDöviz";
            this.cmbDöviz.Size = new System.Drawing.Size(49, 21);
            this.cmbDöviz.TabIndex = 24;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDogum);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtBatim);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lblTemp2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.txtMaxTemp);
            this.groupBox4.Controls.Add(this.txtMinTemp);
            this.groupBox4.Controls.Add(this.txtRuzgar);
            this.groupBox4.Controls.Add(this.txtNem);
            this.groupBox4.Controls.Add(this.txtCity);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(12, 592);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(532, 373);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hava Durumu";
            // 
            // txtDogum
            // 
            this.txtDogum.Location = new System.Drawing.Point(176, 279);
            this.txtDogum.Name = "txtDogum";
            this.txtDogum.Size = new System.Drawing.Size(154, 21);
            this.txtDogum.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(73, 279);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 15);
            this.label19.TabIndex = 20;
            this.label19.Text = "Gün Doğumu";
            // 
            // txtBatim
            // 
            this.txtBatim.Location = new System.Drawing.Point(176, 326);
            this.txtBatim.Name = "txtBatim";
            this.txtBatim.Size = new System.Drawing.Size(154, 21);
            this.txtBatim.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(86, 326);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 15);
            this.label14.TabIndex = 18;
            this.label14.Text = "Gün Batımı";
            // 
            // lblTemp2
            // 
            this.lblTemp2.AutoSize = true;
            this.lblTemp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTemp2.Location = new System.Drawing.Point(409, 181);
            this.lblTemp2.Name = "lblTemp2";
            this.lblTemp2.Size = new System.Drawing.Size(25, 25);
            this.lblTemp2.TabIndex = 17;
            this.lblTemp2.Text = "0";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(364, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 32);
            this.button3.TabIndex = 16;
            this.button3.Text = "ARA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(385, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 68);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // txtMaxTemp
            // 
            this.txtMaxTemp.Location = new System.Drawing.Point(176, 91);
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.Size = new System.Drawing.Size(154, 21);
            this.txtMaxTemp.TabIndex = 12;
            // 
            // txtMinTemp
            // 
            this.txtMinTemp.Location = new System.Drawing.Point(176, 138);
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.Size = new System.Drawing.Size(154, 21);
            this.txtMinTemp.TabIndex = 11;
            // 
            // txtRuzgar
            // 
            this.txtRuzgar.Location = new System.Drawing.Point(176, 185);
            this.txtRuzgar.Name = "txtRuzgar";
            this.txtRuzgar.Size = new System.Drawing.Size(154, 21);
            this.txtRuzgar.TabIndex = 10;
            // 
            // txtNem
            // 
            this.txtNem.Location = new System.Drawing.Point(176, 232);
            this.txtNem.Name = "txtNem";
            this.txtNem.Size = new System.Drawing.Size(154, 21);
            this.txtNem.TabIndex = 9;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(176, 44);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(154, 21);
            this.txtCity.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(127, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 5;
            this.label18.Text = "Nem";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(37, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "Rüzgar Hızı(km/s)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "En Düşük Sıcaklık";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "En Yüksek Sıcaklık";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Şehir";
            // 
            // FLP
            // 
            this.FLP.BackColor = System.Drawing.Color.Transparent;
            this.FLP.Location = new System.Drawing.Point(1449, 775);
            this.FLP.Name = "FLP";
            this.FLP.Size = new System.Drawing.Size(10, 100);
            this.FLP.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(586, 592);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(656, 373);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Borsa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1254, 977);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.FLP);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmbDöviz);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFirma);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAdet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaliyet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urunTxt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borsa";
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urunTxt;
        private System.Windows.Forms.RadioButton rbTek;
        private System.Windows.Forms.RadioButton rbKompleks;
        private System.Windows.Forms.RadioButton rbIc;
        private System.Windows.Forms.RadioButton rbDis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaliyet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonGetRates;
        private System.Windows.Forms.TextBox textBoxEuro;
        private System.Windows.Forms.TextBox textBoxYen;
        private System.Windows.Forms.TextBox textBoxDolar;
        private System.Windows.Forms.TextBox textBoxDinar;
        private System.Windows.Forms.TextBox textBoxPound;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDöviz;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaxTemp;
        private System.Windows.Forms.TextBox txtMinTemp;
        private System.Windows.Forms.TextBox txtRuzgar;
        private System.Windows.Forms.TextBox txtNem;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblTemp2;
        private System.Windows.Forms.TextBox txtDogum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtBatim;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FlowLayoutPanel FLP;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

