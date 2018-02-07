using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace linear_regression
{
    public partial class Analysis : Form
    {
        public DataSet ds;
        public int n;
        public int p;
        public Analysis()
        {
            InitializeComponent();
        }
        public string[] _name;

        public Analysis(string[] c_name, int _n, DataSet _ds,int _p)
        {
            InitializeComponent();
            int i = 0;
            n = _n;
            for (i = 0; i < n; i++)
            {
                listBox1.Items.Add(c_name[i]);
            }
            ds = _ds;
            p = _p;
            
        }



        private void Analysis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " && listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else if (textBox1.Text != " ")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = " ";
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                button1.Text = "确定";
            }
            else
            {
                button1.Text = "取消";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == " ")
            {
                button2.Text = "确定";
            }
            else
            {
                button2.Text = "取消";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == " " && listBox1.SelectedItem != null)
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else if (textBox2.Text != " ")
            {
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = " ";
            }
        }
        //字符串转double
        private double ToDouble(string strText)
        {
            double result;
            bool success = double.TryParse(strText, out result);
            if (success)
                return result;
            else
                return 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //如果为二次回归
            if (p == 2)
            {
                int i = 0;
                int m = ds.Tables[0].Rows.Count;
                for (i = 0; i < n; i++)
                {
                    if (textBox1.Text == ds.Tables[0].Columns[i].ColumnName)
                        break;
                }
                
                double[] x = new double[m];
                double[] y = new double[m];

                Dob_m dob = new Dob_m(m);
                int j = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //遍历列
                    dob.recive_x(ToDouble(dr[i].ToString()), j);
                    x[j] = ToDouble(dr[i].ToString());
                    j++;
                }
                for (i = 0; i < n; i++)
                {
                    if (textBox2.Text == ds.Tables[0].Columns[i].ColumnName)
                        break;
                }
                j = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //遍历列
                    dob.recive_y(ToDouble(dr[i].ToString()), j);
                    y[j] = ToDouble(dr[i].ToString());
                    j++;
                }
                dob.Double_Cal();
                double a, b, c,q;
                a = dob.get_a();
                b = dob.get_b();
                c = dob.get_c();
                q = dob.get_Q();
                gdi Gdi = new gdi(a, b,c, x, y, m, q, 2);                Gdi.Show();
            }
            //如果为一次回归
            else if(p==1)
            {
                int i = 0;
                int m = ds.Tables[0].Rows.Count;
                for (i = 0; i < n; i++)
                {
                    if (textBox1.Text == ds.Tables[0].Columns[i].ColumnName)
                        break;
                }
                //自变量，因变量
                double[] x = new double[m];
                double[] y = new double[m];
                Sle_m sle = new Sle_m(m);
                int j = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //遍历列
                    sle.recive_x(ToDouble(dr[i].ToString()), j);
                    x[j] = ToDouble(dr[i].ToString());
                    j++;
                }
                for (i = 0; i < n; i++)
                {
                    if (textBox2.Text == ds.Tables[0].Columns[i].ColumnName)
                        break;
                }
                j = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //遍历列
                    sle.recive_y(ToDouble(dr[i].ToString()), j);
                    y[j] = ToDouble(dr[i].ToString());
                    j++;
                }
                sle.Single_Cal();
                double a;
                double b;
                double q = 0;
                a = sle.get_a();
                b = sle.get_b();
                q = sle.get_Q();
                gdi Gdi = new gdi(a, b,0, x, y, m,q,1);
                Gdi.Show();
            }
                
           // MessageBox.Show(sle.get_a().ToString()+"\\"+ sle.get_b().ToString()+"\\" + sle.get_c().ToString()) ;
            
        }
    }
}
