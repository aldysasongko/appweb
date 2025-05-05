using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapi
{
    public partial class dasboard : Form
    {
        public dasboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open form to add cow data
            Tambah_data form2 = new Tambah_data();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open form to add feed data
            Tambah_pakan form3 = new Tambah_pakan();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Confirm logout and close the application or return to login form
            var result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close(); // or open LoginForm and hide this
            }
        }

    }
}
