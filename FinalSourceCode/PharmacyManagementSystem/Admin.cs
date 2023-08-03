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

namespace PharmacyManagementSystem
{
    public partial class Admin : Form
    {
        int flagTag = 0;
        public Admin()
        {
            InitializeComponent();
        }

        public Admin(string s)
        {
            InitializeComponent();
            adminLabelText.Text = s;
        }

        public void showTable(string s)
        {
            string conString = "Data Source=DESKTOP-KU8ITD4\\SQLEXPRESS01;Initial Catalog=PBSdb;User ID=sa;Password=asdf1234";
            string query = s;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = conString;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
        }

        private void exitAdmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 admToLog = new Form1();
            admToLog.Show();
            this.Hide();
        }

        private void btnAddPharmacist_Click(object sender, EventArgs e)
        {
            NewPharmacist anf = new NewPharmacist();
            anf.Show();
            this.Hide();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            NewAdmin cna = new NewAdmin();
            cna.Show();
            this.Hide();
        }

        private void btnResolveIssues_Click(object sender, EventArgs e)
        {
            string query = "select * from Issues";
            showTable(query);
        }

        private void btnAdminList_Click(object sender, EventArgs e)
        {
            string query = "select Name, Post, Phone, Email from AdminInfo";
            showTable(query);
            flagTag = 1;
        }

        private void btnPharmacyList_Click(object sender, EventArgs e)
        {
            string query = "select OwnerName, NID, ShopName, Contact, Location, Email from PharmacistInfo";
            showTable(query);
            flagTag = 2;
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            string query = "select Name, DOB, Mobile, Email, UserName from UserInfo";
            showTable(query);
            flagTag = 3;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (flagTag == 0)
            {
                MessageBox.Show("Select a table first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (flagTag == 1)
            {
                string conString = "Data Source=DESKTOP-KU8ITD4\\SQLEXPRESS01;Initial Catalog=PBSdb;User ID=sa;Password=asdf1234";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = "select * from AdminInfo where Name=@name";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@name", searchTextBox.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (flagTag == 2)
            {
                string conString = "Data Source=DESKTOP-KU8ITD4\\SQLEXPRESS01;Initial Catalog=PBSdb;User ID=sa;Password=asdf1234";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = "select * from PharmacistInfo where ShopName=@shopname";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@shopname", searchTextBox.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (flagTag == 3)
            {
                string conString = "Data Source=DESKTOP-KU8ITD4\\SQLEXPRESS01;Initial Catalog=PBSdb;User ID=sa;Password=asdf1234";
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = "select * from UserInfo where UserName=@username";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", searchTextBox.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Something is wrong");
            }
        }
    }
}
