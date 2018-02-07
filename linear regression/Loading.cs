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
    public partial class Loading : Form
    {

        public
            Form1 MainWnd = new Form1();
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            MainWnd.Show();
            MainWnd.Hide();

        }
        public void start()
        {
            
            MainWnd.Show();
        }
    }
}
