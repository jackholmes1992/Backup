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

        }

        private void button4_Click(object sender, EventArgs e)
        //This is a temporary button for testing the connection :)  
        {

            //SQL to return all transactions on card in specified timeframe, ordered by date
            string sql = @"Select Forename From CUSTOMER ";

            //create DataAdapter and assign SQL instruction and Connection
            OleDbDataAdapter myDA = new OleDbDataAdapter(sql, myConn);

            //fill parameters
            myDA.SelectCommand.Parameters.AddWithValue("@cardno", clearedCardID);
            DateTime timenow = DateTime.Now;
            DateTime timespan = timenow.AddYears(-2);
            myDA.SelectCommand.Parameters.AddWithValue("@date", timespan.ToString("dd/MM/yyy HH:mm:ss"));

            //create DataTable to hold result...
            DataTable dtCustomers = new DataTable();
            //pull data from Db into DataTable
            myDA.Fill(dtCustomers);

            //link DataTable to the DataGridView control
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dtCustomers;

            //configure DataGridView display options
            dataGridView1.Columns[0].DefaultCellStyle.Format = "D";  //format this column as a date  
            dataGridView1.Columns[2].DefaultCellStyle.Format = "C";  //format this column as a currency
            dataGridView1.Columns[0].HeaderText = "Date";
            dataGridView1.Columns[1].HeaderText = "Action";
            dataGridView1.Columns[2].HeaderText = "Amount";
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.ReadOnly = true;
        }
    }
}
