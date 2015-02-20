using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ContractManagementSystem
{
    public partial class FindCustomer : Form
    {
        public FindCustomer()
        {
            InitializeComponent();
        }

        OleDbConnection myConn = new OleDbConnection();

        private void FindCustomer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConn.ConnectionString = connectionDetails.dbsource;

            //SQL to return all transactions on card in specified timeframe, ordered by date
            string sql =@"Select CustomerNo, Title, Forename, Surname, AddressLine1, AddressLine2,
                        Town, County, Postcode, HomePhone, WorkPhone, Fax From CUSTOMER"
                        + " Where Forename = @cusName";

            //create DataAdapter and assign SQL instruction and Connection
            OleDbDataAdapter myDA = new OleDbDataAdapter(sql, myConn);

            //fill parameters
            myDA.SelectCommand.Parameters.AddWithValue("@cusName", textBox1.Text);

            //create DataTable to hold result...
            DataTable dtCustomer = new DataTable();
            //pull data from Db into DataTable
            myDA.Fill(dtCustomer);

            //link DataTable to the DataGridView control
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dtCustomer;

            /* //SIMPLY FORMATS CELLS - WE MIGHT NEED THIS LATER
            //configure DataGridView display options
            dataGridView1.Columns[0].DefaultCellStyle.Format = "D";  //format this column as a date  
            dataGridView1.Columns[2].DefaultCellStyle.Format = "C";  //format this column as a currency
            dataGridView1.Columns[0].HeaderText = "Date";
            dataGridView1.Columns[1].HeaderText = "Action";
            dataGridView1.Columns[2].HeaderText = "Amount";
            dataGridView1.Columns[0].Width = 160;
            */
            dataGridView1.ReadOnly = true;








/*
            try
            {
                myConn.ConnectionString = connectionDetails.dbsource;
                OleDbCommand myCmd = myConn.CreateCommand();

                myCmd.CommandText = "Select Forename, Surname From CUSTOMER" + " Where CustomerNo = @cusNo";
                myCmd.Parameters.AddWithValue("cusNo", textBox1.Text);

                myConn.Open();
                OleDbDataReader myDR = myCmd.ExecuteReader();
                myDR.Read();
                textBox3.Text = myDR[0].ToString();
                textBox4.Text = myDR[1].ToString();
                //MessageBox.Show("connected");
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
