using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form2 : Form
    {
        string strConn =
          "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))" +
          "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=hr;Password=hr;";
        OracleConnection conn;
        OracleCommand cmd;

        UserControl4 page1 = new UserControl4();
        UserControl5 page2 = new UserControl5();
        UserControl6 page3 = new UserControl6();
        UserControl7 page4 = new UserControl7();
        UserControl8 page5 = new UserControl8();
        UserControl9 page6 = new UserControl9();

       
       
        public Form2()
        {
            InitializeComponent();
        }

        private void cpubtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
        }

        private void gpubtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            panel1.Controls.Remove(page6);
            panel1.Controls.Add(page1);
        }

        private void casebtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page5);
            panel1.Controls.Remove(page6);
            panel1.Controls.Add(page4);
        }

        private void memobtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page6);
            panel1.Controls.Add(page5);
        }

        private void memo2btn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            panel1.Controls.Add(page6);
        }

        private void mainbtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            panel1.Controls.Remove(page6);
            panel1.Controls.Add(page2);
        }

        private void pwbtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            panel1.Controls.Remove(page6);
            panel1.Controls.Add(page3);
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rebtn_Click(object sender, EventArgs e)
        {
            Chart();
            DateTime dateTime = DateTime.Now;
            time.Text = dateTime.ToString();
        }

        private void Chart()
        {
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM BUPUM WHERE SUBSTR(BNAME, 1, INSTR(BNAME, '_') -1 ) = 'CPU'";

            OracleDataReader rdr = cmd.ExecuteReader();
            int i = 0;
            string[] X = new string[5];
            int[] Y = new int[5];
            int[] Z = new int[5];
            while (rdr.Read())
            {

                string bname = rdr["BNAME"] as string;
                int binven = int.Parse(rdr["BINVEN"].ToString());
                int bsales = int.Parse(rdr["BSALES"].ToString());

                X[i] = bname;
                Y[i] = binven;
                Z[i] = bsales;
                i++;
            }
            chart1.Series[0].Points.DataBindXY(X, Z);

            cmd.CommandText = "commit";

            cmd.ExecuteNonQuery();


            conn.Close();
        }

        private void cpubtn_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
        }
    }
}

