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
    public partial class MulAnalysis :  Form
    {
        public DataSet ds;
        public int n;               //列数
        public MulAnalysis()
        {
            InitializeComponent();
        }
        public MulAnalysis(string[] c_name, int _n, DataSet _ds)
        {
            InitializeComponent();
            int i = 0;
            n = _n;
            for (i = 0; i < n; i++)
            {
                listBox1.Items.Add(c_name[i]);
            }
            ds = _ds;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            button1.Text = "取消";
        }

        private void MulAnalysis_Load(object sender, EventArgs e)
        {
            listBox1.SetSelected(0, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null && listBox1.SelectedItem != null)
            {
                listBox2.Items.Add( listBox1.SelectedItem.ToString());
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
           else if (listBox2.SelectedItem != null && listBox1.SelectedItem == null)
            {
               
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.ClearSelected();
            button1.Text = "确定";
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
        //
        private void button3_Click_1(object sender, EventArgs e)
        {
            int item_n = listBox2.Items.Count;
            int[] i = new int[item_n];
            int _i = 0;
            int _c = 0;
            int k = 0;
            int m = ds.Tables[0].Rows.Count;  //行数
            //获取自变量列索引，储存在i[]数组中
            for (_i = 0; _i < item_n; _i++)
            {
                for (k = 0; k < n; k++)
                {
                    if (listBox2.Items[_i].ToString() == ds.Tables[0].Columns[k].ColumnName)
                    {
                        i[_i] = k;
                    }
                }
            }

            double[] x = new double[m];
            double[] y = new double[m];
            Mul_m mul = new Mul_m(m, item_n);
            int j = 0;
            //因为不能传递指针，只能for循环传递数据
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //遍历列
                for (_i = 0; _i < item_n; _i++)
                {
                    mul.InputData_x(j, _i, ToDouble(dr[i[_i]].ToString()));
                }
                j++;
            }
            //因变量列索引
            for (_i = 0; _i < n; _i++)
            {
                if (textBox2.Text == ds.Tables[0].Columns[_i].ColumnName)
                    break;
            }
            j = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //遍历列
                mul.InputData_y(j,ToDouble(dr[_i].ToString()));
                j++;
            }
            mul.Mul_Cal2();                                             //计算
            Mul_display mus = new Mul_display(mul, item_n);
            mus.Show();
        }
    }
}
