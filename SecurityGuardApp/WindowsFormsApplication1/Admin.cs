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
    public partial class Admin : Form
    {

        string str = "Data Source=DESKTOP-IKV1FT9\\SQLEXPRESS;Initial Catalog=SecGuardSystem;Integrated Security=True"; 

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
           
        }

        private void showGuards_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("ShowGuards", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DataAd = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                DataAd.Fill(tbl);
                dataGridView1.DataSource = tbl;
                con.Close();
            }
        }

        private void addGuard_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddGuard aG = new AddGuard();
            aG.Show();
        }

        private void deleteGuard_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }

        private void deleteGuard_Click_1(object sender, EventArgs e)
        {
                DeleteGuard dG = new DeleteGuard();
                dG.Show();
            
        }

        private void updateGuard_Click(object sender, EventArgs e)
        {
            UpdateGuard ug = new UpdateGuard();
            ug.Show();
        }
    }
}
