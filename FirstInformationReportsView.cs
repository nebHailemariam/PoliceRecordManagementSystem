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
    public partial class FirstInformationReportsView : Form
    {
        SqlConnection sqlConnection = null;
        public FirstInformationReportsView()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
            InitializeComponent();
            InitalizeFIRListBox();


        }
      
        private void Create_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateFirstInformationReportView createFirstInformationReportView = new CreateFirstInformationReportView();
            createFirstInformationReportView.Show();
        }

        private void InitalizeFIRListBox()
        {
            userListView.Clear();
            userListView.Refresh();



            string query = "Select * from FirstInformationReport";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            userListView.View = View.Details;
            userListView.FullRowSelect = true;

            userListView.Sorting = System.Windows.Forms.SortOrder.Ascending;

            userListView.Columns.Add("Identification", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Crime Type", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Crime Description", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Place of Offense", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Offense Date", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Offense Time", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Report Date", -2, HorizontalAlignment.Left);



            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                int num = 1;
                while (reader.Read())
                {
                    String username = Convert.ToString(reader["CrimeType"]);
                    String docId = Convert.ToString(reader["Id"]);
                    String firstname = Convert.ToString(reader["CrimeDescription"]);
                    String lastname = Convert.ToString(reader["PlaceOfOffense"]);
                    String phonenumber = Convert.ToString(reader["offenseDate"]);
                    String email = Convert.ToString(reader["offenseTime"]);
                    String status = Convert.ToString(reader["reportDate"]);
                    Console.WriteLine(username + " " + firstname + " " + lastname + " " + phonenumber + " " + email + " " + status);
                    ListViewItem item = new ListViewItem();


                    item.Text = docId;
                    item.SubItems.Add(username);
                    item.SubItems.Add(firstname);
                    item.SubItems.Add(lastname);

                    item.SubItems.Add(phonenumber);
                    item.SubItems.Add(email);
                    item.SubItems.Add(status);
                    //userListView.Items.Add(item);
                    userListView.Items.AddRange(new ListViewItem[] { item });
                    num++;

                }
            }

        }

        private void Info_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateInformation ci = new CreateInformation();
            ci.Show();
        }

        private void Back_Click(object sender, EventArgs e)
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

        private void viewinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            InformationList ilist = new InformationList();
            ilist.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}
