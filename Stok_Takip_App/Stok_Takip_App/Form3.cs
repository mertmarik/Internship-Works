using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Stok_Takip_App
{
    public partial class Form3 : Form
    {
     
        public Form3()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

       

        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=stok;Uid=root;Pwd='';");

        private void Form3_Load(object sender, EventArgs e)
        {
            btnKompGuncel.Enabled = false;  
            button3.Visible = false;
            groupBox3.Visible = false;
            btnGuncelle.Enabled = false;
            try
            {
                mysqlbaglan.Open();
                if (mysqlbaglan.State != ConnectionState.Closed)
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

            MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip", mysqlbaglan);
            MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            mysqlbaglan.Close();
        }

        int i = 0;
        int j = 0;
        int k = 0;
        int txtTop = 4;
        int counter = 0;
        List<string> komponentList = new List<string>();

        private void button_Click_Guncelle(object s, EventArgs ev, GroupBox grp)
        {
            mysqlbaglan.Open();
            MySqlCommand komut = new MySqlCommand("UPDATE stok_takip SET komponent=@komponent, adet=@adet WHERE urun_adi=@urun_adi", mysqlbaglan);
            komut.Parameters.AddWithValue("@urun_adi", txtUrun.Text);
            komut.Parameters.AddWithValue("@komponent", cmbTip.Text);
            komut.Parameters.AddWithValue("@adet", Convert.ToInt16(txtMaliyet.Text));

        }
           
        int clickCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (clickCount == 0)
            {
                button3.Visible = true;
                groupBox3.Visible = true;
                button1.Text = "Stoğu Güncelle";
                #region Tablo Doldurma
                groupBox2.Visible = false;
                btnGuncelle.Visible = false;
                button2.Visible = false;
                MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM komponentler", mysqlbaglan);
                MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                mysqlbaglan.Close();
                #endregion

                clickCount = 1;
            }
            else if(clickCount == 1)
            {
                button3.Visible = false;
                groupBox3.Visible = false;
                button1.Text = "Komponentleri Güncelle";
                groupBox2.Visible = true;
                btnGuncelle.Visible = true;
                button2.Visible = true;
               
                mysqlbaglan.Open();
                MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip", mysqlbaglan);
                MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                mysqlbaglan.Close();
                clickCount = 0;
            }
        }

        int n = 0;
        List<string> urunList = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
            while (n < dataGridView1.SelectedRows.Count)
            {
                mysqlbaglan.Open();
                string urunAdi = dataGridView1.SelectedRows[n].Cells["urun_adi"].Value.ToString();
                MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip WHERE urun_adi = @urunAdi", mysqlbaglan);
                SqlKomutu.Parameters.AddWithValue("@urunAdi", urunAdi);

                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlKomutu);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                mysqlbaglan.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    urunList.Add(row["urun_adi"].ToString());
                    urunList.Add(row["urun_tipi"].ToString());
                    urunList.Add(row["ic_dis"].ToString());
                    urunList.Add(row["maliyet"].ToString());
                    urunList.Add(row["alim_tarihi"].ToString());
                    urunList.Add(row["vade_tarihi"].ToString());
                    urunList.Add(row["alinan_firma"].ToString());
                    urunList.Add(row["adet"].ToString());
                    urunList.Add(row["id"].ToString());
                }
                n++;
            }

            txtUrun.Text = urunList[0];
            cmbTip.Text = urunList[1];
            cmbAlim.Text = urunList[2];
            txtMaliyet.Text = urunList[3];
            DateTime alimDate = DateTime.Parse(urunList[4]);
            DateTime vadeDate = DateTime.Parse(urunList[5]);
            dtpAlim.Value = alimDate;
            dtpVade.Value = vadeDate;
            txtFirma.Text = urunList[6];
            txtAdet.Text = urunList[7];
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            mysqlbaglan.Open();
            MySqlCommand komut = new MySqlCommand("UPDATE stok_takip SET urun_adi=@urun_adi, urun_tipi=@urun_tipi, ic_dis=@ic_dis, maliyet=@maliyet, alim_tarihi=@alim_tarihi, vade_tarihi=@vade_tarihi, alinan_firma=@alinan_firma, adet=@adet WHERE id=@id", mysqlbaglan);
            komut.Parameters.AddWithValue("@urun_adi", txtUrun.Text);
            komut.Parameters.AddWithValue("@urun_tipi", cmbTip.Text);
            komut.Parameters.AddWithValue("@ic_dis", cmbAlim.Text);
            komut.Parameters.AddWithValue("@maliyet", Convert.ToInt16(txtMaliyet.Text));
            komut.Parameters.AddWithValue("@alim_tarihi", dtpAlim.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@vade_tarihi", dtpVade.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@alinan_firma", txtFirma.Text);
            komut.Parameters.AddWithValue("@adet", Convert.ToInt16(txtAdet.Text));
            komut.Parameters.AddWithValue("@id", Convert.ToInt16(urunList[8]));
            komut.ExecuteNonQuery();
            mysqlbaglan.Close();

            MessageBox.Show("Güncellendi");

            MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip", mysqlbaglan);
            MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            if (txtUrun.Text != urunList[0])
            {
                mysqlbaglan.Open();
                MySqlCommand komponentUpdate = new MySqlCommand("UPDATE komponentler SET urun_adi=@urun_adi WHERE urun_adi=@eski_urun_adi", mysqlbaglan);
                komponentUpdate.Parameters.AddWithValue("@urun_adi", txtUrun.Text);
                komponentUpdate.Parameters.AddWithValue("@eski_urun_adi", urunList[0]);
                komponentUpdate.ExecuteNonQuery();
                mysqlbaglan.Close();
                MessageBox.Show("Komponentler Güncellendi");
            }
        }

        private void btnKompGuncel_Click(object sender, EventArgs e)
        {
            mysqlbaglan.Open();
            MySqlCommand komponentUpdate = new MySqlCommand("UPDATE komponentler SET komponent=@komponent , adet=@adet WHERE id = @id", mysqlbaglan);
            komponentUpdate.Parameters.AddWithValue("@komponent", txtKomponent.Text);
            komponentUpdate.Parameters.AddWithValue("@id", komponentList[3]);
            komponentUpdate.Parameters.AddWithValue("@adet",Convert.ToInt16(txt_adet.Text));
            komponentUpdate.ExecuteNonQuery();
            mysqlbaglan.Close();
            MessageBox.Show("Komponentler Güncellendi");
            mysqlbaglan.Open();
            MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM komponentler", mysqlbaglan);
            MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mysqlbaglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnKompGuncel.Enabled = true;
            while (n < dataGridView1.SelectedRows.Count)
            {
                mysqlbaglan.Open();
                string urunAdi = dataGridView1.SelectedRows[n].Cells["urun_adi"].Value.ToString();
                MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM komponentler WHERE urun_adi = @urunAdi", mysqlbaglan);
                SqlKomutu.Parameters.AddWithValue("@urunAdi", urunAdi);

                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlKomutu);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                mysqlbaglan.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    komponentList.Add(row["urun_adi"].ToString());
                    komponentList.Add(row["komponent"].ToString());
                    komponentList.Add(row["adet"].ToString());
                    komponentList.Add(row["id"].ToString());
                }
                n++;
            }

            label9.Text = komponentList[0];
            txtKomponent.Text = komponentList[1];
            txt_adet.Text = komponentList[2];         
        }
    }
}
