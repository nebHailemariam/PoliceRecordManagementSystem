using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceCrimeReport
{
    public partial class creatCrimeInfo : Form
    {
        SqlConnection sqlConnection = null;
        public creatCrimeInfo()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
        }

        private void back_Click(object sender, EventArgs e)
        {
            string roleid = Login.currentUserRole;
            if (roleid == "1")
            {
                this.Hide();
                AdminHome adminhome = new AdminHome();
                adminhome.Show();

            }
            else if (roleid == "2")
            {
                this.Hide();
                ChiefPoliceView chief = new ChiefPoliceView();
                chief.Show();

            }
            else if (roleid == "3")
            {
                this.Hide();
                CommanderView commander = new CommanderView();
                commander.Show();

            }
            else if (roleid == "4")
            {
                this.Hide();
                OfficerView offiecerview = new OfficerView();
                offiecerview.Show();
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            string roleid = Login.currentUserRole;
            if (roleid == "1")
            {
                this.Hide();
                AdminHome adminhome = new AdminHome();
                adminhome.Show();

            }
            else if (roleid == "2")
            {
                this.Hide();
                ChiefPoliceView chief = new ChiefPoliceView();
                chief.Show();

            }
            else if (roleid == "3")
            {
                this.Hide();
                CommanderView commander = new CommanderView();
                commander.Show();

            }
            else if (roleid == "4")
            {
                this.Hide();
                OfficerView offiecerview = new OfficerView();
                offiecerview.Show();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO FinalCrimeReport(charges,sentence,guilty,PrisonName,firId) values (@charges, @sentence, @guilty, @prisonname,@firId)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            string charges_string = chargesvalue.Text;
            string sentence_string = Sentencevalue.Text;
            string guilty_string = guiltyvalue.Text;
            string prisonname_string = prisonNamevalue.Text;
            string firId_string = DocumentIdvalue.Text;

            try
            {
               
                sqlCommand.Parameters.AddWithValue("@charges", charges_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@sentence", sentence_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@guilty", guilty_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@prisonname", prisonname_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@firId", firId_string.Replace(" ", "_"));
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Information Created");
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}
