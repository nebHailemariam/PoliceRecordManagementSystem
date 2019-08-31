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
    public partial class CreateInformation : Form
    {
        SqlConnection sqlConnection = null;
        public CreateInformation()
        {
          
            InitializeComponent();
            InitalizeRoleComboBox();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
        }
        private void InitalizeRoleComboBox()
        {
            ownerType.Items.Add("Suspect");
            ownerType.Items.Add("Victim");
            ownerType.Items.Add("Criminal");
            ownerType.Items.Add("Whistleblower");
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Create_Click(object sender, EventArgs e)
        {
            string query = "";
            bool wrong = false;
            if (firRadio.Checked == true)
            {
                query = "INSERT INTO Information(firstname,lastname,AddressInfo,age,phoneNumber," +
               " Identification,ownerType,Fir_id )values (@firstname, @lastname, @addresinfo,@age, @phoneNumber, @id," +
               " @ownertype,@doc_id)";
            }
            else if (cirRadio.Checked == true)
            {
                query = "INSERT INTO Information(firstname,lastname,AddressInfo,age,phoneNumber," +
               " Identification,ownerType,cir_id )values (@firstname, @lastname, @addresinfo,@age, @phoneNumber, @id," +
               " @ownertype,@doc_id)";
            }
            else
            {
                MessageBox.Show("Choose document type");
                wrong = true;
            }
            if (!wrong)
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                string firstname_string = firstname.Text;
                string lastname_string = lastname.Text;
                string address_string = Address.Text;
                string age_string = Age.Text;
                string phoneNumber_string = phonenumber.Text;
                string id_string = DocumentId.Text;
                string ownerType_string = (ownerType.SelectedIndex + 1).ToString();
                string docId = DocumentId.Text;
                try
                {
                    sqlCommand.Parameters.AddWithValue("@firstname", firstname_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@lastname", lastname_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@addresinfo", address_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@age", age_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@id", id_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@ownertype", ownerType_string.Replace(" ", "_"));
                    sqlCommand.Parameters.AddWithValue("@doc_id", docId.Replace(" ", "_"));


                    sqlCommand.ExecuteNonQuery();
                    //createFIRInformation();
                    MessageBox.Show("Report Created");

                }
                catch (System.Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirstInformationReportsView firview = new FirstInformationReportsView();
            firview.Show();
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

        //private void createFIRInformation()
        //{
        //    string query2 = "INSERT INTO FIRInformation(FIR_Id,victimInfoId,criminalInfoId)values (@firid,@vinfoid,@cinfoid)";
        //    string query1 = "INSERT INTO CrimeInfo(CrimeId,victimInfoId,criminalInfoId)values (@crid,@vinfoid,@cinfoid)";
        //    SqlCommand sqlCommand2 = new SqlCommand(query2, sqlConnection);

        //    string docId = DocumentId.Text;
        //    try
        //    {
        //        createFIRInformation();
        //        MessageBox.Show("Report Created");

        //    }
        //    catch (System.Exception error)
        //    {
        //        MessageBox.Show(error.Message);
        //    }

        //}
    }
}
