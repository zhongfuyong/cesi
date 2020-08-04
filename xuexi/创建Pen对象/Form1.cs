using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 创建Pen对象
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue,2);
            //定义你的笔的颜色和大小

            g.DrawEllipse(p,0,80,280,120);//第一个参数是指定用笔还是必刷，第二第三个是值椭圆矩形的坐标值，第四第五个代表圆的长轴和短轴长度
            g.Dispose();//释放由Graphics使用的资源
        }
    }
}
