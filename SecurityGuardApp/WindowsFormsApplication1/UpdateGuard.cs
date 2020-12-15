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
    public partial class UpdateGuard : Form
    {
        SqlDataAdapter DataAd;
        SqlCommandBuilder cmb;
        SqlConnection con;
        DataTable tbl;
        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True";     

        public UpdateGuard()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                con = new SqlConnection(str);
            
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateGuard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Guard_Id", guardID.Text.Trim());
                cmd.ExecuteNonQuery();
                DataAd = new SqlDataAdapter(cmd);
                tbl = new DataTable();
                DataAd.Fill(tbl);
                dataGridView1.DataSource = tbl;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();        
        }

        private void UpdateGuard_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmb = new SqlCommandBuilder(DataAd);
                DataAd.Update(tbl);
                MessageBox.Show("Information Successfully Updated");

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
