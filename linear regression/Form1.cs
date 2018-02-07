using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
//[DllImport("eigen")]
//private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
/*2014级地信班，王文松，数字地球科学期末作业第一题。
采用C#、C++混合编程，C#负责界面设计制作，C++负责矩阵计算。
*/

namespace linear_regression
{
    //[DllImport("eigen.dll")]
    public partial class Form1 : Form
    {
        //[DllImport("eigen")]
        //private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.RowHeadersVisible = false;
            // dataGridView1.ColumnHeadersVisible = false;
            //DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < 30; i++)
            {
                int index = this.dataGridView1.Rows.Add();
            }
            // this.dataGridView1.Rows[index].Cells[0].Value = "1";
        }



        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;

                string v_Line = v_LineNo.ToString();

                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
        public DataSet ExcelToDS(string Path)
        {
            // string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            //OleDbConnection conn = new OleDbConnection(strConn);
            // DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            // string tableName = schemaTable.Rows[0][2].ToString().Trim();
            /*
             string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
             OleDbConnection conn = new OleDbConnection(strConn);
             conn.Open();

             DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
             string tableName = schemaTable.Rows[0][2].ToString().Trim();
             string strExcel = "";
             MessageBox.Show(tableName);
             OleDbDataAdapter myCommand = null;
             DataSet ds = null;
             strExcel = "select * from "+ tableName;
             myCommand = new OleDbDataAdapter(strExcel, strConn);
             ds = new DataSet();
             myCommand.Fill(ds, "table1");
             return ds;*/

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            //
            DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();

            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            ds = null;
            strExcel = "select * from [" + tableName + "]";
            // MessageBox.Show(strExcel);
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //文件操作，获取数据仅支持xls格式，若为xlsx请转换为xls格式
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.InitialDirectory = " ";
            fbd.Title = "请选择文件";
            fbd.Filter = "所有文件(*.xls)|*.xls";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                int n = dataGridView1.ColumnCount;
                int i = 0;
                //   for (i = 0; i < dataGridView1.Columns.Count; i++) if (dataGridView1.Columns[i].Visible == true) n++;
                for (i = 0; i < n; i++)
                {
                    // MessageBox.Show(dataGridView1.ColumnCount.ToString());
                    dataGridView1.Columns.Remove(dataGridView1.Columns[0]);
                    //  dataGridView1.Columns.RemoveAt(0);
                    //MessageBox.Show("11",i.ToString());
                }
                dataGridView1.AutoGenerateColumns = true;
                DataSet ds = new DataSet();
                dataGridView1.DataSource = ExcelToDS(fbd.FileName).Tables[0];

                //MessageBox.Show("");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       /* private void 分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (ds != null)
            {
                dt = ds.Tables[0];
                //遍历行
                int n = dataGridView1.ColumnCount;
                string[] col_name = new string[n];
                int i = 0;

                for (i = 0; i < n; i++)
                {
                    col_name[i] = dataGridView1.Columns[i].HeaderText;
                }
                Analysis AnalyWnd = new Analysis(col_name, n,ds);
                AnalyWnd.Show();
            }
            else
            {
                MessageBox.Show("请读取数据!");
            }
        }*/

        private void 多元分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (ds != null)
            {
                dt = ds.Tables[0];
                //遍历行
                int n = dataGridView1.ColumnCount;
                string[] col_name = new string[n];
                int i = 0;

                for (i = 0; i < n; i++)
                {
                    col_name[i] = dataGridView1.Columns[i].HeaderText;
                }
                MulAnalysis AnalyWnd = new MulAnalysis(col_name, n, ds);
                AnalyWnd.Show();
            }
            else
            {
                MessageBox.Show("请读取数据!");
            }
        }

        private void 一元分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (ds != null)
            {
                dt = ds.Tables[0];
                //遍历行
                int n = dataGridView1.ColumnCount;
                string[] col_name = new string[n];
                int i = 0;

                for (i = 0; i < n; i++)
                {
                    col_name[i] = dataGridView1.Columns[i].HeaderText;
                }
                Analysis AnalyWnd = new Analysis(col_name, n, ds,1);
                AnalyWnd.Show();
            }
            else
            {
                MessageBox.Show("请读取数据!");
            }
        }

        private void 二次分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (ds != null)
            {
                dt = ds.Tables[0];
                //遍历行
                int n = dataGridView1.ColumnCount;
                string[] col_name = new string[n];
                int i = 0;

                for (i = 0; i < n; i++)
                {
                    col_name[i] = dataGridView1.Columns[i].HeaderText;
                }
                Analysis AnalyWnd = new Analysis(col_name, n, ds, 2);
                AnalyWnd.Show();
            }
            else
            {
                MessageBox.Show("请读取数据!");
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("地信班王文松14306039，数学地质期末作业\n本程序包含三个功能：一元回归，多元回归，二次曲线回归。采用c++、c#混合编程实现。仅支持读取.xls文件");
        }
    }
}