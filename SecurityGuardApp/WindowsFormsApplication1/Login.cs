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
    public partial class Login : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'secGuardSystemDataSet.Client' table. You can move, or remove it, as needed.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select * from Login where Username='" + textBox1.Text + "' and Password= '" + textBox2.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            sda.Fill(tbl);

            string usertypeValue = comboBox1.SelectedItem.ToString();

            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    if (tbl.Rows[i][2].ToString() == usertypeValue)
                    {
                        MessageBox.Show("Successfully Logged In As " + tbl.Rows[i][2]);

                        if (comboBox1.SelectedIndex == 0)
                        {
                            this.Hide();
                            Client c = new Client(textBox1.Text);
                            c.Show();

                        }

                        else if (comboBox1.SelectedIndex == 1)
                        {
                            this.Hide();
                            Guard g = new Guard(textBox1.Text);
                            g.Show();
                        }

                        else {

                            this.Hide();
                            Admin a = new Admin();
                            a.Show();
                        
                        }

                    }



                }


            }

            else { MessageBox.Show("Check Username or Password or User Type"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Choice c = new Choice();
            c.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
