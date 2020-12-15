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
    public partial class UpdateRequest : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public UpdateRequest(string str2)
        {
            InitializeComponent();

            showusrnm.Text = str2;

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ShowContracts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", showusrnm.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;

                con.Close();
            }  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateRequest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("CheckUpdateContract", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@c_un", showusrnm.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                bool correctConID = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (tbl.Rows[i]["Contract_ID"].ToString() == maskedTextBox6.Text.Trim())
                    {
                        correctConID = true;
                        break;
                    }
                }

                // checking if contract id is correct 

                SqlCommand cmd2 = new SqlCommand("ShowProp", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("Username", showusrnm.Text);
                cmd2.ExecuteNonQuery();


                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable tbl2 = new DataTable();
                sda2.Fill(tbl2);          

                bool correctProp = false;

                for (int i = 0; i < tbl2.Rows.Count; i++)
                {
                    if (tbl2.Rows[i]["Property_ID"].ToString() == maskedTextBox1.Text.Trim())
                    {
                        correctProp = true;
                        break;
                    }
                }

                // checking if property id is correct


                bool CompInfo = true;

                if (maskedTextBox2.Text.Trim() == "" || maskedTextBox3.Text.Trim() == "")
                {
                    CompInfo = false;

                }


                if (correctConID == false || correctProp == false || CompInfo == false)
                {
                    MessageBox.Show("Please Enter Correct Property ID, Correct ID And/Or Make Sure All Fields Are Complete!");

                }

                else
                {
                    try
                    {
                        SqlCommand cmd3 = new SqlCommand("UpdateRequest", con);
                        cmd3.CommandType = CommandType.StoredProcedure;

                        cmd3.Parameters.AddWithValue("@con_id", maskedTextBox6.Text.Trim());
                        cmd3.Parameters.AddWithValue("@sdate", dateTimePicker1.Value);      
                        cmd3.Parameters.AddWithValue("@edate", dateTimePicker2.Value);
                        cmd3.Parameters.AddWithValue("@Hours", maskedTextBox2.Text.Trim());
                        cmd3.Parameters.AddWithValue("@Fee", maskedTextBox3.Text.Trim());
                        cmd3.Parameters.AddWithValue("@prop_id", maskedTextBox1.Text.Trim());
                        cmd3.ExecuteNonQuery();

                        MessageBox.Show("Request Updated!");
                    }

                    catch
                    {
                        MessageBox.Show("Please Make Sure That Hours Are Equal To Or Less Than 24");

                    }
                }
             


                    con.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("CheckDeleteContract", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@c_un", showusrnm.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                bool correctConID = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (tbl.Rows[i]["Contract_ID"].ToString() == maskedTextBox4.Text.Trim())
                    {
                        correctConID = true;
                        break;
                    }
                }


                if (correctConID == false)
                {
                    MessageBox.Show("Please Enter Correct ID");
                }

                else
                {
                    SqlCommand cmd2 = new SqlCommand("DeleteRequest", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@con_id", maskedTextBox4.Text.Trim());
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Request Successfully Deleted!");

                }

            }
        }
    }
}
