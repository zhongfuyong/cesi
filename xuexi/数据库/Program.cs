using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;

namespace 数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据库
            //CREATE DATABASE 数据库名;

            //删除数据库
            //drop database <数据库名>;

            //创建数据表
            //CREATE TABLE 表名 (属性名 属性值);

            //删除数据库
            //DROP TABLE table_name ;

            //插入数据
            //INSERT INTO 表名 ( 字段名123 )
            //VALUES
            //(插入值123);

            //查询数据
            //SELECT 要查询的东西
            //FROM 查询的表
            //[WHERE Clause]（查询条件）
            //[LIMIT N][OFFSET M]（通过OFFSET指定SELECT语句开始查询的数据偏移量）

            //多表查询
            //select count(*)
            //from 表1,表2
            //where Member.id = Album.id and Member.id = Log.id

            //联表查询
            //SELECT
            //查询字段
            //FROM
            //表1
            //INNER JOIN 表2 ON 表1.id = 表2.id;

            //插入数据
            //UPDATE 表名 SET 字段1 = 值1, 字段2 = 值2
            //[WHERE Clause]

            //删除数据
            //DELETE FROM 表名 [WHERE Clause]

            //LIKE 子句
            //SELECT 字段
            //FROM 表名
            //WHERE 字段 LIKE 条件（通常配合%使用达到模糊查询的效果）

            //UNION 操作符（可用于检索重复的值）
            //SELECT 字段
            //FROM 表1
            //[WHERE conditions]
            //UNION[ALL | DISTINCT]  DISTINCT:删除结果集中重复的数据。默认情况下 UNION 操作符已经删除了重复数据   ALL: 可选，返回所有结果集，包含重复数据。
            //SELECT 字段
            //FROM 表2
            //[WHERE conditions];

            //ORDER BY 子句
            //ASC：升序
            //DESC：降序



            //连接本地数据库
            string str = "Data Source=.;Initial Catalog=TelephoneMS;Integrated Security=True;";

            //定义查询语句
            string sql = "select * from xxx";

            //定义连接对象
            SqlConnection con = new SqlConnection(str);
            con.Open();

            //使用SqlCommand类执行sql语句
            //SqlCommand cmd = new SqlCommand(sql,con);
            //cmd.ExecuteReader();//执行一些查询
            //cmd.ExecuteNonQuery();//插入，删除
            //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值

            //SqlDataReader常用属性： FieldCount属性：表示记录中有多少字段；HasRows属性：表示DataReader是否包含数据；IsClosed表示是否关闭
            //SqlDataReader reader = cmd.ExecuteReader();//获取查询数据
            //  reader.Read();
            //Console.WriteLine(reader[0].ToString() + reader[1] + reader[2]);
            // reader.Read();

            //数据适配器
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, con);
            //定义数据集
            DataSet ds = new DataSet();
            sqlda.Fill(ds, "表名");

            Console.WriteLine("yes");
            cesi(ds);


        }
        public static void cesi(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("表名：" + dt.TableName);
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Console.WriteLine(dr[dc] + "\t");
                    }
                }
            }
        }
    }
}
