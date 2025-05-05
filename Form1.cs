using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sapi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=;database=sapi;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Koneksi Berhasil!");

                    // Contoh query (misal, login)
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    string query = "SELECT * FROM tbuser WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login Berhasil!");
                                this.Hide(); // Menyembunyikan form login
                                dasboard form2 = new dasboard();
                                form2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Login Gagal!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Gagal: " + ex.Message);
                }
            }
        }

    }
}
