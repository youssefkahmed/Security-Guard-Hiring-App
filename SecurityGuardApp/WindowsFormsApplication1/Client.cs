using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class Client : Form
    {
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Client(string str2)
        {
            InitializeComponent();
            showusrnm.Text = str2;

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchGuard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                sda.Fill(tbl);

                dataGridView1.DataSource = tbl;

                con.Close();
            }   

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SearchGuard", con);
                cmd.CommandType = CommandType.StoredProcedure;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Request r = new Request(showusrnm.Text);
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddProp a = new AddProp(showusrnm.Text);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ShowProp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Username", showusrnm.Text));
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable tbl = new DataTable();

                sda.Fill(tbl);

                dataGridView2.DataSource = tbl;

                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login L = new Login();
            L.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateRequest ur = new UpdateRequest(showusrnm.Text);
            ur.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            RateGuard rg = new RateGuard(showusrnm.Text);
            rg.Show();
        }
    }
}
