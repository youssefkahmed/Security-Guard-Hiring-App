using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Guard : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Guard(string str2)
        {
            InitializeComponent();
            showusrnm.Text = str2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Guard_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                if (Availability.Checked)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Guard SET Availability = 1 WHERE G_UN = '"+showusrnm.Text+"'", con);
                    cmd.ExecuteNonQuery();

                }


                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Guard SET Availability = 0 WHERE G_UN = '" + showusrnm.Text + "'", con);
                    cmd.ExecuteNonQuery();
                }




                con.Close();




            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchRequests", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login L = new Login();
            L.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AcceptRequest a = new AcceptRequest(showusrnm.Text);
            a.Show();
        }

        private void showusrnm_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
