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
    public partial class AddProp : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public AddProp(string str2)
        {
            InitializeComponent();
            label1.Text = str2;

        }

        private void AddProp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT C_ID FROM Client WHERE C_UN = '" + label1.Text + "'", con);
                cmd.CommandType = CommandType.Text;

                SqlCommand cmd2 = new SqlCommand("AddProp", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = (int)rdr["C_ID"];
                    cmd2.Parameters.AddWithValue("@Address", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@Type", comboBox1.SelectedItem.ToString());
                    cmd2.Parameters.AddWithValue("@c_id", id);               
                }

                rdr.Close();
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Property Successfully Added!");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        
     }

}