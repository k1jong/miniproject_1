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
    public partial class Form3 : Form
    {
        private System.Windows.Forms.Timer timer;
        public Form3()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 6500; 
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
