using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 创建Brush对象
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //1、SolidBrush
            //Graphics g = e.Graphics;
            //Brush bn = new SolidBrush(Color.Black);
            //g.FillEllipse(bn,0,80,280,120);

            //2、TextureBrush
            //string path = @"xxx";
            //Graphics g = e.Graphics;
            //Bitmap img;
            //if (File.Exists(path))
            //{
            //    img = new Bitmap(path);
            //    Brush br = new TextureBrush(img);
            //    g.FillEllipse(br,0,80,180,120);
            //    g.Dispose();
            //}
            //else
            //{
            //    MessageBox.Show("xxx");
            //    g.Dispose();
            //}

            //3、LinearGradientBrush
            //Graphics g = e.Graphics;
            //LinearGradientBrush lgb = new LinearGradientBrush(new Point(0,80),new Point(280,120),Color.White, Color.FromArgb(255,0,0,0));
            //g.FillEllipse(lgb,0,80,280,120);
            //lgb.Dispose();
            //g.Dispose();

            //4、PathGradientBrush
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(0,80,280,120);
            //PathGradientBrush pgb = new PathGradientBrush(gp);
            //pgb.CenterColor = Color.FromArgb(255,255,0,0);
            //Color[] colors = { Color.FromArgb(255, 0, 255, 0)};
            //pgb.SurroundColors = colors;
            //e.Graphics.FillEllipse(pgb,0,80,280,120);
            //pgb.Dispose();

            //4、HatchBrush
            //HatchBrush hb = new HatchBrush(HatchStyle.HorizontalBrick,Color.Black,Color.Red);
            //e.Graphics.FillEllipse(hb,0,80,280,120);

            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
