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
    public partial class Request : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Request(string str2)
        {
            InitializeComponent();
            label5.Text = str2;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();


                SqlCommand cmd2 = new SqlCommand("ShowProp", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("Username", label5.Text);
                cmd2.ExecuteNonQuery();


                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable tbl2 = new DataTable();
                sda2.Fill(tbl2);

                bool correctProp = false;

                for (int i = 0; i < tbl2.Rows.Count; i++)
                {
                    if (tbl2.Rows[i]["Property_ID"].ToString() == maskedTextBox1.Text)
                    {
                        correctProp = true;
                        break;
                    }
                }

                bool CompInfo = true;

                if (maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
                {
                    CompInfo = false;
                
                }


                if (correctProp == false || CompInfo == false)
                {
                    MessageBox.Show("Please Enter Correct Property ID And/Or Make Sure All Fields Are Complete");

                }

                else
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SendRequest", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@client_un", label5.Text);
                        cmd.Parameters.AddWithValue("@sdate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@edate", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@Hours", maskedTextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fee", maskedTextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@prop_id", maskedTextBox1.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Request Sent!");
                    }

                    catch {
                        MessageBox.Show("Please Make Sure That Hours Are Equal To Or Less Than 24");
                    
                    }
                }
                con.Close();
            
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }
    }
}
