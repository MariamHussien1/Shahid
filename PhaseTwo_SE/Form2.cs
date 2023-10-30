//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
//namespace PhaseTwo_SE
//{
//    public partial class Form2 : Form
//    {
//        // Connection string for Oracle database
//        private string connectionString = "Data Source=orcl;User Id=scott;Password=tiger;";

//        // Data adapter and data set
//        private OracleDataAdapter dataAdapter;
//        private DataSet dataSet;

//        public Form2()
//        {
//            InitializeComponent();
//        }

//        private void Form2_Load(object sender, EventArgs e)
//        {
//            // Initialize the data adapter with select command



//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            // Get the user input for the value to search for

//            dataAdapter = new OracleDataAdapter("SELECT * FROM  moviestemp where ID =(select id from categoriestemp where name=:searchValue)", connectionString);
//            dataAdapter.SelectCommand.Parameters.Add("searchValue", txtsearch.Text);
//            // Initialize the data set
//            dataSet = new DataSet();

//            // Fill the data set with data from the database
//            dataAdapter.Fill(dataSet);

//            // Bind the data set to the data grid view
//            dataGridView1.DataSource = dataSet.Tables[0];
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            // Update the database with the changes in the data set
//            //OracleCommandBuilder builder = new OracleCommandBuilder(dataAdapter);
//            //dataAdapter.Update(dataSet, "categories");
//            //MessageBox.Show("Data updated successfully!");
//        }
//    }
//}

using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace PhaseTwo_SE
{
    public partial class Form2 : Form
    {
        // Connection string for Oracle database
        private string connectionString = "Data Source=orcl;User Id=hr;Password=hr;";

        // Data adapter and data set
        private OracleDataAdapter dataAdapter;
        private DataSet dataSet;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Initialize the data adapter with select command
            //dataAdapter = new OracleDataAdapter("SELECT * FROM categoriestemp", connectionString);
            //dataSet = new DataSet();
            //dataAdapter.Fill(dataSet, "categoriestemp");
        
            //// Bind the data set to the data grid view
            //dataGridView1.DataSource = dataSet.Tables["categoriestemp"];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

   
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            // Get the user input for the value to search for

            dataAdapter = new OracleDataAdapter("SELECT movieID,categoryID as category ,title  FROM  movie where categoryID =(select categoryid from category where categoryName=:searchValue)", connectionString);
            dataAdapter.SelectCommand.Parameters.Add("searchValue", txtsearch.Text);

            // Initialize the data set
            dataSet = new DataSet();

            // Fill the data set with data from the database
            dataAdapter.Fill(dataSet);

            // Bind the data set to the data grid view
            dataGridView1.DataSource = dataSet.Tables[0];

        }
   
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Update the database with the changes in the data set
            OracleCommandBuilder builder = new OracleCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet.Tables[0]);
            MessageBox.Show("Data updated successfully!");
        }
    }
}