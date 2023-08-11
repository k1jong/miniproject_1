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
    public partial class UserControl8 : UserControl
    {
        public UserControl8()
        {
            InitializeComponent();
        }

        private void rebtn_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
                         "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                         "(HOST=localhost)(PORT=1521)))" +
                         "(CONNECT_DATA=(SERVER=DEDICATED)" +
                         "(SERVICE_NAME=xe)));" +
                         "User Id=hr;Password=hr;");


            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM BUPUM WHERE (SUBSTR(BNAME, 1, INSTR(BNAME, '_') -1 ) = 'HDD') or \r\n(SUBSTR(BNAME, 1, INSTR(BNAME, '_') -1 ) = 'SSD')";

            OracleDataReader rdr = cmd.ExecuteReader();
            int i = 0;
            string[] X = new string[7];
            int[] Y = new int[7];
            int[] Z = new int[7];
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
            chart6.Series[0].Points.DataBindXY(X, Z);

            cmd.CommandText = "commit";

            cmd.ExecuteNonQuery();


            conn.Close();

            DateTime dateTime = DateTime.Now;
            label2.Text = dateTime.ToString();
        }
    }
}
