using Oracle.ManagedDataAccess.Client;
using Server.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Xml.Linq;

namespace Server
{
    public partial class Form1 : Form
    {
        UserControl1 page1 = new UserControl1 ();
        UserControl2 page2 = new UserControl2 ();
        UserControl3 page3 = new UserControl3 ();
        UserControl0 page4 = new UserControl0 ();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            panel1.Controls.Remove (page1);
            panel1.Controls.Remove (page2);
            panel1.Controls.Remove (page3);
            panel1.Controls.Remove (page4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2 ();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Add(page2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page4);
            panel1.Controls.Add(page3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose ();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)" +
                    "(SERVICE_NAME=xe)));" +
                    "User Id=hr;Password=hr;");

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (radioButton2.Checked == true)
            {
                ProcessQuery(cmd, "CPU");
            }
            else if (radioButton4.Checked == true)
            {
                ProcessQuery(cmd, "PW");
            }
            else if (radioButton6.Checked == true)
            {
                ProcessQuery(cmd, "HDD");
            }
            else if (radioButton5.Checked == true)
            {
                ProcessQuery(cmd, "SSD");
            }
            else if (radioButton3.Checked == true)
            {
                ProcessQuery(cmd, "CASE");
            }
            else if (radioButton1.Checked == true)
            {
                ProcessQuery(cmd, "MAIN");
            }
            else if (radioButton7.Checked == true)
            {
                ProcessQuery(cmd, "GPU");
            }
            else if (radioButton8.Checked == true)
            {
                ProcessQuery(cmd, "RAM");
            }
            else
                MessageBox.Show("조회하실 부품의 항목을 선택해 주세요");

            conn.Close();
        }
        private void ProcessQuery(OracleCommand cmd, string category)
        {
            cmd.CommandText = $"select count(*) from BUPUM where SUBSTR(BNAME, 1, INSTR(BNAME, '_') - 1) = '{category}'";
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                string[] X = new string[count];
                int[] Y = new int[count];
                int[] Y2 = new int[count];

                cmd.CommandText = $"SELECT * FROM BUPUM WHERE SUBSTR(BNAME, 1, INSTR(BNAME, '_') -1 ) = '{category}'";
                OracleDataReader rdr = cmd.ExecuteReader();

                int i = 0;
                while (rdr.Read())
                {
                    string bname = rdr["BNAME"] as string;
                    int binven = int.Parse(rdr["BINVEN"].ToString());
                    int bsales = int.Parse(rdr["BSALES"].ToString());

                    X[i] = bname;
                    Y[i] = binven;
                    Y2[i] = bsales;

                    i++;
                }

                rdr.Close(); // 데이터 리더 닫기

                chart1.Series[0].Points.DataBindXY(X, Y);
                chart1.Series[1].Points.DataBindXY(X, Y2);
            }
            else
            {
                MessageBox.Show($"No data found for {category}.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            panel1.Controls.Remove(page1);
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Add(page4);
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    IPAddress ipAddress = IPAddress.Parse("192.168.111.137");
        //    int port = 13005;

        //    TcpListener server = new TcpListener(ipAddress, port);
        //    Task.Run(() =>
        //    {
        //        server.Start();
        //        while (true)
        //        {
        //            TcpClient client = server.AcceptTcpClient();

        //            Com data = new Com();
        //            using (NetworkStream stream = client.GetStream())
        //            {
        //                byte[] buffer = new byte[1024];
        //                int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //                string jsonString = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        //                data = System.Text.Json.JsonSerializer.Deserialize<Com>(jsonString);
        //                Console.WriteLine($"Received TextBox1 value: {data.Cphone}");

        //                OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=" +
        //                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
        //                "(HOST=localhost)(PORT=1521)))" +
        //                "(CONNECT_DATA=(SERVER=DEDICATED)" +
        //                "(SERVICE_NAME=xe)));" +
        //                "User Id=hr;Password=hr;");

        //                conn.Open();
        //                OracleCommand cmd = new OracleCommand();
        //                cmd.Connection = conn;

        //                cmd.CommandText = $"SELECT * FROM custumer where cphone = '{data.Cphone}' ";
        //                OracleDataReader rdr = cmd.ExecuteReader();

        //                while (rdr.Read())
        //                {
        //                    data.Cid = rdr["cid"].ToString();
        //                    data.Cphone = rdr["cphone"] as string;
        //                    data.Cprice = rdr["CPRICE"].ToString();
        //                    data.Ctype = rdr["CTYPE"].ToString();
        //                    data.Cpu = rdr["cpu"] as string;
        //                    data.Gpu = rdr["gpu"] as string;
        //                    data.Cme = rdr["cme"] as string;
        //                    data.Cmb = rdr["cmb"] as string;
        //                    data.Ccase = rdr["ccase"] as string;
        //                    data.Cpw = rdr["cpw"] as string;
        //                    data.Cas1 = rdr["cas1"] as string;
        //                    data.Cas2 = rdr["cas2"] as string;
        //                    data.Cas3 = rdr["cas3"] as string;
        //                    data.Cas4 = rdr["cas4"] as string;
        //                    data.Cas5 = rdr["cas5"] as string;
        //                    data.Cas6 = rdr["cas6"] as string;
        //                    data.Cas7 = rdr["cas7"] as string;
        //                }
        //                string res = System.Text.Json.JsonSerializer.Serialize(data);
        //                byte[] message = Encoding.UTF8.GetBytes(res);
        //                stream.Write(message, 0, message.Length);
        //            }
        //            client.Close();
        //        }
        //        server.Stop();
        //    });
        //}
    }
    public class Com
    {
        public string Name { get; set; }
        public string Cid { get; set; }
        public string Cphone { get; set; }
        public string Ctime { get; set; }
        public string Ctype { get; set; }
        public string Cprice { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Cme { get; set; }
        public string Cmb { get; set; }
        public string Ccase { get; set; }
        public string Cpw { get; set; }
        public string Cas1 { get; set; }
        public string Cas2 { get; set; }
        public string Cas3 { get; set; }
        public string Cas4 { get; set; }
        public string Cas5 { get; set; }
        public string Cas6 { get; set; }
        public string Cas7 { get; set; }
        public string Opt { get; set; }

    }
}
