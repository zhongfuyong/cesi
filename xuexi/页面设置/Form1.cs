using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 页面设置
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1、页面设置   pageSetupDialog1
            //pageSetupDialog1.ShowDialog();

            //1、打印设置  printDialog1
            //if (printDialog1.ShowDialog()==DialogResult.OK)
            //{
            //    MessageBox.Show("xxx");
            //}

            //3、打印预览控件  printPreviewDialog1
            //printPreviewDialog1.ShowDialog();//弹出打印预览窗口

            //4、printDocument1
            //printDocument1.Print();

        }
    }
}
