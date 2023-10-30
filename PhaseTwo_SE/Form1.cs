using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace PhaseTwo_SE
{
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd1 = new OracleCommand();
            //fill combo box1 with all films
            cmd1.Connection = conn;
            cmd1.CommandText = "select title from movie";
            cmd1.CommandType = CommandType.Text;
            OracleDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                filmBox.Items.Add(dr[0]);
            }
            dr.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }



        private void UserIdBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
        
            OracleCommand cmd2 = new OracleCommand();
            OracleCommand cmd3 = new OracleCommand();
            int maxid = 1, newid = 1, filmid = 1;

            //get max id from table Favoriets
            //------------------------------------------------------------------
            cmd.Connection = conn;
            cmd.CommandText = "GetmaxID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                maxid = Convert.ToInt32(cmd.Parameters["id"].Value.ToString());
                newid = maxid + 1;
            }
            catch
            {
                newid = 1;
            }

            //get film id from table movies by filmname 
            //------------------------------------------------------------------
            cmd3.Connection = conn;
            cmd3.CommandText = "GetFilmID";
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("film_id", OracleDbType.Int32, ParameterDirection.Output);
            cmd3.Parameters.Add("filmname", filmName.Text);




            cmd3.ExecuteNonQuery();
            try
            {

                filmid = Convert.ToInt32(cmd3.Parameters["film_id"].Value.ToString());

            }
            catch
            {
              //  MessageBox.Show("Film is not founded");
            }
            //inser new record 
            //------------------------------------------------------------------ 
            cmd2.Connection = conn;
            cmd2.CommandText = "INSERT INTO Favourites(ID ,Name, UserID,movieID,showID)VALUES( :newid ,:Name, :UserID,:filmid,1)";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("newid", OracleDbType.Int32).Value = newid;
            cmd2.Parameters.Add("Name", filmBox.Text);
            cmd2.Parameters.Add("UserID", UserIdBox.Text);
            cmd2.Parameters.Add("filmid", OracleDbType.Int32).Value = filmid;


            int r = cmd2.ExecuteNonQuery();
            if (r != -1)
            {

                MessageBox.Show("Film is added to your favourites");

            }
        }

        private void filmBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}