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
    public partial class CommanderView : Form
    {
        public CommanderView()
        {
            InitializeComponent();
        }

        private void fir_doc_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirstInformationReportsView firstInformationReportsView = new FirstInformationReportsView();
            firstInformationReportsView.Show();
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

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crimereport_Click(object sender, EventArgs e)
        {
            this.Hide();
            creatCrimeInfo cci = new creatCrimeInfo();
            cci.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            criminalList clist = new criminalList();
            clist.Show();
        }

        private void schedule_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
