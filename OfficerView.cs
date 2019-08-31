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
    public partial class OfficerView : Form
    {
        public OfficerView()
        {
            InitializeComponent();
        }

        private void fir_doc_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirstInformationReportsView firstInformationReportsView = new FirstInformationReportsView();
            firstInformationReportsView.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            criminalList clist = new criminalList();
            clist.Show();
        }

        private void crimereport_Click(object sender, EventArgs e)
        {
            this.Hide();
            creatCrimeInfo cci = new creatCrimeInfo();
            cci.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}
