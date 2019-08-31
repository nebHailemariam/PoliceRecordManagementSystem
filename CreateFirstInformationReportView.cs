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
namespace PoliceCrimeReport
{
    public partial class CreateFirstInformationReportView : Form
    {
        SqlConnection sqlConnection = null;
        public CreateFirstInformationReportView()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO FirstInformationReport(Station, officer,CrimeType, CrimeDescription, PlaceOfOffense," +
                " offenseDate" +
                ", offenseTime, reportDate) values (@Station, @officer, @CrimeType, @CrimeDescription, @PlaceOfOffense," +
                " @offenseDate, @offenseTime, @reportDate)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            string crimetype_string = crimetype.Text;
            string crimedescription_string = crimedescription.Text;
            string placeofoffense_string = placeofoffense.Text;
            string offencedate_string = offencedate.Text;
            string offencetime_string = offencetime.Text;
            string reportdate_string = reportdate.Text;
            string officer_string = Login.currentUserId;
            try
            {
                sqlCommand.Parameters.AddWithValue("@Station", "2");
                sqlCommand.Parameters.AddWithValue("@officer", officer_string.Replace(" ","_"));
                sqlCommand.Parameters.AddWithValue("@CrimeType", crimetype_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@CrimeDescription", crimedescription_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@PlaceOfOffense", placeofoffense_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@offenseDate", offencedate_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@offenseTime", offencetime_string.Replace(" ", "_"));
                sqlCommand.Parameters.AddWithValue("@reportDate", reportdate_string.Replace(" ", "_"));
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Report Created");
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirstInformationReportsView firv = new FirstInformationReportsView();
            firv.Show();
        }

        private void addinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateInformation ci = new CreateInformation();
            ci.Show();
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

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}