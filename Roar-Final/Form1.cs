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

namespace Roar_Final
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True");
            //connecting to database by giving path
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From LOGIN where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            //searching the database for the data that are input on the 2 text boxes
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            //passing the values of first column of first row(means searching columns then respective row
            //..likewise in whole database until the value is found)
            {
                this.Hide();
                //hiding the login form
                MainProgram ss = new MainProgram();
                ss.ShowDialog();
                //showing the mainprogram
                this.Close();
                //closing of the whole program
            }
            else
            {
                MessageBox.Show("Wrong Username and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if there's an error in username and password it shows the error with a message
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                //if the checkbox is checked then the hidden characters are shown
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                //if the checkbox isn't checked then the characters won't be shown
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            //the input values initializes in hidden form
        }
    }
}
