using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Stok_Takip_App
{
    public partial class Form1 : Form
    {        
        private readonly IServiceProvider _serviceProvider;
        public Form1()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            CheckForIllegalCrossThreadCalls = false;
            // Build service provider
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=stok;Uid=root;Pwd='';");
        int labelTop = 30;
        int txtTop = 30;
        int btnTop = 310;
        int num = 1;
        int cnt = 0;
        double dovizMaliyet = 0;

        private void button_Click(object sender, EventArgs e, GroupBox grp, Button btn)
        {
            if (cnt < 8)
            {
                Button btn2 = sender as Button;

                TextBox txt = new TextBox();
                txt.Name = "Textbox" + num;
                txt.Top = txtTop + 20;
                txt.Left = 20;
                txt.Font = new Font("Microsoft Sans Serif", 11);
                grp.Controls.Add(txt);

                TextBox txt_adet = new TextBox();
                txt_adet.Name = "Atxt" + num;
                txt_adet.Top = txtTop + 20;
                txt_adet.Left = 90 + txt.Width;
                txt_adet.Font = new Font("Microsoft Sans Serif", 11);
                grp.Controls.Add(txt_adet);

                labelTop += txt.Height + 5;
                txtTop += txt.Height + 5;
                num++;
                cnt++;
            }
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            txtMaliyet.Enabled = false;
            label6.Visible = false;
            label7.Visible = false;
            cmbDöviz.Enabled = false;
            var exchangeRateProvider = _serviceProvider.GetRequiredService<TcbExchangeRateProvider>();
            var exchangeRates = await exchangeRateProvider.GetCurrencyLiveRatesAsync("TRY");

            SetExchangeRates(exchangeRates);
            cmbDöviz.SelectedIndex = 0;
            getWeather("Ankara");
            txtCity.Text = "Ankara";
            //getForecast();
        }

        int checkCount = 0;
        private void rbKompleks_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKompleks.Checked)
            {
                label6.Visible=true;
                label7.Visible=true;
                if (checkCount == 0)
                {
                    checkCount++;
                    GroupBox grp = new GroupBox();
                    grp.Top = 200;
                    grp.Name = "Grpb";
                    grp.Left = 400;
                    grp.Text = "Kontroller";
                    grp.Size = new Size(320, 350);
                    grp.ForeColor = Color.White;
                    grp.FlatStyle = FlatStyle.Flat;
                    this.Controls.Add(grp);

                    TextBox txt = new TextBox();
                    txt.Name = "Textbox" + num;
                    txt.Top = txtTop + 20;
                    txt.Left = 20;
                    txt.Font = new Font("Microsoft Sans Serif", 11);
                    grp.Controls.Add(txt);
                    
                    TextBox txt_adet = new TextBox();
                    txt_adet.Name = "Atxt" + num;
                    txt_adet.Top = txtTop + 20;
                    txt_adet.Left = 90 + txt.Width;
                    txt_adet.Font = new Font("Microsoft Sans Serif", 11);
                    grp.Controls.Add(txt_adet);

                    labelTop += txt.Height + 5;
                    txtTop += txt.Height + 5;

                    Button btn2 = new Button();
                    btn2.Size = new Size(70, 27);
                    btn2.Text = "EKLE";
                    btn2.Name = "Button" + checkCount;
                    btn2.Top = btnTop;
                    btn2.Left = 120;
                    btn2.BackColor = Color.White;
                    btn2.ForeColor = Color.Black;
                    btn2.Click += (s, ev) => button_Click(s, ev, grp, btn2);
                    btn2.Parent = grp;
                    grp.Controls.Add(btn2);
                }

                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                    {
                        if (control.Name.StartsWith("Grpb"))
                        {
                            GroupBox dynamicGroup = (GroupBox)control;
                            dynamicGroup.Visible = true;
                        }
                        foreach (Control subControl in control.Controls)
                        {
                            if (subControl is TextBox && subControl.Name.StartsWith("Textbox"))
                            {
                                TextBox dynamicTextBox = (TextBox)subControl;
                                dynamicTextBox.Visible = true;
                            }
                            else if (subControl is Button && subControl.Name.StartsWith("Button"))
                            {
                                Button dynamicButton = (Button)subControl;
                                dynamicButton.Visible = true;
                            }
                            else if (subControl is Label && subControl.Name.StartsWith("Label"))
                            {
                                Label dynamicLabel = (Label)subControl;
                                dynamicLabel.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        string alimTipi;

        private void rbDis_CheckedChanged(object sender, EventArgs e)
        {
            txtMaliyet.Enabled = true;
            alimTipi = "dis";
            cmbDöviz.Enabled = true;
        }

        private void rbIc_CheckedChanged(object sender, EventArgs e)
        {
            txtMaliyet.Enabled = false;
            alimTipi = "ic";
            cmbDöviz.Enabled= false;
        }

        string urunTipi;
        DateTime vade;
        int m;
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var exchangeRateProvider = _serviceProvider.GetRequiredService<TcbExchangeRateProvider>();
            var exchangeRates = await exchangeRateProvider.GetCurrencyLiveRatesAsync("TRY");
            if(txtMaliyet.Text != "")
            {
                m = Convert.ToInt16(txtMaliyet.Text);
            }
            else
            {
                m = 0;
            }
            double tumMaliyet = calculateMaliyet(exchangeRates,m);
            if (rbTek.Checked)
            {
                urunTipi = "tek";
            }
            else if (rbKompleks.Checked)
            {
                urunTipi = "kompleks";
            }

            if (rbIc.Checked)
            {
                alimTipi = "ic";
            }
            else if (rbDis.Checked)
            {
                alimTipi = "dis";
            }

            vade = dtp1.Value.AddMonths(1);
            Console.WriteLine(vade);

            try
            {
                mysqlbaglan.Open();
                if (mysqlbaglan.State == ConnectionState.Open)
                {
                    int i = 1;
                }
                else
                {
                    MessageBox.Show("Veritabanı bağlantısı yapılamadı lütfen XAMPP uygulamasını açın ya da interneti kontrol edin!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (rbTek.Checked)
            {
                MySqlCommand SqlKomutu = new MySqlCommand("INSERT INTO stok_takip(urun_adi,urun_tipi,ic_dis,maliyet,alim_tarihi,vade_tarihi,alinan_firma,adet, currency) VALUES (@urun_adi,@urun_tipi,@ic_dis,@maliyet,@alim_tarihi,@vade_tarihi,@alinan_firma,@adet, @currency)", mysqlbaglan);
                SqlKomutu.Parameters.AddWithValue("@urun_adi", urunTxt.Text.ToUpper());
                SqlKomutu.Parameters.AddWithValue("@urun_tipi", urunTipi);
                SqlKomutu.Parameters.AddWithValue("@ic_dis", alimTipi);
                SqlKomutu.Parameters.AddWithValue("@maliyet", tumMaliyet);
                SqlKomutu.Parameters.AddWithValue("@alim_tarihi", dtp1.Value);
                SqlKomutu.Parameters.AddWithValue("@vade_tarihi", vade);
                SqlKomutu.Parameters.AddWithValue("@alinan_firma", txtFirma.Text.ToUpper());
                SqlKomutu.Parameters.AddWithValue("@adet", Convert.ToInt32(txtAdet.Text));
                SqlKomutu.Parameters.AddWithValue("@currency",cmbDöviz.Text);
                SqlKomutu.ExecuteNonQuery();
                MessageBox.Show("Veritabanına başarıyla kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rbKompleks.Checked)
            {
                MySqlCommand Sql_Stok_Takip = new MySqlCommand("INSERT INTO stok_takip(urun_adi,urun_tipi,ic_dis,maliyet,alim_tarihi,vade_tarihi,alinan_firma,adet,currency) VALUES (@urun_adi,@urun_tipi,@ic_dis,@maliyet,@alim_tarihi,@vade_tarihi,@alinan_firma,@adet,@currency)", mysqlbaglan);
                Sql_Stok_Takip.Parameters.AddWithValue("@urun_adi", urunTxt.Text.ToUpper());
                Sql_Stok_Takip.Parameters.AddWithValue("@urun_tipi", urunTipi);
                Sql_Stok_Takip.Parameters.AddWithValue("@ic_dis", alimTipi);
                Sql_Stok_Takip.Parameters.AddWithValue("@maliyet", tumMaliyet);
                Sql_Stok_Takip.Parameters.AddWithValue("@alim_tarihi", dtp1.Value);
                Sql_Stok_Takip.Parameters.AddWithValue("@vade_tarihi", vade);
                Sql_Stok_Takip.Parameters.AddWithValue("@alinan_firma", txtFirma.Text);
                Sql_Stok_Takip.Parameters.AddWithValue("@adet", Convert.ToInt16(txtAdet.Text));
                Sql_Stok_Takip.Parameters.AddWithValue("@currency", cmbDöviz.Text);
                Sql_Stok_Takip.ExecuteNonQuery();

                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox && control.Name == "Grpb")
                    {
                        string urunAdi = urunTxt.Text.ToUpper();

                        foreach (Control subControl in control.Controls)
                        {
                            if (subControl is TextBox)
                            {
                                if (subControl.Name.StartsWith("Textbox"))
                                {
                                    string komponentValue = ((TextBox)subControl).Text;
                                    TextBox adetTextBox = control.Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "Atxt" + subControl.Name.Substring(7));
                                    int adetValue = Convert.ToInt16(adetTextBox?.Text);

                                    try
                                    {
                                        using (MySqlCommand Sql_Komponentler = new MySqlCommand("INSERT INTO komponentler(urun_adi,komponent,adet) VALUES (@urun_adi,@komponent,@adet)", mysqlbaglan))
                                        {
                                            Sql_Komponentler.Parameters.AddWithValue("@urun_adi", urunAdi);
                                            Sql_Komponentler.Parameters.AddWithValue("@komponent", komponentValue);
                                            Sql_Komponentler.Parameters.AddWithValue("@adet", adetValue);
                                            Sql_Komponentler.ExecuteNonQuery();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Veritabanına eklenirken bir hata oluştu: " + ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Veritabanına başarıyla kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            mysqlbaglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 stok_rapor = new Form2();
            stok_rapor.Show();
            this.Hide();
        }

        private void rbTek_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            if (rbTek.Checked)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                    {
                        if (control.Name.StartsWith("Grpb"))
                        {
                            GroupBox dynamicGroup = (GroupBox)control;
                            dynamicGroup.Visible = false;
                        }
                        foreach (Control subControl in control.Controls)
                        {
                            if (subControl is TextBox && subControl.Name.StartsWith("Textbox"))
                            {
                                TextBox dynamicTextBox = (TextBox)subControl;
                                dynamicTextBox.Visible = false;
                            }
                            else if (subControl is Button && subControl.Name.StartsWith("Button"))
                            {
                                Button dynamicButton = (Button)subControl;
                                dynamicButton.Visible = false;
                            }
                            else if (subControl is Label && subControl.Name.StartsWith("Label"))
                            {
                                Label dynamicLabel = (Label)subControl;
                                dynamicLabel.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAdet.Clear();
            txtFirma.Clear();
            txtMaliyet.Clear();
            urunTxt.Clear();
            dtp1.ResetText();
            rbDis.Refresh();
            rbIc.Refresh();
            rbKompleks.Refresh();
            rbTek.Refresh();
            

            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {                   
                    foreach (Control subControl in control.Controls)
                    {
                        if (subControl is TextBox && subControl.Name.StartsWith("Textbox"))
                        {
                            TextBox adetTextBox = control.Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "Atxt" + subControl.Name.Substring(7));
                            TextBox dynamicTextBox = (TextBox)subControl;
                            dynamicTextBox.Clear();
                            adetTextBox.Clear();
                        }                      
                    }
                }
            }

        }
        #region DÖVİZ
        private static void ConfigureServices(IServiceCollection services)
        {
            // Configure logging
            services.AddLogging(configure => configure.AddConsole());

            // Register TcbExchangeRateProvider and other dependencies
            services.AddTransient<TcbExchangeRateProvider>();
        }
        private async void buttonGetRates_ClickAsync(object sender, EventArgs e)
        {
            var exchangeRateProvider = _serviceProvider.GetRequiredService<TcbExchangeRateProvider>();
            var exchangeRates = await exchangeRateProvider.GetCurrencyLiveRatesAsync("TRY");

            SetExchangeRates(exchangeRates);
            
        }

        private double calculateMaliyet(IList<ExchangeRate> exchangeRates, int maliyet)
        {
            dovizMaliyet=maliyet * Convert.ToDouble(GetExchangeRate(exchangeRates, cmbDöviz.Text));
            
            return dovizMaliyet;
        }

        private void SetExchangeRates(IList<ExchangeRate> exchangeRates)
        {
            textBoxDolar.Text = GetExchangeRate(exchangeRates, "USD").ToString();
            textBoxEuro.Text = GetExchangeRate(exchangeRates, "EUR").ToString();
            textBoxYen.Text = GetExchangeRate(exchangeRates, "JPY").ToString();
            textBoxPound.Text = GetExchangeRate(exchangeRates, "GBP").ToString();
            textBoxDinar.Text = GetExchangeRate(exchangeRates, "KWD").ToString();           
        }
        
        private decimal GetExchangeRate(IList<ExchangeRate> exchangeRates, string currencyCode)
        {
            var rate = exchangeRates.FirstOrDefault(r => r.CurrencyCode.Equals(currencyCode, StringComparison.InvariantCultureIgnoreCase));
            return rate != null ? rate.Value : 0;
        }
        #endregion
        #region HAVA DURUMU
        string apikey = "bbf881bdd01fc84531a09fd2b24d6974";
        //string apikey2 = "9872938e69bf51a2ef0c388de340b97c";
        private void button3_Click(object sender, EventArgs e)
        {
            getWeather(txtCity.Text);
           
        }
        
        void getWeather(string sehir)
        {
            using(WebClient wc = new WebClient())
            {
                string url = "https://api.openweathermap.org/data/2.5/weather?q="+sehir+"&appid="+apikey;
                var json = wc.DownloadString(url);
                HavaDurumu.root Info = JsonConvert.DeserializeObject<HavaDurumu.root>(json);

                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon +".png";
                lblTemp2.Text = Info.weather[0].main;
                txtDogum.Text = convertDateTime(Info.sys.sunrise).ToLocalTime().ToString("T");
                txtBatim.Text = convertDateTime(Info.sys.sunset).ToLocalTime().ToString("T");
                txtRuzgar.Text = Info.wind.speed.ToString();
                txtMaxTemp.Text = (Info.main.temp_max-273).ToString();
                txtMinTemp.Text = (Info.main.temp_min-273).ToString();
                lblTemp2.Text = (Info.main.temp-273).ToString() + "°";
                txtNem.Text = "%"+Info.main.humidity.ToString();
                

            }
        }
        
        DateTime convertDateTime(long milisec)
        {
            DateTime day =new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc).ToLocalTime();
            day= day.AddSeconds(milisec);
            return day;
        }
        #endregion
    }
}