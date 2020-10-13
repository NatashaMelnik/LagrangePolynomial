using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr4_LagrangePolynomial
{
    public partial class Form1 : Form
    {
        Graphics gr;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint,
                true);

            UpdateStyles();

            MainMenu();
        }

        private void MainMenu()
        {
            gr = this.CreateGraphics();
        }

        static double InterpolateLagrangePolynomial(double x, double[] xValues, double[] yValues, int size)
        {
            double lagrangePol = 0.0;
            for (int i = 0; i < size; i++)
            {
                double basicsPol = 1.0;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - xValues[j]) / (xValues[i] - xValues[j]);  
                    }
                }
                lagrangePol += basicsPol * yValues[i];
            }

            return lagrangePol;
        }

        private void Button1_Click(object sender, EventArgs e)
        {           
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            gr.DrawLine(new Pen(Color.Black, 4), 70, 100, 70, 950);
            gr.DrawLine(new Pen(Color.Black, 4), 60, 900, 70, 950);
            gr.DrawLine(new Pen(Color.Black, 4), 70, 950, 80, 900);
            gr.DrawLine(new Pen(Color.Black, 4), 70, 100, 1650, 100);
            gr.DrawLine(new Pen(Color.Black, 4), 1600, 90, 1650, 100);
            gr.DrawLine(new Pen(Color.Black, 4), 1600, 110, 1650, 100);

            const int size = 5;
            double[] xValues = new double[size] { Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text) };
            double[] yValues = new double[size] { Convert.ToDouble(textBox10.Text), Convert.ToDouble(textBox9.Text), Convert.ToDouble(textBox8.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox6.Text) };
            double h = (xValues[size - 1] - xValues[0]) / 99;
            int step = 0;

            for (double i = xValues[0]; i <= xValues[size - 1] + h; i += h)
            {
                step++;
                //Console.WriteLine(step + " " + InterpolateLagrangePolynomial(i, xValues, yValues, size));  

                int x_ = (int)Math.Truncate(i * 100);
                int y_ = (int)Math.Truncate(InterpolateLagrangePolynomial(i, xValues, yValues, size) * 100);

                gr.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x_, y_, 5, 5));

            }
        }
    }
}

