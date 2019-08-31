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
    public partial class criminalList : Form
    {
        SqlConnection sqlConnection = null;
        public criminalList()
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



            string query = "Select * from FinalCrimeReport";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
           

            userListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            userListView.Columns.Add("Id", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Charges", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Sentences", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Guilty", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("PrisonName", -2, HorizontalAlignment.Left);
   
            using (SqlDataReader reader12 = sqlCommand.ExecuteReader())
            {
               
                while (reader12.Read())
                {
                    String charges_string = Convert.ToString(reader12["charges"]);
                    String sentence_string = Convert.ToString(reader12["sentence"]);
                    String guilty_string = Convert.ToString(reader12["guilty"]);
                    String prisonName_string = Convert.ToString(reader12["PrisonName"]);
                    String id_string = Convert.ToString(reader12["Id"]);
                    string fir_id = Convert.ToString(reader12["firId"]);
                    string query3 = "Select firstname,lastname from information where Fir_id=@var1 and cir_id=@var2";
                    SqlCommand sqlCommand1 = new SqlCommand(query3, sqlConnection);
                    ListViewItem item = new ListViewItem();
                    try {
                        sqlCommand1.Parameters.AddWithValue("@var1", fir_id.Replace(" ", "_"));
                        sqlCommand1.Parameters.AddWithValue("@var2", id_string.Replace(" ", "_"));
                        

                        using (SqlDataReader reader2 = sqlCommand1.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                String fname_string = Convert.ToString(reader2["firstname"]);
                                String lname_string = Convert.ToString(reader2["lastname"]);
                                item.SubItems.Add(fname_string);
                                item.SubItems.Add(lname_string);
                            }
                            reader2.Close();
                        }
                       
                            //createFIRInformation();
                           // MessageBox.Show("Report Created");
                    } catch (Exception err) {  }


                    // Console.WriteLine(username + " " + firstname + " " + lastname + " " + phonenumber + " " + email + " " + status);


                   
                    item.Text = id_string;
                    item.SubItems.Add(charges_string);
                    item.SubItems.Add(sentence_string);

                    item.SubItems.Add(guilty_string);
                    item.SubItems.Add(prisonName_string);
                    
                    //userListView.Items.Add(item);
                    userListView.Items.AddRange(new ListViewItem[] { item });
                   

                }
            }

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

        private void userList_Click(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void userListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gotoinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            InformationList ilist = new InformationList();
            ilist.Show();
        }
    }
}
