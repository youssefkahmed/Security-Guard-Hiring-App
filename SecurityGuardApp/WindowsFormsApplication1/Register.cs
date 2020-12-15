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
    public partial class Register : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Login where Username= '" + username.Text + "'", con);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);
                bool AlreadyTaken = false;

                for (int i = 0; i < tbl.Rows.Count; i++)

                {
              
                    if (tbl.Rows[i][0].ToString() == username.Text)
                    { AlreadyTaken = true;
                    break;
                    }
                
                }

                    if (FirstName.Text == "" || LastName.Text == "" || Phone.Text == "" || E_mail.Text == "" || username.Text == "" || password.Text == "")
                    {
                        MessageBox.Show("Please Enter All Required Fields");
                    }

                    if (password.Text != ConPassword.Text)
                    {
                        MessageBox.Show("Passwords Do Not Match");
                    }

                    if (AlreadyTaken == true)
                    { MessageBox.Show("Username Already Taken"); }

                    else
                    {
                        SqlCommand cmd = new SqlCommand("RegisterClient", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstName", FirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@lastName", LastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", Phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", E_mail.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registration Successful");

                        this.Hide();
                        Choice c = new Choice();
                        c.Show();

                    }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Choice c = new Choice();
            c.Show();
        }
    }
}
