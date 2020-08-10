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
    }
}
