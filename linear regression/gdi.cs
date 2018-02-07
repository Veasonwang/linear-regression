using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linear_regression
{
    public partial class gdi : Form
    {
        public double a, b,c;
        public double[] x, y;
        double x_a;
        double y_a;
        double q;
        int length;
        int pw;                                //一次拟合二次拟合
        public gdi()
        {
            InitializeComponent();
        }
        private void PaintDraw()
        {
            //创建一个画图图面
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //创建一只笔
            Pen pen = new Pen(Brushes.Red);
            //直线的两个坐标
            //  double x_1 = 100*b / a;
            Point pointStart = new Point(40, 180);
            Point pointEnd = new Point(600, 180);

            //开始画
            g.DrawLine(pen, pointStart, pointEnd);
            //
            pointStart = new Point(40, 350);
            pointEnd = new Point(40, 10);
            g.DrawLine(pen, pointStart, pointEnd);
            //缩放倍数
            double x_bs = 1;
            double y_bs = 1;
            x_bs = (int)((600 / x_a) * 0.3);
            y_bs = (int)((150 / y_a) * 0.3);


            Pen pen1 = new Pen(Brushes.Blue);
            pointStart = new Point(40, (int)(180 - y_bs * b));
            pointEnd = new Point(40 + 600, 180 - (int)((600 * a / x_bs + b) * y_bs));
            g.DrawLine(pen1, pointStart, pointEnd);

            Pen p = new Pen(Color.Black, 2);
            Graphics g1 = CreateGraphics();

            for (int i = 0; i < length; i++)
            {
                x[i] = x_bs * x[i];
                y[i] = y_bs * y[i];
                g1.DrawEllipse(p, 40 + (float)x[i], (float)(180 - y[i]), 2, 2);
            }
            label1.Text = "y=" + a.ToString("f4") + "x+" + b.ToString("f4");
            label2.Text = (600 / x_bs).ToString();
            label3.Text = (180 / y_bs).ToString();
            label4.Text = (90 / y_bs).ToString();
            label5.Text = (300 / x_bs).ToString();
            label6.Text = "残差平方和SSE=" + q.ToString();
            //  g1.DrawEllipse(p, 200, 200, 1, 1);
        }
        double f2(double x)
        {
            return a * x * x + b * x + c;
        }                //拟合的二次函数，绘图用
        //二次函数绘图
        private void PaintDraw2()   
        {
            //创建一个画图图面
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //创建一只笔
            Pen pen = new Pen(Brushes.Red);
            //直线的两个坐标
            //  double x_1 = 100*b / a;
            Point pointStart = new Point(40, 180);
            Point pointEnd = new Point(600, 180);

            //开始画
            g.DrawLine(pen, pointStart, pointEnd);
            //
            pointStart = new Point(40, 350);
            pointEnd = new Point(40, 10);
            g.DrawLine(pen, pointStart, pointEnd);
            //缩放倍数
            double x_bs = 1;
            double y_bs = 1;
            x_bs = (int)((600 / x_a) * 0.3);
            y_bs = (int)((150 / y_a) * 0.3);
            //绘制函数曲线
            double __x;
            double __x_1;
            Pen pen1 = new Pen(Brushes.Blue);
            for (int i = 0; i < 30; i++)
            {
                __x = (600) * i / (30);
                __x = __x / x_bs;
                __x_1 = (600) * (i+1) / (30);
                __x_1 = __x_1 / x_bs;
                pointStart = new Point(40 +(int)(__x*x_bs), 180 - (int)(f2(__x)*y_bs));
                pointEnd = new Point(40 + (int)(__x_1*x_bs), 180-(int)(f2(__x_1) *y_bs));
                g.DrawLine(pen1, pointStart, pointEnd);
            }


            Pen p = new Pen(Color.Black, 2);
            Graphics g1 = CreateGraphics();

            for (int i = 0; i < length; i++)
            {
                x[i] = x_bs * x[i];
                y[i] = y_bs * y[i];
                g1.DrawEllipse(p, 40 + (float)x[i], (float)(180 - y[i]), 2, 2);
            }
            label1.Text = "y=" + a.ToString("f4") + "x_2+" + b.ToString("f4")+"x+"+c.ToString("f4");
            label2.Text = (600 / x_bs).ToString();
            label3.Text = (180 / y_bs).ToString();
            label4.Text = (90 / y_bs).ToString();
            label5.Text = (300 / x_bs).ToString();
            label6.Text = "残差平方和Q=" + q.ToString();
            //  g1.DrawEllipse(p, 200, 200, 1, 1);
        }
        int control = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (control == 0)       //控制变量
            {
                if (pw == 1)
                {
                    PaintDraw();
                }
                if (pw == 2)
                {
                    PaintDraw2();
                }
                control++;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            //创建一个画图图面
            Graphics g = this.CreateGraphics();
            //创建一只笔
            Pen pen = new Pen(Brushes.Red);
            //直线的两个坐标
            //  double x_1 = 100*b / a;
            Point pointStart = new Point(40, 180);
            Point pointEnd = new Point(600, 180);

            //开始画
            g.DrawLine(pen, pointStart, pointEnd);
            //
            pointStart = new Point(40, 350);
            pointEnd = new Point(40, 10);
            g.DrawLine(pen, pointStart, pointEnd);

            int x_bs = 1;
            int y_bs = 1;
            x_bs = (int)((600 / x_a) * 0.3);
            y_bs = (int)((150 / y_a) * 0.3);

            Pen pen1 = new Pen(Brushes.Blue);
            pointStart = new Point(40, (int)(180 - y_bs * b));
            pointEnd = new Point(40 + 600, 180 - (int)(600 * a / x_bs + b) * y_bs);
            g.DrawLine(pen1, pointStart, pointEnd);

            Pen p = new Pen(Color.Black, 2);
            Graphics g1 = CreateGraphics();

            for (int i = 0; i < length; i++)
            {
                x[i] = x_bs * x[i];
                y[i] = y_bs * y[i];
                g1.DrawEllipse(p, 40 + (float)x[i], (float)(180 - y[i]), 2, 2);
            }
            label1.Text = "y=" + a.ToString() + "x+" + b.ToString();
            label2.Text = (600 / x_bs).ToString();
            label3.Text = (180 / y_bs).ToString();
            label4.Text = (90 / y_bs).ToString();
            label5.Text = (300 / x_bs).ToString();*/
        }

        public gdi(double _a,double _b,double _c,double[] _x,double[] _y,int _length,double Q,int _pw)
        {
            InitializeComponent();
            a = _a;
            b = _b;
            c = _c;
            x = _x;
            y = _y;
            length = _length;
            x_a = 0;
            y_a = 0;
            for(int i=0;i< length;i++)
            {
                x_a = x_a + (x[i] / length);
                y_a = y_a + (y[i] / length);
            }
            q = Q;
            pw = _pw;
        }

        private void gdi_Load(object sender, EventArgs e)
        {
           // PaintDraw();
        }
    }
}
