using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceCrimeReport
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void createUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCreateUser adminDashboard = new AdminCreateUser();
            adminDashboard.Show();
        }

        private void viewUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserList adminUserlist = new AdminUserList();
            adminUserlist.Show();

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminhome = new AdminHome();
            adminhome.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userList_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
