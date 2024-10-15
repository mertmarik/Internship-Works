using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace to_do_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                 Pazartesi.Items.Add(richTextBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                 Sali.Items.Add(richTextBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Çarşamba.Items.Add(richTextBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Perşembe.Items.Add(richTextBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                Cuma.Items.Add(richTextBox1.Text);
            }
            richTextBox1.Clear();
        }
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string dosya_yolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop", "Haftalık.txt");
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            int pazartesiy = Pazartesi.Items.Count;
            int saliy = Sali.Items.Count;
            int carsambay = Çarşamba.Items.Count;
            int persembey = Perşembe.Items.Count;
            int cumay = Cuma.Items.Count;
            while (i < pazartesiy)
            {
                sw.WriteLine("Pazartesi: "+Pazartesi.Items[i].ToString());
                MessageBox.Show("Pazartesi Eklendi");
                i++;
            }
            i = 0;
            while (i < saliy)
            {
                sw.WriteLine("Salı : "+Sali.Items[i].ToString());
                MessageBox.Show("Salı Eklendi");
                i++;
            }
            i = 0;
            while (i < carsambay)
            {
                sw.WriteLine("Çarşamba : "+Çarşamba.Items[i].ToString());
                MessageBox.Show("Çarşamba Eklendi");
                i++;
            }
            i = 0;
            while (i < persembey)
            {
                sw.WriteLine("Perşembe : "+Perşembe.Items[i].ToString());
                MessageBox.Show("Perşembe Eklendi");
                i++;
            }
            i = 0;
            while (i < cumay)
            {
                sw.WriteLine("Cuma : "+Cuma.Items[i].ToString());
                MessageBox.Show("Cuma Eklendi");
                i++;
            }
            i = 0;


            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}

