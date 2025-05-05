using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sapi
{
    public partial class Tambah_data : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=sapi;";
        private int selectedId = -1;

        public Tambah_data()
        {
            InitializeComponent();
        }

        private void Tambah_data_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM tbdaftarsapi";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = null;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbdaftarsapi (nama_sapi, berat_sebelum, berat_sesudah, rasio_sapi, grade_sapi) " +
                                   "VALUES (@nama, @sebelum, @sesudah, @rasio, @grade)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sebelum", float.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@sesudah", float.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@rasio", float.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@grade", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil disimpan!");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal simpan: " + ex.Message);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data yang ingin diedit terlebih dahulu.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tbdaftarsapi SET nama_sapi = @nama, berat_sebelum = @sebelum, " +
                                   "berat_sesudah = @sesudah, rasio_sapi = @rasio, grade_sapi = @grade WHERE id_sapi = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sebelum", float.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@sesudah", float.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@rasio", float.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@grade", textBox5.Text);
                    cmd.Parameters.AddWithValue("@id", selectedId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diubah!");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal edit: " + ex.Message);
                }
            }
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Pilih data yang ingin dihapus terlebih dahulu.");
                return;
            }

            var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?",
                                                "Konfirmasi Hapus",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM tbdaftarsapi WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil dihapus!");
                        LoadData();
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal hapus: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                selectedId = Convert.ToInt32(row.Cells["id_sapi"].Value);

                textBox1.Text = row.Cells["nama_sapi"].Value.ToString(); 
                textBox2.Text = row.Cells["berat_sebelum"].Value.ToString().Replace(" kg", "").Trim();
                textBox3.Text = row.Cells["berat_sesudah"].Value.ToString().Replace(" kg", "").Trim();
                textBox4.Text = row.Cells["rasio_sapi"].Value.ToString().Replace(" kg", "").Trim();
                textBox5.Text = row.Cells["grade_sapi"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            selectedId = -1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

    }
}
