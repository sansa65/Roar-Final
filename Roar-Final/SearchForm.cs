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
    public partial class SearchForm : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30";
        int ToggleMve;
        int MValX;
        int MValY;
        public SearchForm()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchForm_MouseDown(object sender, MouseEventArgs e)
        {
            ToggleMve = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void SearchForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToggleMve == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void SearchForm_MouseUp(object sender, MouseEventArgs e)
        {
            ToggleMve = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {

                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "SELECT Payable_Account.Invoice_Number AS PA_InvoiceNO," +
                        "Payable_Account.Invoice_Date AS PA_InvoiceDate," +
                        "Payable_Account.Account_Holder AS PA_AccHolder," +
                        "Payable_Account.Account_Number AS PA_AccNo," +
                        "Payable_Account.Payment_Amount AS PA_Payment FROM Payable_Account WHERE Account_Holder LIKE '" + textBox2.Text + "'", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView4.DataSource = dtbl;
            }
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {

                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "SELECT Receivable_Account.Invoice_Number AS RA_InvoiceNO," +
                        "Receivable_Account.Invoice_Date AS RA_InvoiceDate," +
                        "Receivable_Account.Account_Holder AS RA_AccHolder," +
                        "Receivable_Account.Account_Number AS RA_AccNo," +
                        "Receivable_Account.Receivable_Amount AS RA_Payment FROM Receivable_Account WHERE Account_Holder LIKE '" + textBox2.Text + "'", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
    }
}
