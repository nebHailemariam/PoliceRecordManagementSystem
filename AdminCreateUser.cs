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
using System.IO;

namespace PoliceCrimeReport
{
    public partial class AdminCreateUser : Form
    {
        SqlConnection sqlConnection = null;
        public AdminCreateUser()
        {
            InitializeComponent();
            InitalizeRoleComboBox();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
        }

        private void InitalizeRoleComboBox()
        {
            roleidcombobox.Items.Add("1");
            roleidcombobox.Items.Add("2");
            roleidcombobox.Items.Add("3");
            roleidcombobox.Items.Add("4");
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

        private void phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private string CreatePassword()
        {
            int length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while(0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Employee(firstname, lastname, email, username, password, phonenumber, status, roleid) values (@firstname, @lastname, @email, @username, @password, @phonenumber, @status, @roleid)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            string username_string = username.Text;
            string firstname_string = firstname.Text;
            string lastname_string = lastname.Text;
            string email_string = email.Text;
            string phonenumber_string = phonenumber.Text;
            string stutus_string = status.Text;
            string password_string = CreatePassword();
            string roleid_string = (roleidcombobox.SelectedIndex + 1).ToString();

            MessageBox.Show(password_string+roleid_string);

            if (roleid_string.Equals("0"))
            {
                MessageBox.Show("Invalid role + "+ roleid_string);
            }
            else
            {
                try
                {
                    StreamWriter file = new StreamWriter("password.txt", true);
                    file.WriteLine(username_string + " " + password_string);
                    file.Close();


                    sqlCommand.Parameters.AddWithValue("@firstname", firstname_string);
                    sqlCommand.Parameters.AddWithValue("@lastname", lastname_string);
                    sqlCommand.Parameters.AddWithValue("@email", email_string);
                    sqlCommand.Parameters.AddWithValue("@username", username_string);
                    sqlCommand.Parameters.AddWithValue("@status", stutus_string);
                    sqlCommand.Parameters.AddWithValue("@phonenumber", phonenumber_string);
                    sqlCommand.Parameters.AddWithValue("@password", password_string);
                    sqlCommand.Parameters.AddWithValue("@roleid", roleid_string);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Employee Created");
                }catch(System.Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }



            username.Text="Username";
            firstname.Text="First Name";
            lastname.Text="Last Name";
            email.Text="Email";
            phonenumber.Text="PhoneNumber";
            status.Text="Status";
            roleidcombobox.Text="Role Id";

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome adminhome = new AdminHome();
            adminhome.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateUser_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roleidcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void status_TextChanged(object sender, EventArgs e)
        {

        }

        private void phonenumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
