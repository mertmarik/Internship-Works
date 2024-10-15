using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stok_Takip_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=stok;Uid=root;Pwd='';");

        private void Form2_Load(object sender, EventArgs e)
        {
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
                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            today.ToString("yyyy-mm-dd");
            MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip WHERE vade_tarihi < @vade_tarihi", mysqlbaglan);
            SqlKomutu.Parameters.AddWithValue("@vade_tarihi", today);
            MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            MySqlCommand SqlKomutu = new MySqlCommand("SELECT * FROM stok_takip WHERE urun_adi = @urun_adi", mysqlbaglan);
            SqlKomutu.Parameters.AddWithValue("@urun_adi", textBox1.Text.ToUpper());
            MySqlDataAdapter da = new MySqlDataAdapter(SqlKomutu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        int n = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            while (n < dataGridView1.SelectedRows.Count)
            {
                MySqlCommand SqlKomutu = new MySqlCommand("DELETE FROM stok_takip WHERE urun_adi='" + dataGridView1.SelectedRows[n].Cells["urun_adi"].Value.ToString() + "'", mysqlbaglan);
                SqlKomutu.ExecuteNonQuery();
                MySqlCommand SqlKomponent = new MySqlCommand("DELETE FROM komponentler WHERE urun_adi='" + dataGridView1.SelectedRows[n].Cells["urun_adi"].Value.ToString() + "'", mysqlbaglan);
                SqlKomponent.ExecuteNonQuery();
                n++;
            }
            MessageBox.Show("Başarıyla Silindi", "Silme");
            MySqlCommand SqlYenile = new MySqlCommand("SELECT * FROM stok_takip", mysqlbaglan);
            MySqlDataAdapter da = new MySqlDataAdapter(SqlYenile);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 stok_ekle = new Form1();
            stok_ekle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 urun_guncelle = new Form3();
            urun_guncelle.Show();
            this.Hide();
        }
    }
}