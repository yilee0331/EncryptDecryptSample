using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace EncryptDecryptSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "<name> 가나다라 ABCDE 12345 &_^%# 李無松";
            textBox6.Text = "<name> 가나다라 ABCDE 12345 &_^%# 李無松";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AES enc = new AES();
            textBox2.Text = enc.AESEncrypt256(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AES enc = new AES();
            textBox3.Text = enc.AESDecrypt256(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AESSalt enc = new AESSalt();
            textBox5.Text = enc.Encrypt(textBox6.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AESSalt enc = new AESSalt();
            textBox4.Text = enc.Decrypt(textBox5.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;

            AES enc = new AES();
            strConn = enc.AESDecrypt256(strConn);

            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(strConn);
                cmd.CommandText = "select *from Categories";

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
