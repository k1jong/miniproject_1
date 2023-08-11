using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Server
{

    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        public async void OrderCom(string cphone, string price, string cpu, string gpu, string cme, string cmb, string ccase, string cpw, string cas1, string cas2, string cas3, string cas4, string cas5, string cas6, string cas7, string opt)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
             "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
             "(HOST=localhost)(PORT=1521)))" +
             "(CONNECT_DATA=(SERVER=DEDICATED)" +
             "(SERVICE_NAME=xe)));" +
             "User Id=hr;Password=hr;";
            OracleConnection conn = new OracleConnection(strConn);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            int _price = int.Parse(price);
            if (opt == "2")
            {
                
                cmd.CommandText = $"insert into custumer values (auto_increase.nextval,'{cphone}',sysdate,0,{_price},'{cpu}','{gpu}','{cme}X2','{cmb}','{ccase}','{cpw}','{cas1}','{cas2}','{cas3}','{cas4}','{cas5}','{cas6}','{cas7}')";
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = $"insert into custumer values (auto_increase.nextval,'{cphone}',sysdate,0,{_price},'{cpu}','{gpu}','{cme}','{cmb}','{ccase}','{cpw}','{cas1}','{cas2}','{cas3}','{cas4}','{cas5}','{cas6}','{cas7}')";
                cmd.ExecuteNonQuery();
            }
 

            cmd.CommandText = "SELECT cid FROM custumer where cid = (select Max(cid) from custumer)";
            string cid = cmd.ExecuteScalar().ToString();
            conn.Close();

            AppendText(($"주문번호{cid} :  컴퓨터 주문 \n"));
            Com com = await MakeCom(cid, price, cpu, gpu, cme, cmb, ccase, cpw, cas1, cas2, cas3, cas4, cas5, cas6, cas7, opt);
        }

        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task<Com> MakeCom(string cid, string price, string cpu, string gpu, string cme, string cmb, string ccase, string cpw, string cas1, string cas2, string cas3, string cas4, string cas5, string cas6, string cas7, string opt)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
             "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
             "(HOST=localhost)(PORT=1521)))" +
             "(CONNECT_DATA=(SERVER=DEDICATED)" +
             "(SERVICE_NAME=xe)));" +
             "User Id=hr;Password=hr;";

            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //3.서버와 함께 신나게 놀기
            //3.1 Query 명령객체 만들기
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn; //연결객체와 연동

            await _semaphore.WaitAsync();
            try
            {
                cmd.CommandText = $"SELECT binven FROM bupum WHERE bname = '{cpu}' OR bname = '{gpu}' OR bname = '{cme}' OR bname = '{cmb}' OR bname ='{ccase}' OR bname = '{cpw}' OR bname = '{cas1}'OR bname = '{cas2}'OR bname = '{cas3}'OR bname = '{cas4}'OR bname = '{cas5}'OR bname = '{cas6}'OR bname = '{cas7}'";
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int binven = reader.GetInt32(0);
                    if (binven <= 0)
                    {
                        AppendText($"재고가 부족합니다\n");

                        return null;
                       
                    }
                }

                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cpu}'";
                cmd.ExecuteNonQuery();
                if (gpu != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{gpu}'";
                    cmd.ExecuteNonQuery();
                }
                if (opt == "2")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cme}'";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cme}'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cme}'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cmb}'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{ccase}'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cpw}'";
                cmd.ExecuteNonQuery();

                if (cas1 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas1}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas2 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas2}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas3 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas3}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas4 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas4}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas5 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas5}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas6 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas6}'";
                    cmd.ExecuteNonQuery();
                }
                if (cas7 != "선택 안함")
                {
                    cmd.CommandText = $"UPDATE bupum SET binven = binven - 1, bsales = bsales + 1 WHERE bname = '{cas7}'";
                    cmd.ExecuteNonQuery();

                }


                //시작 부분
                // CPU, GPU , 메인보드,RAM, PW , HDD,SDD,QC

                AppendText(($"주문번호 {cid} : 컴퓨터 주문 제작 시작 \n"));
                await Task.Delay(1000);

                AppendText(($"주문번호 {cid} : {cpu} 삽입준비 \n"));
                pictureBox9.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                await Task.Delay(1000);



                AppendText(($"주문번호 {cid} : {cpu} 삽입중\n"));
                if (circularProgressBar1.InvokeRequired)
                    circularProgressBar1.Invoke(new Action(() => circularProgressBar1.Value++));
                else
                    circularProgressBar1.Value++;

                if ( circularProgressBar1.Value >2 ) 
                {
                    circularProgressBar1.ProgressColor = Color.Yellow;
                }
               if (circularProgressBar1.Value > 4)
                {
                    circularProgressBar1.ProgressColor = Color.Red;
                }
                pictureBox1.Load("C:\\Users\\Admin\\Desktop\\PC\\cpu.gif");
                pictureBox9.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                await Task.Delay(5000);


                AppendText(($"주문번호 {cid} : {cpu} 삽입완료 \n"));
                pictureBox9.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox18.Load("C:\\Users\\Admin\\Desktop\\PC\\오른쪽.gif");
                pictureBox1.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                await Task.Delay(1000);



                ////////////////////////////////////////////////////////////////////////////

                if (gpu != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {gpu} 삽입준비 \n"));
                    await Task.Delay(1000);
 
                    AppendText(($"주문번호 {cid} : {gpu} 삽입중 \n"));
                    if (circularProgressBar2.InvokeRequired)
                        circularProgressBar2.Invoke(new Action(() => circularProgressBar2.Value++));
                    else
                        circularProgressBar2.Value++;

                    if (circularProgressBar2.Value == 2)
                    {
                        circularProgressBar2.ProgressColor = Color.Yellow;
                    }
                    else if (circularProgressBar2.Value == 3)
                    {
                        circularProgressBar2.ProgressColor = Color.Red;
                    }
                    pictureBox2.Load("C:\\Users\\Admin\\Desktop\\PC\\gpu.gif");
                    pictureBox10.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {gpu} 삽입완료 \n"));
                    pictureBox19.Load("C:\\Users\\Admin\\Desktop\\PC\\오른쪽.gif");
                    pictureBox10.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                    pictureBox2.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                    await Task.Delay(1000);
                }
                else
                {
                    if (circularProgressBar2.InvokeRequired)
                        if(circularProgressBar2.Value != 0)
                        circularProgressBar2.Invoke(new Action(() => circularProgressBar2.Value--));
                    else
                            if(circularProgressBar2.Value != 0)
                        circularProgressBar2.Value--;

                    if (circularProgressBar2.Value == 2)
                    {
                        circularProgressBar2.ProgressColor = Color.Yellow;
                    }
                    else if (circularProgressBar2.Value == 3)
                    {
                        circularProgressBar2.ProgressColor = Color.Red;
                    }
                }
                ///////////////////////////////////////////////////////////////////////////

                AppendText(($"주문번호 {cid} : {cme} 삽입준비 \n"));
                await Task.Delay(1000);
                AppendText(($"주문번호 {cid} : {cme} 삽입중 \n"));
                if (circularProgressBar3.InvokeRequired)
                    circularProgressBar3.Invoke(new Action(() => circularProgressBar3.Value++));
                else
                    circularProgressBar3.Value++;

                if (circularProgressBar3.Value > 2)
                {
                    circularProgressBar3.ProgressColor = Color.Yellow;
                }
                if (circularProgressBar3.Value > 4)
                {
                    circularProgressBar3.ProgressColor = Color.Red;
                }
                pictureBox3.Load("C:\\Users\\Admin\\Desktop\\PC\\ram.gif");
                pictureBox11.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                await Task.Delay(5000);
                AppendText(($"주문번호 {cid} : {cme} 삽입완료 \n"));
                if (opt == "2")
                {
                    AppendText(($"주문번호 {cid} : {cme} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cme} 삽입중 \n"));
                    if (circularProgressBar3.InvokeRequired)
                        circularProgressBar3.Invoke(new Action(() => circularProgressBar3.Value++));
                    else
                        circularProgressBar3.Value++;

                    if (circularProgressBar3.Value > 2)
                    {
                        circularProgressBar3.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar3.Value > 4)
                    {
                        circularProgressBar3.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cme} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                pictureBox20.Load("C:\\Users\\Admin\\Desktop\\PC\\오른쪽.gif");
                pictureBox11.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox3.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                await Task.Delay(1000);
                //////////////////////////////////////////////////////////////////////////
                AppendText(($"주문번호 {cid} : {cmb} 삽입준비 \n"));
                pictureBox12.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                await Task.Delay(1000);
                AppendText(($"주문번호 {cid} : {cmb} 삽입중 \n"));
                if (circularProgressBar4.InvokeRequired)
                    circularProgressBar4.Invoke(new Action(() => circularProgressBar4.Value++));
                else
                    circularProgressBar4.Value++;

                if (circularProgressBar4.Value > 2)
                {
                    circularProgressBar4.ProgressColor = Color.Yellow;
                }
                if (circularProgressBar4.Value > 4)
                {
                    circularProgressBar4.ProgressColor = Color.Red;
                }
                pictureBox4.Load("C:\\Users\\Admin\\Desktop\\PC\\main.gif");
                pictureBox12.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                await Task.Delay(5000);
                AppendText(($"주문번호 {cid} : {cmb} 삽입완료 \n"));
                pictureBox21.Load("C:\\Users\\Admin\\Desktop\\PC\\아래.gif");
                pictureBox12.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox4.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                await Task.Delay(1000);
                ///////////////////////////////////////////////////////////////////////////
                AppendText(($"주문번호 {cid} : {cpw} 삽입준비 \n"));
                await Task.Delay(1000);
                pictureBox13.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                AppendText(($"주문번호 {cid} : {cpw} 삽입중 \n"));
                if (circularProgressBar5.InvokeRequired)
                    circularProgressBar5.Invoke(new Action(() => circularProgressBar5.Value++));
                else
                    circularProgressBar5.Value++;

                if (circularProgressBar5.Value > 2)
                {
                    circularProgressBar5.ProgressColor = Color.Yellow;
                }
                if (circularProgressBar5.Value > 4)
                {
                    circularProgressBar5.ProgressColor = Color.Red;
                }
                pictureBox5.Load("C:\\Users\\Admin\\Desktop\\PC\\pw.gif");
                pictureBox13.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                pictureBox22.Load("C:\\Users\\Admin\\Desktop\\PC\\왼.png");
                await Task.Delay(5000);
                AppendText(($"주문번호 {cid} : {cpw} 삽입완료 \n"));
                pictureBox22.Load("C:\\Users\\Admin\\Desktop\\PC\\왼쪽.gif");
                pictureBox13.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox5.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                await Task.Delay(1000);
                ////////////////////////////////////////////////////////////////////////////////////


                //HDD
                pictureBox14.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox14.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                pictureBox6.Load("C:\\Users\\Admin\\Desktop\\PC\\hdd.gif");
                if (cas1 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas1} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas1} 삽입중 \n"));
                    if (circularProgressBar6.InvokeRequired)
                        circularProgressBar6.Invoke(new Action(() => circularProgressBar6.Value++));
                    else
                        circularProgressBar6.Value++;

                    if (circularProgressBar6.Value > 2)
                    {
                        circularProgressBar6.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar6.Value > 4)
                    {
                        circularProgressBar6.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas1} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                if (cas2 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas2} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas2} 삽입중 \n"));
                    if(circularProgressBar6.Value != circularProgressBar6.Maximum)
                    {
                        if (circularProgressBar6.InvokeRequired)
                            circularProgressBar6.Invoke(new Action(() => circularProgressBar6.Value++));
                        else
                            circularProgressBar6.Value++;
                    }
                    if (circularProgressBar6.Value > 2)
                    {
                        circularProgressBar6.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar6.Value > 4)
                    {
                        circularProgressBar6.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas2} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                if (cas3 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas3} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas3} 삽입중 \n"));
                    if (circularProgressBar6.Value != circularProgressBar6.Maximum)
                    {
                        if (circularProgressBar6.Value != circularProgressBar6.Maximum)
                        {
                            if (circularProgressBar6.InvokeRequired)
                                circularProgressBar6.Invoke(new Action(() => circularProgressBar6.Value++));
                            else
                                circularProgressBar6.Value++;
                        }
                    }
                    if (circularProgressBar6.Value > 2)
                    {
                        circularProgressBar6.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar6.Value > 4)
                    {
                        circularProgressBar6.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas3} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                pictureBox23.Load("C:\\Users\\Admin\\Desktop\\PC\\왼쪽.gif");
                pictureBox14.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox6.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");
                await Task.Delay(1000);

                ////////////////////////////////////////////////////////////////////////////////////
                //SSD
                pictureBox15.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox15.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                pictureBox7.Load("C:\\Users\\Admin\\Desktop\\PC\\ssd.gif");
                if (cas4 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas4} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas4} 삽입중 \n"));
                    if (circularProgressBar7.Value != circularProgressBar7.Maximum)
                    {
                        if (circularProgressBar7.InvokeRequired)
                            circularProgressBar7.Invoke(new Action(() => circularProgressBar7.Value++));
                        else
                            circularProgressBar7.Value++;
                    }

                    if (circularProgressBar7.Value > 2)
                    {
                        circularProgressBar7.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar7.Value > 4)
                    {
                        circularProgressBar7.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas4} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                if (cas5 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas5} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas5} 삽입중 \n"));
                    if (circularProgressBar7.Value != circularProgressBar7.Maximum)
                    {
                        if (circularProgressBar7.InvokeRequired)
                            circularProgressBar7.Invoke(new Action(() => circularProgressBar7.Value++));
                        else
                            circularProgressBar7.Value++;
                    }


                    if (circularProgressBar7.Value >2)
                    {
                        circularProgressBar7.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar7.Value > 4)
                    {
                        circularProgressBar7.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas5} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                if (cas6 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas6} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas6} 삽입중 \n"));
                    if (circularProgressBar7.Value != circularProgressBar7.Maximum)
                    {
                        if (circularProgressBar7.InvokeRequired)
                            circularProgressBar7.Invoke(new Action(() => circularProgressBar7.Value++));
                        else
                            circularProgressBar7.Value++;
                    }
                    if (circularProgressBar7.Value > 2)
                    {
                        circularProgressBar7.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar7.Value > 4)
                    {
                        circularProgressBar7.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas6} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                if (cas7 != "선택 안함")
                {
                    AppendText(($"주문번호 {cid} : {cas7} 삽입준비 \n"));
                    await Task.Delay(1000);
                    AppendText(($"주문번호 {cid} : {cas7} 삽입중 \n"));
                    if (circularProgressBar7.Value != circularProgressBar7.Maximum)
                    {
                        if (circularProgressBar7.InvokeRequired)
                            circularProgressBar7.Invoke(new Action(() => circularProgressBar7.Value++));
                        else
                            circularProgressBar7.Value++;
                    }
                    if (circularProgressBar7.Value > 2)
                    {
                        circularProgressBar7.ProgressColor = Color.Yellow;
                    }
                    if (circularProgressBar7.Value > 4)
                    {
                        circularProgressBar7.ProgressColor = Color.Red;
                    }
                    await Task.Delay(5000);
                    AppendText(($"주문번호 {cid} : {cas7} 삽입완료 \n"));
                    await Task.Delay(1000);
                }
                pictureBox24.Load("C:\\Users\\Admin\\Desktop\\PC\\왼쪽.gif");
                pictureBox15.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox7.Load("C:\\Users\\Admin\\Desktop\\PC\\pc.jpg");

                //////////////////////////////////////////////////////////////////////////
                AppendText(($"주문번호 {cid} : QC과정 준비 \n"));
                pictureBox17.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                await Task.Delay(1000);

                AppendText(($"주문번호 {cid} : QC과정 진행중 \n"));
                if (circularProgressBar8.Value != circularProgressBar8.Maximum)
                {
                    if (circularProgressBar8.InvokeRequired)
                        circularProgressBar8.Invoke(new Action(() => circularProgressBar8.Value++));
                    else
                        circularProgressBar7.Value++;
                }
                if (circularProgressBar8.Value > 2)
                {
                    circularProgressBar8.ProgressColor = Color.Yellow;
                }
                if (circularProgressBar8.Value > 4)
                {
                    circularProgressBar8.ProgressColor = Color.Red;
                }
                pictureBox8.Load("C:\\Users\\Admin\\Desktop\\PC\\검수.gif");
                pictureBox17.Load("C:\\Users\\Admin\\Desktop\\PC\\노.jpg");
                await Task.Delay(5000);

                AppendText(($"주문번호 {cid} : QC과정 완료 \n"));
                pictureBox17.Load("C:\\Users\\Admin\\Desktop\\PC\\초.jpg");
                pictureBox8.Load("C:\\Users\\Admin\\Desktop\\PC\\검수 정지.png");
                await Task.Delay(1000);



                AppendText(($"주문번호 {cid} : 제작 완료 \n"));
                if(circularProgressBar1.Value == circularProgressBar1.Maximum || circularProgressBar2.Value == circularProgressBar2.Maximum || circularProgressBar3.Value == circularProgressBar3.Maximum || circularProgressBar4.Value == circularProgressBar4.Maximum  || circularProgressBar5.Value == circularProgressBar5.Maximum || circularProgressBar6.Value == circularProgressBar6.Maximum || circularProgressBar8.Value == circularProgressBar8.Maximum || circularProgressBar7.Value == circularProgressBar7.Maximum)
                {
                    AppendText("장비 과열 식힘\n");
                    await Task.Delay(5000);
                    if (circularProgressBar1.InvokeRequired)
                        circularProgressBar1.Invoke(new Action(() => circularProgressBar1.Value=0));
                    else
                        circularProgressBar1.Value = 0;

                    if (circularProgressBar2.InvokeRequired)
                        circularProgressBar2.Invoke(new Action(() => circularProgressBar2.Value = 0));
                    else
                        circularProgressBar2.Value = 0;

                    if (circularProgressBar3.InvokeRequired)
                        circularProgressBar3.Invoke(new Action(() => circularProgressBar3.Value = 0));
                    else
                        circularProgressBar3.Value = 0;

                    if (circularProgressBar4.InvokeRequired)
                        circularProgressBar4.Invoke(new Action(() => circularProgressBar4.Value = 0));
                    else
                        circularProgressBar4.Value = 0;

                    if (circularProgressBar5.InvokeRequired)
                        circularProgressBar5.Invoke(new Action(() => circularProgressBar5.Value = 0));
                    else
                        circularProgressBar5.Value = 0;

                    if (circularProgressBar6.InvokeRequired)
                        circularProgressBar6.Invoke(new Action(() => circularProgressBar6.Value = 0));
                    else
                        circularProgressBar6.Value = 0;

                    if (circularProgressBar7.InvokeRequired)
                        circularProgressBar7.Invoke(new Action(() => circularProgressBar7.Value = 0));
                    else
                        circularProgressBar7.Value = 0;

                    if (circularProgressBar8.InvokeRequired)
                        circularProgressBar8.Invoke(new Action(() => circularProgressBar8.Value = 0));
                    else
                        circularProgressBar8.Value = 0;

                    circularProgressBar1.ProgressColor = Color.Lime;
                    circularProgressBar2.ProgressColor = Color.Lime;
                    circularProgressBar3.ProgressColor = Color.Lime;
                    circularProgressBar4.ProgressColor = Color.Lime;
                    circularProgressBar5.ProgressColor = Color.Lime;
                    circularProgressBar6.ProgressColor = Color.Lime;
                    circularProgressBar7.ProgressColor = Color.Lime;
                    circularProgressBar8.ProgressColor = Color.Lime;
                }
                pictureBox9.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox10.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox11.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox12.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox13.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox14.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox15.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");
                pictureBox17.Load("C:\\Users\\Admin\\Desktop\\PC\\빨.jpg");

                pictureBox18.Load("C:\\Users\\Admin\\Desktop\\PC\\오.png");
                pictureBox19.Load("C:\\Users\\Admin\\Desktop\\PC\\오.png");
                pictureBox20.Load("C:\\Users\\Admin\\Desktop\\PC\\오.png");
                pictureBox21.Load("C:\\Users\\Admin\\Desktop\\PC\\아.png");
                pictureBox22.Load("C:\\Users\\Admin\\Desktop\\PC\\왼.png");
                pictureBox23.Load("C:\\Users\\Admin\\Desktop\\PC\\왼.png");
                pictureBox24.Load("C:\\Users\\Admin\\Desktop\\PC\\왼.png");

            }
            finally
            {
                _semaphore.Release();
            }
            cmd.CommandText = $"UPDATE custumer SET ctype=1 WHERE cid = '{cid}'";
            cmd.ExecuteNonQuery();
            conn.Close();

            return new Com { Cid = cid, Cpu = cpu, Gpu = gpu };
        }
        private void AppendText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                richTextBox1.AppendText(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 13000;

            TcpListener server = new TcpListener(ipAddress, port);
            Task.Run(() =>
            {
                server.Start();
                AppendText("서버를 시작합니다...\n");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        try
                        {
                            Com comData = JsonSerializer.Deserialize<Com>(receivedData);
                            string cphone = $"{comData.Cphone}";
                            string price = $"{comData.Cprice}";
                            string cpu = $"{comData.Cpu}";
                            string gpu = $"{comData.Gpu}";
                            string cme = $"{comData.Cme}";
                            string cmb = $"{comData.Cmb}";
                            string ccase = $"{comData.Ccase}";
                            string cpw = $"{comData.Cpw}";
                            string cas1 = $"{comData.Cas1}";
                            string cas2 = $"{comData.Cas2}";
                            string cas3 = $"{comData.Cas3}";
                            string cas4 = $"{comData.Cas4}";
                            string cas5 = $"{comData.Cas5}";
                            string cas6 = $"{comData.Cas6}";
                            string cas7 = $"{comData.Cas7}";
                            string opt = $"{comData.Opt}";
                            Thread t = new Thread(() =>
                              OrderCom(cphone, price, cpu, gpu, cme, cmb, ccase, cpw, cas1, cas2, cas3, cas4, cas5, cas6, cas7, opt));
                            t.IsBackground = true;
                            t.Start();
                            t.Join();
                        }
                        catch (JsonException ex)
                        {
                        
                        }
                    }
                    client.Close();
                }
                server.Stop();
            });
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
            circularProgressBar2.Value = 0;
            circularProgressBar3.Value = 0;
            circularProgressBar4.Value = 0;
            circularProgressBar5.Value = 0;
            circularProgressBar6.Value = 0;
            circularProgressBar7.Value = 0;
            circularProgressBar8.Value = 0;
        }
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
