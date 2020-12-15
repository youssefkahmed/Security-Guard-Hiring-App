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
    public partial class AcceptRequest : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public AcceptRequest(string str2)
        {
            InitializeComponent();
            showusrnm.Text = str2;

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AcceptedRequests", con);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("g_un", showusrnm.Text.Trim());
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();

                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;

                con.Close();
            }
        

        }

        private void ShowRequests_Load(object sender, EventArgs e)
        {

        }

        private void showusrnm_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("SearchRequests", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);
            
                bool correctID = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    if (tbl.Rows[i]["Contract_ID"].ToString() == maskedTextBox1.Text.Trim())
                    {
                        correctID = true;
                        break;
                    }

                }

                if (correctID == true)
                {
                    SqlCommand cmd2 = new SqlCommand("AcceptRequest", con);
                    cmd2.CommandType = CommandType.StoredProcedure;                   
                    cmd2.Parameters.AddWithValue("@g_un", showusrnm.Text);
                    cmd2.Parameters.AddWithValue("@con_id", maskedTextBox1.Text.Trim());
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Contract Successfully Accepted!");
                    

                }

                else {
                    MessageBox.Show("Please Check That The Contract ID You Entered Is Correct");
                 
                }

                con.Close();


            }

        }
    }
}
