using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql= "Provider=Microsoft ACEOLEDB.120:" + "Data Source=" + @"C:\Users\Administrator\Desktop\公司\餐补\钟富勇.xlsx" + ",;" + "Extended Properties=\"Excel 12.0HDR=YES, IMEX=1\V";
            //创建连接到数据源
            OleDbConnection con = new OleDbConnection(sql);

            //打开链接
            con.Open();
            string sql2 = "select * from [Sheet1$]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql,con);

            DataSet ds = new DataSet();

            adapter.Fill(ds,"aa");

            DataTable table = ds.Tables["aa"];

            DataRowCollection rows = table.Rows;
            foreach (DataRow item in rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    Console.WriteLine(rows[i]+"");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
