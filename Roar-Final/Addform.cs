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
    public partial class Addform : Form
    {
        int toggleval;
        int valx;
        int valy;
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30";

        public Addform()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            toggleval = 1;
            valx = e.X;
            valy = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (toggleval == 1)
            {
                this.SetDesktopLocation(MousePosition.X - valx, MousePosition.Y - valy);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            toggleval = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter Data to Save");
            }
            else
            {
                try
                {

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30");
                    //MessageBox.Show("Successfully connected");
                    String query = "INSERT INTO Account_Details(Account_Number,Account_Name,Organization,Contact_No,Address,EMail) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Enter Data to Edit");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30");
                    //MessageBox.Show("Successfully connected");
                    String query = "UPDATE Account_Details SET Account_Name='" + textBox2.Text + "',Organization='" + textBox3.Text + "',Contact_No='" + textBox4.Text + "',Address='" + textBox5.Text + "',EMail='" + textBox6.Text + "' WHERE Account_Number='" + textBox1.Text + "'";
                    //"UPDATE Receivable_Accounts SET Invoice#='"+textBox10.Text+"',Invoice_Date='"+textBox6.Text+"',Account_Holder='"+textBox9.Text+"',Account_Number='"+textBox8.Text+"',Payment_Amount='"+textBox7.Text+"') WHERE Invoice#='"+textBox10.Text+"' ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Edited","Success",MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
