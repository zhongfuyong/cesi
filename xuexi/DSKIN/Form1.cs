using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSKIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void tishi(string str) 
        {
            textBox6.AppendText(DateTime.Now.ToString()+str+"\n") ;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="")
            {
                MessageBox.Show("不得添加空的目录");
            }
            else
            {
                TreeNode tn = new TreeNode();
                tn.Text = textBox1.Text;
                treeView1.Nodes.Add(tn.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode();
            tn = treeView1.SelectedNode;
            if (tn.Nodes.Count>0)
            {
                DialogResult dr = MessageBox.Show("该节点有子节点，确定删除吗","删除提示",MessageBoxButtons.YesNo);
                if (dr==DialogResult.Yes)
                {
                    tn.Remove();
                }
                
            }
            tn.Remove();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim() == "")
            //{
            //    MessageBox.Show("不得添加空的目录");
            //}
            //else
            //{
            //    if (treeView1.SelectedNode==)
            //    {
            //        MessageBox.Show("请选择根目录");
            //    }
            //    else
            //    {
            //        TreeNode tn = new TreeNode();
            //        tn.Text = textBox1.Text;
            //        treeView1.SelectedNode.Nodes.Add(tn.Text);
            //    }
                
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 8 || textBox2.Text.Length > 10)
            {
                errorProvider1.SetError(textBox2, "用户名必须为8到10位");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.PerformStep();
            if (progressBar1.Value>progressBar1.Minimum)
            {
                progressBar1.PerformStep();
                tishi("进度条正在执行，已经完成"+((1-Convert.ToDouble(progressBar1.Value)/Convert.ToDouble(progressBar1.Maximum))*100).ToString() +"%");
            }
            else
            {
                tishi("进度已经完成");
                timer1.Enabled = false;
                button5.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //progressBar1.Value = 1000;
            //progressBar1.Increment(1500);
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            timer1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim()=="")
            {
                MessageBox.Show("请先设置时间");
            }
            else
            {
                progressBar1.Maximum = int.Parse(textBox5.Text);
                progressBar1.Step = -1;
                progressBar1.Value = progressBar1.Maximum;
                progressBar1.PerformStep();
                button5.Enabled = false;
                button6.Enabled = true;
                tishi("程序时间设置完成，请开始");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            timer1.Enabled = true;
            timer1.Start();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled==true)
            {
                tishi("暂停");
                timer1.Stop();
                button7.Text = "开始";
            }
            else
            {
                tishi("开始");
                timer1.Start();
                button7.Text = "暂停";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tishi("已停止");
            timer1.Enabled = false;
            progressBar1.Value = 0;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            timer1.Enabled = false;
            textBox5.Text = "";
        }
    }
}
