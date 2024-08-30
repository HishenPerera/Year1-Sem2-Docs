using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int studentID;
        String studentName;
        int age;
        double gpa;
        String Address;
        string connetionString;
        SqlConnection cnn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connetionString = getConnectionString();

            cnn = new SqlConnection(connetionString);
            cnn.Open();
           // MessageBox.Show("Connection Open  !");
            


            studentName = TxtName.Text;
            studentID = Int32.Parse(TxtID.Text);
            age= Int32.Parse(txtAge.Text);
            gpa = Convert.ToDouble(txtGPA.Text);
            Address = txtAddress.Text;


            string query = "INSERT INTO dbo.student values (@studentID, @studentName, @age, @gpa, @Address)";

            SqlCommand myCommand = new SqlCommand(query, cnn);
            myCommand.Parameters.AddWithValue("@studentName", studentName);
            myCommand.Parameters.AddWithValue("@studentID", studentID);
            myCommand.Parameters.AddWithValue("@age",age);
            myCommand.Parameters.AddWithValue("@gpa",gpa);
            myCommand.Parameters.AddWithValue("@Address", Address);
            // ... other parameters
            myCommand.ExecuteNonQuery();

            cnn.Close();

            TxtName.Text="";
            TxtID.Text = "";
            txtAge.Text = "";
            txtGPA.Text = "";
            Address = txtAddress.Text;

            loadData();

        }

        public void loadData()
        {
            connetionString = getConnectionString();
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            String sql = "select * From dbo.student";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cnn);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            dataGridView1.DataSource = table;
            // dataGridView1.d;
            cnn.Close();
        }

        public string getConnectionString()
        {
            string conString;
         
            conString = @"Data Source=LAPTOP-O4DFFLQM\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";

            return conString;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            loadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
