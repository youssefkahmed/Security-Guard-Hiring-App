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
    public partial class DeleteGuard : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public DeleteGuard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ShowGuards", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                sda.Fill(tbl);

                SqlCommand cmd2 = new SqlCommand("DeleteGuard", con);
                cmd2.CommandType = CommandType.StoredProcedure;
               
                bool found = false;

                for (int i = 0; i < tbl.Rows.Count; i++)
                {

                    if (tbl.Rows[i][8].ToString() == textBox1.Text)
                    {
                        found = true;
                        break;
                    }

                }


                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter The Username Of The Guard You Would Like To Delete");


                if (found == true)
                {
                    try
                    {
                        cmd2.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Guard Is Successfully Deleted");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot Delete A Guard Under Contract!");
                    }
                }

                else {
                    MessageBox.Show("Guard Not Found");
                }

                this.Hide();
                Admin ad = new Admin();
                ad.Show();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteGuard_Load(object sender, EventArgs e)
        {

        }
    }
}
