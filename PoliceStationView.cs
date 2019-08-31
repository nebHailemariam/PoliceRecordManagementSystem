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
    public partial class PoliceStationView : Form
    {
        SqlConnection sqlConnection = null;
        public PoliceStationView()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PoliceCrimeReportDB; Integrated Security = True";
            sqlConnection.Open();
            initializeInfo();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void phonevalue_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoliceStationEdit pse = new PoliceStationEdit();
            pse.Show();
        }
        private void initializeInfo()
        {
            string query = "Select * from PoliceStation";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
               
                while (reader.Read())
                {
                    String name = Convert.ToString(reader["StationName"]).Replace("_", " ") ;
                    String location = Convert.ToString(reader["StationLocation"]).Replace("_", " ");
                    String city = Convert.ToString(reader["city"]).Replace("_", " ");
                    String phonenumber = Convert.ToString(reader["PhoneNumber"]).Replace("_", " ");
                    String info = Convert.ToString(reader["info"]).Replace("_", " ");
                    Console.WriteLine(name);
                    Console.WriteLine(location);
                    Console.WriteLine(city);
                    Console.WriteLine(phonenumber);
                    Console.WriteLine(info);
                    namevalue.Text = name;
                    locationvalue.Text = location;
                    cityvalue.Text = city;
                    phonevalue.Text = phonenumber;
                    infovalue.Text = info;
                   

                }
            }


        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiefPoliceView cpv = new ChiefPoliceView();
            cpv.Show();
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

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
