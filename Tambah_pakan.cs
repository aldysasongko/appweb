using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sapi
{
    public partial class Tambah_pakan : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=sapi;";
        private int selectedId = -1;

        public Tambah_pakan()
        {
            InitializeComponent();
        }

        private void Tambah_pakan_Load(object sender, EventArgs e)
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
                    string query = "SELECT * FROM tbdaftarpakan";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void simpan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tbdaftarpakan (jenis_pakan, jumlah_pakan, pakan_perhari) VALUES (@jenis, @jumlah, @perhari)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@jenis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@jumlah", float.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@perhari", float.Parse(textBox3.Text));
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
                    string query = "UPDATE tbdaftarpakan SET jenis_pakan = @jenis, jumlah_pakan = @jumlah, pakan_perhari = @perhari WHERE id_pakan = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@jenis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@jumlah", float.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@perhari", float.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@id", selectedId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diedit!");
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

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM tbdaftarpakan WHERE id_pakan = @id";
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

                selectedId = Convert.ToInt32(row.Cells["id_pakan"].Value);
                
                textBox1.Text = row.Cells["jenis_pakan"].Value.ToString();
                textBox2.Text = row.Cells["jumlah_pakan"].Value.ToString().Replace(" kg", "").Trim();
                textBox3.Text = row.Cells["pakan_perhari"].Value.ToString().Replace(" kg/sapi", "").Trim();
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            selectedId = -1;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
