using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 表格数据控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = cesi().Tables["cesi"];
        }
        private DataSet cesi() 
        {
            string str = "连接数据库";
            SqlConnection con = new SqlConnection(str);
            string sql = "select * from 表名";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql,con);
            sqlda.Fill(ds,"表名");
            return ds;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = e.RowIndex + 1;
            //int col = e.ColumnIndex + 1;


            //int row = dataGridView1.CurrentCell.RowIndex + 1;
            //int col = dataGridView1.CurrentCell.ColumnIndex + 1;


            int row = dataGridView1.CurrentCellAddress.Y + 1;
            int col = dataGridView1.CurrentCellAddress.X + 1;

            //int row = dataGridView1.CurrentRow.Index + 1;

            //获取单元格内容
            string cell = dataGridView1.Rows[row-1].Cells[col-1].Value.ToString() ;

            string cell2 = dataGridView1.CurrentCell.Value.ToString();

            MessageBox.Show("这是第" + row.ToString() + "行,第" + col.ToString() + "列");
        }
        private int rowIndex = 0;
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1,e.Location);
                contextMenuStrip1.Show(Cursor.Position);


            }
        }
        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
        private SqlDataAdapter sqlda;
        private DataSet ds = new DataSet();

        private int StartVal = 0;//起始值
        private int valperPage = 3;//每页显示内容
        private int totaValNumber;//总条数
        private int currentPage = 1;//当前页
        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = "xx";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string sql = "xx";
            sqlda = new SqlDataAdapter(sql,con);
            sqlda.Fill(ds,"xx");
            con.Close();
            totaValNumber = ds.Tables["xx"].Rows.Count;//总条数
            int totaPageNumber = (totaValNumber % valperPage == 0) ? (totaValNumber / valperPage) : (totaValNumber / valperPage+1);//总页数
            toolStripLabel1.Text = "/" + totaPageNumber;


        }
    }
}
