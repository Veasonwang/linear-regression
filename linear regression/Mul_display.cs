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
    public partial class Mul_display : Form
    {
        public int width;
        public double[] bs;
        public double b0;
        public Mul_m mul_m;
        public Mul_display()
        {
            InitializeComponent();
        }
        public Mul_display(Mul_m mul,int _width)
        {
            InitializeComponent();
            width = _width;
            bs = new double[width+1];
            for(int i=0;i<= width;i++)
            {
                bs[i] = mul.get_M_rs(i);
            }
            mul.Calferroe();
            mul_m = mul;
        }

        private void Mul_display_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column 1");    //添加列1
            dt.Columns.Add("Column 2");
            for(int i=0;i<=width;i++)
            {
                dt.Rows.Add();
            }
            dt.Rows[0][0] = "系数b0" ;
            dt.Rows[0][1] = bs[0];
            for (int i=0;i< width;i++)
            {
                dt.Rows[i+1][0] = "系数b"+(i+1).ToString();
                dt.Rows[i+1][1] = bs[i+1];
            }
            dt.Rows.Add();
            dt.Rows.Add();
            dt.Rows.Add();
            dt.Rows.Add();
            dt.Rows[width+1][0] = "残差平方和SSE";
            dt.Rows[width + 1][1] = mul_m.getSSE();
            dt.Rows[width + 2][0] = "回归平方和SSR";
            dt.Rows[width +2][1] = mul_m.getSSR();
            dt.Rows[width + 3][0] = "总离差平方和SST";
            dt.Rows[width + 3][1] = mul_m.getSST();
            dt.Rows[width + 4][0] = "检验统计量F";
            dt.Rows[width + 4][1] = mul_m.getF();
            //绑定数据
            dataGridView1.DataSource = dt;
        }
    }
}
