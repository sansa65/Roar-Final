﻿using System;
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
    
    public partial class MainProgram : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30";
        //connecting the database(had to make sure the database is connected cuz there were some errors)
        int ToggleMove;
        int MValueX;
        int MValueY;
        //declaring int variables to adjust the move of the app

        public MainProgram()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            //closes the whole program
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.WindowState = FormWindowState.Minimized;
                //minimizing the app
            }
        }
        //adjusting the movements of the app when dragged from the top panel according to desktop mouse pointer values
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ToggleMove = 1;
            MValueX = e.X;
            MValueY = e.Y;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToggleMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValueX, MousePosition.Y - MValueY);
            }
        }

        private void panel5_MouseUp(object sender, MouseEventArgs e)
        {
            ToggleMove = 0;
        }
        
        private void MainProgram_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //starting to show the system time in app
            Date.Text = DateTime.Now.ToLongDateString();
            Time.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            scrollingpanel.Height = button1.Height;
            scrollingpanel.Top = button1.Top;
            tabControl1.SelectTab(tabPage2);
        }*/
        
        /*As of each button is clicked the scrolling panel moves with the 
        height and top fixed with button height and top values of the each button
        and the tabs changes accordingly*/
        private void button2_Click(object sender, EventArgs e)
        {
            scrollingpanel.Height = button2.Height;
            scrollingpanel.Top = button2.Top;
            tabControl1.SelectTab(tabPage1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            scrollingpanel.Height = button3.Height;
            scrollingpanel.Top = button3.Top;
            tabControl1.SelectTab(tabPage3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scrollingpanel.Height = button4.Height;
            scrollingpanel.Top = button4.Top;
            tabControl1.SelectTab(tabPage4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scrollingpanel.Height = button5.Height;
            scrollingpanel.Top = button5.Top;
            tabControl1.SelectTab(tabPage5);
        }

        //adjusting the movements of the app when dragged from the top middle label according to desktop mouse pointer values
        private void label12_MouseDown(object sender, MouseEventArgs e)
        {
            ToggleMove = 1;
            MValueX = e.X;
            MValueY = e.Y;
        }

        private void label12_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToggleMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MValueX, MousePosition.Y - MValueY);
            }
        }

        private void label12_MouseUp(object sender, MouseEventArgs e)
        {
            ToggleMove = 0;
        }
        
        //(3)..edit button on receivable tab

        private void button15_Click(object sender, EventArgs e)
        {
            //checking all the boxes are filled
            if (textBox10.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Enter Data to Edit");
                //if not filled a message box will be shown
            }
            else
            {
                int myint2;
                bool validateInvno = int.TryParse(textBox10.Text, out myint2);
                bool validateaccountnum = int.TryParse(textBox8.Text, out myint2);
                bool validatereceiamount = int.TryParse(textBox7.Text, out myint2);

                //cheking the values entered in respective text boxes are integer values if not error messages are shown to each
                if (validateInvno == true)
                {
                    if (validateaccountnum == true)
                    {
                        if (validatereceiamount == true)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf; Integrated Security = True; Connect Timeout = 30");
                                //connecting to DB
                                //MessageBox.Show("Successfully connected");
                                String query = "UPDATE Receivable_Account SET Invoice_Date='" + dateTimePicker2.Text + "',Account_Holder='" + textBox9.Text + "',Account_Number='" + textBox8.Text + "',Receivable_Amount='" + textBox7.Text + "' WHERE Invoice_Number='" + textBox10.Text + "' ";
                                //Have to insert correct invoice number then the data to be edited in each textbox filled
                                con.Open();
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Successfully Edited");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter a Integer Value to  Received Amount");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter a Integer Value to  Account Number");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a Integer Value to Invoice Number");
                }
            }
        }

        //(3)..save button on receivable tab

        private void button16_Click(object sender, EventArgs e)
        {
            //checking all the boxes are filled
            if (textBox10.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Enter Data to Save");
                //if not filled a message box will be shown
            }
            else
            {
                int myint3;
                bool validateInvno = int.TryParse(textBox10.Text, out myint3);
                bool validateaccountnum = int.TryParse(textBox8.Text, out myint3);
                bool validatereceiamount = int.TryParse(textBox7.Text, out myint3);

                //cheking the values entered in respective text boxes are integer values if not error messages are shown to each
                if (validateInvno == true)
                {
                    if (validateaccountnum == true)
                    {
                        if (validatereceiamount == true)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30");
                                //connecting to DB
                                //MessageBox.Show("Successfully connected");
                                String query = "INSERT INTO Receivable_Account(Invoice_Number,Invoice_Date,Account_Holder,Account_Number,Receivable_Amount) Values ('" + textBox10.Text + "','" + dateTimePicker2.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                                //Inserting data into the DB
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
                        else
                        {
                            MessageBox.Show("Enter a Integer Value to Received Amount");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter a Integer Value to Account Number");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a Integer Value to Invoice Number");
                }
            }
        }

        //(3)..view button on receivable tab

        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select Invoice_Number,Invoice_Date,Account_Holder,Account_Number,Receivable_Amount From Receivable_Account", sqlcon);
                //Showing the data on the datagrid view by selecting the only columns that we want to show
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);
                dataGridView2.DataSource = dtbl1;

            }
        }

        //(3)..edit button on payable tab

        private void button11_Click(object sender, EventArgs e)
        {
            //checking all the boxes are filled
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Enter Data to Edit");
                //if not filled a message box will be shown
            }
            else
            {
                int myint1;
                bool validateInvNo = int.TryParse(textBox1.Text, out myint1);
                bool validateaccno = int.TryParse(textBox4.Text, out myint1);
                bool validatepaymamount = int.TryParse(textBox5.Text, out myint1);

                //cheking the values entered in respective text boxes are integer values if not error messages are shown to each
                if (validateInvNo == true)
                {
                    if (validateaccno == true)
                    {
                        if (validatepaymamount == true)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30");
                                //MessageBox.Show("Successfully connected");
                                String query = "UPDATE Payable_Account SET Invoice_Date='" + dateTimePicker1.Text + "',Account_Holder='" + textBox3.Text + "',Account_Number='" + textBox4.Text + "',Receivable_Amount='" + textBox5.Text + "' WHERE Invoice_Number='" + textBox1.Text + "'";
                                ////Have to insert correct invoice number then the data to be edited in each textbox filled

                                //"UPDATE Receivable_Accounts SET Invoice#='"+textBox10.Text+"',Invoice_Date='"+textBox6.Text+"',Account_Holder='"+textBox9.Text+"',Account_Number='"+textBox8.Text+"',Payment_Amount='"+textBox7.Text+"') WHERE Invoice#='"+textBox10.Text+"' ";
                                con.Open();
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Successfully Edited");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Integer Value to Payment Amount");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Integer Value to Account Number");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Integer Value to Invoice Number");
                }
            }
        }

        //(3)..save button on payable tab

        private void button12_Click(object sender, EventArgs e)
        {
            //checking all the boxes are filled
            if (textBox1.Text =="" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Enter Data to Save");
                //if not filled a message box will be shown
            }
            else
            {
                int myInt;
                bool validateInvoiceNo = int.TryParse(textBox1.Text, out myInt);
                bool validateAccNo= int.TryParse(textBox4.Text, out myInt);
                bool validatepayamount= int.TryParse(textBox5.Text, out myInt);

                //cheking the values entered in respective text boxes are integer values if not error messages are shown to each
                if (validateInvoiceNo == true)
                {
                    if (validateAccNo == true)
                    {
                        if (validatepayamount == true)
                        {

                            try
                            {

                                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\Roar-Final\roardb.mdf;Integrated Security=True;Connect Timeout=30");
                                //MessageBox.Show("Successfully connected");
                                String query = "INSERT INTO Payable_Account(Invoice_Number,Invoice_Date,Account_Holder,Account_Number,Payment_Amount) Values ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                                //Inserting data into DB

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
                        else
                        {
                            MessageBox.Show("Enter Integer Value to Payable Amount");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter Integer Value to Account Number");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Integer Value to Invoice Number");
                }
            }
        }

        //(3)..view button on payable tab

        private void button13_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select Invoice_Number,Invoice_Date,Account_Holder,Account_Number,Payment_Amount From Payable_Account", sqlcon);
                //Showing the data on the datagrid view by selecting the only columns that we want to show
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        //(2)..view all button in transactions tab

        private void button18_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "Select Payable_Account.Invoice_Number AS PA_InvoiceNo," +
                                "Payable_Account.Invoice_Date AS PA_InvoiceDate," +
                                "Payable_Account.Account_Holder AS PA_AccHolder," +
                                "Payable_Account.Account_Number AS PA_AccNo," +
                                "Payable_Account.Payment_Amount AS PA_Payment," +
                                "Receivable_Account.Invoice_Number AS RA_InvoiceNo," +
                                "Receivable_Account.Invoice_Date AS RA_InvoiceDate," +
                                "Receivable_Account.Account_Holder AS RA_AccHolder," +
                                "Receivable_Account.Account_Number AS RA_AccNo," +
                                "Receivable_Account.Receivable_Amount AS RA_Payment " +
                          "From Payable_Account " +
                          "FULL OUTER JOIN Receivable_Account " +
                          "ON Payable_Account.Invoice_Number=Receivable_Account.Invoice_Number", sqlcon);
                /*Merged the 2 tables by full outer join so all coloumns will be shown 
                and selected the columns that are needed to be shown(changed the column names as we needed)*/

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView3.DataSource = dtbl;
            }

            //tried to get the sum..didn't worked out
            /*try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    /*string query = "SELECT SUM (Price) FROM Bill";
                    using (SqlConnection sqlcon = new SqlConnection(connectionString))
                    {
                        object result = sqlcon.ExecuteScalar();
                        label14.Text = Convert.ToString(result);
                    }

                    
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand
                        (
                    "Select SUM(Payment_Amount) FROM Payable.Account", sqlcon);
                    
                    
                    Int32 count = (Int32)cmd.ExecuteScalar();
                    label14.Text = ();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            /*using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                //SqlCommand com;
                string q = "Select SUM Payment_Amount From Payable_Account";
                /*SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "Select SUM (Payable_Account.Payment_Amount) " +
                        "From Payable_Account", sqlcon);*/
            //com = new SqlCommand(q, con);
            //reader.Read();
            //labelname15.Text = reader["Name"].ToString();
            //lCommand query = new SqlCommand(q, sqlcon);
            //lDataReader dr = query.ExecuteReader();
            //label15.Text = sqlDa.ToString();
            //xtBox6.Text = dr["Total"].ToString();
            //
            /*using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "Select Payable_Account.Invoice_Number AS PA_InvoiceNo," +
                                "Payable_Account.Invoice_Date AS PA_InvoiceDate," +
                                "Payable_Account.Account_Holder AS PA_AccHolder," +
                                "Payable_Account.Account_Number AS PA_AccNo," +
                                "Payable_Account.Payment_Amount AS PA_Payment," +
                                "Receivable_Account.Invoice_Number AS RA_InvoiceNo," +
                                "Receivable_Account.Invoice_Date AS RA_InvoiceDate," +
                                "Receivable_Account.Account_Holder AS RA_AccHolder," +
                                "Receivable_Account.Account_Number AS RA_AccNo," +
                                "Receivable_Account.Receivable_Amount AS RA_Payment " +
                          "From Payable_Account " +
                          "FULL OUTER JOIN Receivable_Account " +
                          "ON Payable_Account.Invoice_Number=Receivable_Account.Invoice_Number", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView3.DataSource = dtbl;
            }*/
        }

        //(2)..add buttons on transactions tab
        private void AddReinTra_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
            //switching to the selected tab

        }

        //(2)..add buttons on transactions tab
        private void AddPayinTran_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage5);
            //switching to the selected tab
        }

        //(2)..A new form opens to search by name 
        private void button7_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.ShowDialog();
        }

        //(1)..A new form opens to Add Account
        private void button20_Click(object sender, EventArgs e)
        {
            Addform af = new Addform();
            af.ShowDialog();
        }

        //(1)..A new form opens to Manage Account
        private void button22_Click(object sender, EventArgs e)
        {
            Addform af = new Addform();
            af.ShowDialog();
        }

        //(1)..View all in Accounts tab

        private void button21_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter
                    (
                        "Select Account_Number," +
                                "Account_Name," +
                                "Organization," +
                                "Contact_No," +
                                "Address," +
                                "EMail AS Email FROM Account_Details", sqlcon);
                ///Showing the data on the datagrid view by selecting the only columns that we want to show
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView4.DataSource = dtbl;
            }
        }

        //(1)..Search button on Accounts tab

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            //if the search box is empty a message is shown
            {
                MessageBox.Show("Enter a Name to Search");
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {

                    sqlcon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter
                        (
                            "SELECT * FROM Account_Details WHERE Account_Name LIKE '" + textBox2.Text + "'", sqlcon);
                    //Showing the details of the account by the name that we searches
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView4.DataSource = dtbl;
                }
            }
        }

        //(2).. save as button on transactions tab

        private void button17_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView3.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView3.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                //User is able to select the type that the document needs to be saved
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful","Sucess",MessageBoxButtons.OK);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //dataGridView3.Rows.Clear();
            //dataGridView3.Refresh();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = null;
            //dataGridView2.Refresh();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
            /*string query = "SELECT SUM (Price) FROM Bill";
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, DBconn);
            DataTable source = new DataTable();
            dAdapter.Fill(source);
            TotalValueLabel.Text = source.ToString();*/
        }

        //(3).. cleaning the textboxes in payable tab if they are filled
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            //textBox1.Text = null;
        }

        //(3).. cleaning the textboxes in receivable tab if they are filled
        private void button9_Click(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox9.Text = null;
            textBox8.Text = null;
            textBox7.Text = null;
        }
    }
}
