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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.intel.co.kr/content/www/kr/ko/products/overview.html");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nvidia.com/ko-kr/geforce/graphics-cards/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kr.msi.com/Motherboards/Products#?tag=MEG-Series");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://shop.danawa.com/virtualestimate/?controller=estimateMain&methods=index&marketPlaceSeq=16&logger_kw=dnw_gnb_esti");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.asus.com/kr/motherboards-components/motherboards/all-series/filter?Category=Intel");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://maxelite.co.kr/");
        }

        private void button13_Click(object sender, EventArgs e)
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
            if (comboBox2.Text == "")
            {
                MessageBox.Show("주문할 부품을 선택해 주세요");
            }
            else
            {
                cmd.CommandText = $"update bupum set binven = (SELECT BINVEN FROM BUPUM WHERE bname = '{comboBox2.Text}') + {textBox2.Text} where bname ='{comboBox2.Text}'";
            }
            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();



            richTextBox1.AppendText($"{comboBox2.Text} 부품 {textBox2.Text} 개 주문 완료\r\n");


            //리소스 반환
            conn.Close();

        }

        private void button12_Click(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT * FROM BUPUM";
            }
            else
            {
                cmd.CommandText = $"SELECT * FROM BUPUM WHERE SUBSTR(BNAME, 1, INSTR(BNAME, '_') -1 ) = '{comboBox1.Text}'";
            }
            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (rdr.Read())
            {
                string bname = rdr["BNAME"] as string;
                int binven = int.Parse(rdr["BINVEN"].ToString());
                int bsales = int.Parse(rdr["BSALES"].ToString());


                dataGridView1.Rows.Add(bname, binven, bsales);
            }
            //리소스 반환
            conn.Close();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("colname", "부품이름");
            dataGridView1.Columns.Add("colinven", "수량");
            dataGridView1.Columns.Add("colsales", "판매량");
        }
    }
}

