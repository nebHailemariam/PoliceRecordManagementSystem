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
    public partial class Login : Form
    {
       public static string  currentUserId="";
        public static string currentUserRole = "";
        SqlConnection sqlConnection = null;
        public Login()
        {

            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void mainLogin_Click(object sender, EventArgs e)
        {
            //Cheack if the username and password inserted are't empty
            if (Password.Text == null || Username.Text == null)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {//if the username and password aren't empty
                String username_string = "", password_string = "", roleid = "";
                string query = "Select * from employee";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    bool check = false;
                    while (reader.Read())
                    {
                        //find if the username and password entered exist in the database
                        username_string = Convert.ToString(reader["username"]);
                        roleid = Convert.ToString(reader["Roleid"]);
                        password_string = Convert.ToString(reader["Password"]);
                        if (Username.Text == username_string && Password.Text == password_string)
                        {
                            currentUserId = Convert.ToString(reader["Id"]);
                            currentUserRole = Convert.ToString(reader["Roleid"]);
                            check = true;
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
                            Console.WriteLine(username_string + " " + password_string + " " + roleid);

                        }
                    }
                    if(check == false)
                    {
                        MessageBox.Show("Invalid Credentials");
                        ClearTexts();
                    }
                }
            }

        }
        private void ClearTexts()
        {
            
            string user = String.Empty;
            string pass = String.Empty;
            Username.Text = user;
            Password.Text = pass;
        }

        private void Username_Enter(object sender, EventArgs e)
        {
            if (Username.Text == "Username")
            {
                Username.Text = "";
            }
        }

        private void Username_Leave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Username";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm home = new HomePageForm();
            home.Show();

        }

        private void back_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm home = new HomePageForm();
            home.Show();
        }
    }
       
    }
