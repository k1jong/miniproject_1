namespace Server
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rebtn = new System.Windows.Forms.Button();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.backbtn = new System.Windows.Forms.Button();
            this.gpubtn = new System.Windows.Forms.Button();
            this.mainbtn = new System.Windows.Forms.Button();
            this.pwbtn = new System.Windows.Forms.Button();
            this.casebtn = new System.Windows.Forms.Button();
            this.memobtn = new System.Windows.Forms.Button();
            this.cpubtn = new System.Windows.Forms.Button();
            this.memo2btn = new System.Windows.Forms.Button();
            this.groupbox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // rebtn
            // 
            this.rebtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rebtn.Location = new System.Drawing.Point(724, 437);
            this.rebtn.Name = "rebtn";
            this.rebtn.Size = new System.Drawing.Size(111, 32);
            this.rebtn.TabIndex = 0;
            this.rebtn.Text = "갱신하기";
            this.rebtn.UseVisualStyleBackColor = true;
            this.rebtn.Click += new System.EventHandler(this.rebtn_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.panel1);
            this.groupbox1.Location = new System.Drawing.Point(12, 5);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(870, 580);
            this.groupbox1.TabIndex = 1;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "통계";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 551);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rebtn);
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.time);
            this.panel2.Location = new System.Drawing.Point(12, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(861, 557);
            this.panel2.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "CPU1판매량";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "CPU1판매량";
            series1.Name = "CPU 판매량";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(855, 492);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(19, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "마지막 갱신 시간 :";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.time.Location = new System.Drawing.Point(175, 525);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(45, 16);
            this.time.TabIndex = 4;
            this.time.Text = "Time";
            // 
            // backbtn
            // 
            this.backbtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.backbtn.Location = new System.Drawing.Point(889, 547);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(111, 32);
            this.backbtn.TabIndex = 5;
            this.backbtn.Text = "뒤로 가기";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // gpubtn
            // 
            this.gpubtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gpubtn.Location = new System.Drawing.Point(888, 93);
            this.gpubtn.Name = "gpubtn";
            this.gpubtn.Size = new System.Drawing.Size(111, 32);
            this.gpubtn.TabIndex = 6;
            this.gpubtn.Text = "GPU판매량";
            this.gpubtn.UseVisualStyleBackColor = true;
            this.gpubtn.Click += new System.EventHandler(this.gpubtn_Click);
            // 
            // mainbtn
            // 
            this.mainbtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mainbtn.Location = new System.Drawing.Point(888, 348);
            this.mainbtn.Name = "mainbtn";
            this.mainbtn.Size = new System.Drawing.Size(111, 32);
            this.mainbtn.TabIndex = 7;
            this.mainbtn.Text = "매인보드 판매량";
            this.mainbtn.UseVisualStyleBackColor = true;
            this.mainbtn.Click += new System.EventHandler(this.mainbtn_Click);
            // 
            // pwbtn
            // 
            this.pwbtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pwbtn.Location = new System.Drawing.Point(889, 409);
            this.pwbtn.Name = "pwbtn";
            this.pwbtn.Size = new System.Drawing.Size(111, 32);
            this.pwbtn.TabIndex = 8;
            this.pwbtn.Text = "파워 판매량";
            this.pwbtn.UseVisualStyleBackColor = true;
            this.pwbtn.Click += new System.EventHandler(this.pwbtn_Click);
            // 
            // casebtn
            // 
            this.casebtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.casebtn.Location = new System.Drawing.Point(888, 151);
            this.casebtn.Name = "casebtn";
            this.casebtn.Size = new System.Drawing.Size(111, 32);
            this.casebtn.TabIndex = 9;
            this.casebtn.Text = "케이스 판매량";
            this.casebtn.UseVisualStyleBackColor = true;
            this.casebtn.Click += new System.EventHandler(this.casebtn_Click);
            // 
            // memobtn
            // 
            this.memobtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memobtn.Location = new System.Drawing.Point(889, 213);
            this.memobtn.Name = "memobtn";
            this.memobtn.Size = new System.Drawing.Size(111, 32);
            this.memobtn.TabIndex = 10;
            this.memobtn.Text = "주메모리 판매량";
            this.memobtn.UseVisualStyleBackColor = true;
            this.memobtn.Click += new System.EventHandler(this.memobtn_Click);
            // 
            // cpubtn
            // 
            this.cpubtn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cpubtn.Location = new System.Drawing.Point(889, 32);
            this.cpubtn.Name = "cpubtn";
            this.cpubtn.Size = new System.Drawing.Size(111, 32);
            this.cpubtn.TabIndex = 11;
            this.cpubtn.Text = "CPU판매량";
            this.cpubtn.UseVisualStyleBackColor = true;
            this.cpubtn.Click += new System.EventHandler(this.cpubtn_Click_1);
            // 
            // memo2btn
            // 
            this.memo2btn.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memo2btn.Location = new System.Drawing.Point(889, 281);
            this.memo2btn.Name = "memo2btn";
            this.memo2btn.Size = new System.Drawing.Size(111, 32);
            this.memo2btn.TabIndex = 12;
            this.memo2btn.Text = "보조메모리 판매량";
            this.memo2btn.UseVisualStyleBackColor = true;
            this.memo2btn.Click += new System.EventHandler(this.memo2btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 597);
            this.Controls.Add(this.memo2btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cpubtn);
            this.Controls.Add(this.mainbtn);
            this.Controls.Add(this.memobtn);
            this.Controls.Add(this.casebtn);
            this.Controls.Add(this.pwbtn);
            this.Controls.Add(this.gpubtn);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.groupbox1);
            this.Name = "Form2";
            this.Text = "Server";
            this.groupbox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rebtn;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button gpubtn;
        private System.Windows.Forms.Button mainbtn;
        private System.Windows.Forms.Button pwbtn;
        private System.Windows.Forms.Button casebtn;
        private System.Windows.Forms.Button memobtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cpubtn;
        private System.Windows.Forms.Button memo2btn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label time;
    }
}