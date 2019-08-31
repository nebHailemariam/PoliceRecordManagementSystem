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
    public partial class PoliceStationEdit : Form
    {
        SqlConnection sqlConnection = null;
        public PoliceStationEdit()
        {
            InitializeComponent();
            
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
        }



        private void Edit_Click(object sender, EventArgs e)
        {
            String chiefId = Login.currentUserId;
           
                string query = "update PoliceStation set StationName=@StationName, StationLocation=" +
                "@StationLocation, City=@City1, PhoneNumber=@PhoneNumber, info=@info WHERE chief="+chiefId;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Console.WriteLine(chiefId);

            string stationname_string = stationname.Text.Replace(" ","_");
            string stationlocation_string = stationlocation.Text.Replace(" ", "_");
            string city_string = cityvalue.Text.Replace(" ", "_");
            string phonenumber_string = phonenumber.Text.Replace(" ", "_");
            
            string info_string = info.Text;

            sqlCommand.Parameters.AddWithValue("@StationName", stationname_string);
            sqlCommand.Parameters.AddWithValue("@StationLocation", stationlocation_string);
            sqlCommand.Parameters.AddWithValue("@City1", city_string);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", phonenumber_string);
            sqlCommand.Parameters.AddWithValue("@info", info_string);


            try{
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Station Updated!");
            }
            catch (Exception error)
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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiefPoliceView cpv = new ChiefPoliceView();
            cpv.Show();
          
        }

        private void backtoview_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoliceStationView psv = new PoliceStationView();
            psv.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
