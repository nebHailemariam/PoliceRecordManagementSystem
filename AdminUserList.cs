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
    public partial class AdminUserList : Form
    {
        SqlConnection sqlConnection = null;

        public AdminUserList()
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



            string query = "Select * from employee";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            userListView.View = View.Details;
            userListView.FullRowSelect = true;
            userListView.CheckBoxes = true;
    
            userListView.Sorting = System.Windows.Forms.SortOrder.Ascending;

            userListView.Columns.Add("Username", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("First Name", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Phonenumber", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Email", -2, HorizontalAlignment.Left);
            userListView.Columns.Add("Status", -2, HorizontalAlignment.Left);



            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                int num = 1;
                while (reader.Read())
                {
                    String username = Convert.ToString(reader["username"]);
                    String firstname = Convert.ToString(reader["firstname"]);
                    String lastname = Convert.ToString(reader["lastname"]);
                    String phonenumber = Convert.ToString(reader["phoneNumber"]);
                    String email = Convert.ToString(reader["email"]);
                    String status = Convert.ToString(reader["status"]);
                    Console.WriteLine(username + " " + firstname + " " + lastname + " " + phonenumber + " " + email + " " + status);
                    ListViewItem item = new ListViewItem();

                    
                    item.Text = username;
                    item.SubItems.Add(firstname);
                    item.SubItems.Add(lastname);
                    
                    item.SubItems.Add(phonenumber);
                    item.SubItems.Add(email);
                    item.SubItems.Add(status);
                    //userListView.Items.Add(item);
                    userListView.Items.AddRange(new ListViewItem[] {item});
                    num++;

                }
            }
            
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            string query = "DELETE Employee WHERE username = @username";
            


            //string store = userListView.CheckedItems.ToString();
            
            foreach(ListViewItem store in userListView.CheckedItems)
            {
               
                
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@username", store.Text);
                    sqlCommand.ExecuteNonQuery();
                    InitalizeUserListBox();


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

            }
            
            //this.Hide();
            //AdminUserList adminUserList = new AdminUserList();
            //adminUserList.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminhome = new AdminHome();
            adminhome.Show();
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

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homeform = new HomePageForm();
            homeform.Show();
        }

        private void userList_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome admin = new AdminHome();
            admin.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminUserList_Load(object sender, EventArgs e)
        {

        }
    }
}
