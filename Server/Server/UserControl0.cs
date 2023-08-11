using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class UserControl0 : UserControl
    {
        public UserControl0()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)" +
                    "(SERVICE_NAME=xe)));" +
                    "User Id=hr;Password=hr;");

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //명령객체 생성
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            //데이터 조회



            if (comboBox1.Text == "전체조회")
            {
                cmd.CommandText = "SELECT * FROM custumer order by cid";
            }
            else if(comboBox1.Text == "불량품")
            {
                cmd.CommandText = $"select * from custumer where Ctype = 0  order by cid";
            }
            else if(comboBox1.Text == "완성품")
            {
                cmd.CommandText = $"select * from custumer where Ctype = 1  order by cid";
            }
            else if (comboBox1.Text == "출고 완료")
            {
                cmd.CommandText = $"select * from custumer where Ctype = 2  order by cid";
            }
            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (rdr.Read())
            {
                int cid = int.Parse(rdr["CID"].ToString());
                string cphone = rdr["CPHONE"] as string;
                DateTime ctime = DateTime.Parse(rdr["CTIME"].ToString());
                int cprice = int.Parse(rdr["CPRICE"].ToString());


                dataGridView1.Rows.Add(cid, cphone, ctime , cprice);
            }
            //리소스 반환
            conn.Close();
        }

        private void UserControl0_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("colname", "주문번호");
            dataGridView1.Columns.Add("colinven", "주문자 전화번호");
            dataGridView1.Columns.Add("colsales", "주문 일자");
            dataGridView1.Columns.Add("colsales", "주문 가격");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)" +
                    "(SERVICE_NAME=xe)));" +
                    "User Id=hr;Password=hr;");

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //명령객체 생성
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            //데이터 조회
           
            
            cmd.CommandText = "update custumer set CTYPE = 1 where CTYPE = 0";
            
            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();


            //리소스 반환
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)" +
                    "(SERVICE_NAME=xe)));" +
                    "User Id=hr;Password=hr;");

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //명령객체 생성
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            //데이터 조회


            cmd.CommandText = "update custumer set CTYPE = 2 where CTYPE = 1";

            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();


            //리소스 반환
            conn.Close();

             Form3 form3 = new Form3();
            form3.Show();

        }
    }
}

