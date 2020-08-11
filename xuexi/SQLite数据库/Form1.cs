using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Data.Entity;

namespace SQLite数据库
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()!="")
            {
                string sql = "SELECT * FROM DBstu where name like '"+textBox1.Text.Trim()+"%'";
                using (SQLiteConnection con = new SQLiteConnection(DBHelp.SQLiteCon)) 
                {
                    SQLiteDataAdapter sqliteda = new SQLiteDataAdapter(sql,con);
                    DataSet ds = new DataSet();
                    sqliteda.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim()!=""&& textBox3.Text.Trim() != ""  )
            {
                int a = int.Parse(textBox3.Text.Trim());
                string sql = "insert into DBstu (name,chengji)values('"+textBox2.Text.Trim()+"',"+a+")";
                using (SQLiteConnection con=new SQLiteConnection(DBHelp.SQLiteCon)) 
                {
                    SQLiteCommand com = new SQLiteCommand(sql,con);
                    if (com.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("成功");
                    }
                    else 
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("不得有空");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim()!="")
            {
                this.textBox5.ReadOnly = true;
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
                this.button4.Enabled = true;
                int x = int.Parse(textBox5.Text.Trim());
                string sql = "select * from DBstu where id=@"+x;
                using (SQLiteConnection con =new SQLiteConnection(DBHelp.SQLiteCon)) 
                {
                    SQLiteCommand com = new SQLiteCommand(sql,con);
                    SQLiteDataReader sQLiteData = com.ExecuteReader();
                    textBox6.Text = sQLiteData["name"].ToString();
                    textBox7.Text = sQLiteData["chengji"].ToString();
                }
            }
            else
            {
                MessageBox.Show("请先填写");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox5.Text);
            string sql = "update set DBstu name=@"+textBox6.Text+"chengji=@"+textBox7.Text+"where id=@"+x;
            using (SQLiteConnection con =new SQLiteConnection(DBHelp.SQLiteCon)) 
            {
                SQLiteCommand com = new SQLiteCommand(sql,con);
                if (com.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
        }
    }
}
