using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 创建Graphics对象和Pan对象2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Graphics对象表示GDI+绘图表面，是用于创建图形图像的对象.所以要通过GDI+创建绘图，
            //必须先创建Graphics对象，然后才可以使用GDI+的笔、刷等结合颜色、字体等对象进行绘制线条形状、
            //填充区域、显示文本图像等操作。
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //1、
            Graphics g1 = e.Graphics;

            //2、创建一个Image对象
            Bitmap imgTemp = new Bitmap(200,200);
            Graphics g2 = Graphics.FromImage(imgTemp);

            //3、
            Graphics g3 = this.CreateGraphics();

            MessageBox.Show("11");

        }
    }
}
