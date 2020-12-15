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
    public partial class RateGuard : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True";

        public RateGuard(string str2)
        {
            InitializeComponent();
            showusrnm.Text = str2;

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CanRateGuards",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@c_un", showusrnm.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RateGuard_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CanRateGuards", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@c_un", showusrnm.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                bool correctGuard = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (tbl.Rows[i]["guard_un"].ToString() == textBox1.Text.Trim())
                    {
                        correctGuard = true;
                        break;
                    }

                }

                if (correctGuard == true)
                {
                    SqlCommand cmd2 = new SqlCommand("RateGuard", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@g_un", textBox1.Text.Trim());
                    cmd2.Parameters.AddWithValue("@rating", comboBox1.SelectedItem);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Guard Rated Successfully");
                }

                else {
                    MessageBox.Show("Please Enter Correct Guard Username From The List Below");
                }

            }
        }
    }
}
