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

    public partial class AddGuard : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public AddGuard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddGuard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin aD = new Admin();
            aD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Login where Username= '" + userName.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);
                bool AlreadyTaken = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    if (tbl.Rows[i][0].ToString() == userName.Text)
                    {
                        AlreadyTaken = true;
                        break;
                    }

                }
                if (firstName.Text == "" || lastName.Text == "" || age.Text == "" || height.Text == "" ||weight.Text=="" || userName.Text == "" || password.Text == "" )
                {
                    MessageBox.Show("Please Enter All Required Fields");
                }
                if (AlreadyTaken == true)
                {
                    MessageBox.Show("Username Already Taken");
                }
                else {
                    SqlCommand cmd = new SqlCommand("AddGuard", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName",firstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", lastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", age.Text.Trim());
                    cmd.Parameters.AddWithValue("@Height", height.Text.Trim());
                    cmd.Parameters.AddWithValue("@Weight", weight.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", userName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Guard is Successfully Added");                
                
                }
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
