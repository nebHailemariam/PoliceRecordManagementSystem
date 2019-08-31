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
    public partial class InformationList : Form
    {
        SqlConnection sqlConnection = null;
        public InformationList()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
            InitializeComponent();
            InitalizeUserListBox();
        }
        private void InitalizeUserListBox()
        {
            userListView.Clear();
            userListView.Refresh();



            string query = "Select * from information";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
            userListView.CheckBoxes = true;
       


            userListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            userListView.Columns.Add("Id", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("First Name", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Address", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Age", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("PhoneNumber", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Identification", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Owner Type", -2, HorizontalAlignment.Left);

            using (SqlDataReader reader12 = sqlCommand.ExecuteReader())
            {

                while (reader12.Read())
                {
                    String firstname_string = Convert.ToString(reader12["firstname"]);
                    String lastname_string = Convert.ToString(reader12["lastname"]);
                    String address_string = Convert.ToString(reader12["AddressInfo"]);
                    String age_string = Convert.ToString(reader12["age"]);
                    String phoneNumber_string = Convert.ToString(reader12["phoneNumber"]);
                    String id_string = Convert.ToString(reader12["Id"]);
                    string owner_string = Convert.ToString(reader12["ownerType"]);
                   
                    ListViewItem item = new ListViewItem();
                    // Console.WriteLine(username + " " + firstname + " " + lastname + " " + phonenumber + " " + email + " " + status);

                    item.Text = id_string;
                    item.SubItems.Add(firstname_string);
                    item.SubItems.Add(lastname_string);

                    item.SubItems.Add(address_string);
                    item.SubItems.Add(phoneNumber_string);
                    item.SubItems.Add(id_string);
                    item.SubItems.Add(owner_string);

                    //userListView.Items.Add(item);
                    userListView.Items.AddRange(new ListViewItem[] { item });


                }
            }

        }
        private void userList_Click(object sender, EventArgs e)
        {

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

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.Show();
        }
    }
}
