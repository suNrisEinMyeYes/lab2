using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    
    public partial class Form1 : Form
    {

        private decimal xMax; 
        private decimal yMax;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 500;
        }
        
        int i = 0;
        decimal t, x0, y0, v0, cosa, sina;

        private void Resume_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        const decimal g = 9.81M;
        const decimal dt = 0.1M;

        private void Launch_Click(object sender, EventArgs e)
        {

            timer1.Start();

            chart1.Series[0].Points.Clear();

                t = 0;

                x0 = 0;

                y0 = inputHeight.Value;

                v0 = inputSpeed.Value;

                double a = (double)inputAngle.Value * Math.PI / 180;

                cosa = (decimal)Math.Cos(a);

                sina = (decimal)Math.Sin(a);

                xMax = ((v0 * v0 * (decimal)Math.Sin(2 * a)) / g) +y0;

                yMax = y0 + (v0 * v0 * sina * sina) / (2 * g);

                chart1.ChartAreas[0].AxisX.Maximum = (double)xMax * 1.3;
                chart1.ChartAreas[0].AxisY.Maximum = (double)yMax*1.2;
                chart1.Series[0].Points.AddXY(x0, y0);

            timer1.Start();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = t.ToString();
            t += dt;

            decimal x = x0 + v0 * cosa * t;

            decimal y = y0 + v0 * sina * t - g * t * t / 2;

            chart1.Series[0].Points.AddXY(x, y);

            //inputHeight.Value = y;
            if (y < 0) timer1.Stop();
        }

    }
}
