namespace Server
{
    partial class UserControl9
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart7 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rebtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).BeginInit();
            this.SuspendLayout();
            // 
            // chart7
            // 
            chartArea1.Name = "ChartArea1";
            this.chart7.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart7.Legends.Add(legend1);
            this.chart7.Location = new System.Drawing.Point(3, 13);
            this.chart7.Name = "chart7";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "보조 메모리 판매량";
            this.chart7.Series.Add(series1);
            this.chart7.Size = new System.Drawing.Size(855, 505);
            this.chart7.TabIndex = 0;
            this.chart7.Text = "chart1";
            // 
            // rebtn
            // 
            this.rebtn.Location = new System.Drawing.Point(724, 437);
            this.rebtn.Name = "rebtn";
            this.rebtn.Size = new System.Drawing.Size(111, 32);
            this.rebtn.TabIndex = 1;
            this.rebtn.Text = "갱신하기";
            this.rebtn.UseVisualStyleBackColor = true;
            this.rebtn.Click += new System.EventHandler(this.rebtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(239, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(56, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "마지막 갱신 시간 :";
            // 
            // UserControl9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rebtn);
            this.Controls.Add(this.chart7);
            this.Name = "UserControl9";
            this.Size = new System.Drawing.Size(1048, 589);
            ((System.ComponentModel.ISupportInitialize)(this.chart7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart7;
        public System.Windows.Forms.Button rebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}