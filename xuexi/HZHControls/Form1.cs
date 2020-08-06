using HZH_Controls.Controls;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZHControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
            FrmWithTitle fw = new FrmWithTitle();
            fw.IsShowCloseBtn = true;
            fw.Title = "xxx";
            fw.Show();
        }

        private void gifBox1_Click(object sender, EventArgs e)
        {

        }

        private void skinCode1_Click(object sender, EventArgs e)
        {

        }

        private void skinFileTransfersItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
