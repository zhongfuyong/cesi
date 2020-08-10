using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace dapperssss
{
    public class PersonService
    {
        //根据用户姓氏查询用户的集合
        public List<Person> FindeListByLastName(string firstname)
        {
            using (IDbConnection dbConnection = new SqlConnection(SqlHelp.ConString))
            {
                //查询
                //string sql = "select * from mock_data where first_name='"+lastname+"'";
                //IEnumerable<Person> lst= dbConnection.Query<Person>(sql);

                string sql = $"select * from mock_data where FirstName=@FirstName";

                IEnumerable<Person> lst = dbConnection.Query<Person>(sql, new { FirstName = firstname });

                return lst.ToList();//转化为List类型返回
            }
        }
    }

    public class PersonServic2
    {
        public bool InsertData(Person person) 
        {
            using (IDbConnection dbConnection = new SqlConnection(SqlHelp.ConString)) 
            {
                string sql = "insert into mock_data(FirstName,LastName,Email)values(@FirstName,@LastName,@Email)";
                int result= dbConnection.Execute(sql,person);
                bool success = true;
                if (result>0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
                return success;
            }
        }
    }
    public class PersonServic3
    {
        public Person FindByPersonId(int id) 
        {
            using (IDbConnection con=new SqlConnection(SqlHelp.ConString)) 
            {
                string sql = $"select * from mock_data where id=@id";
                IEnumerable<Person> lst= con.Query<Person>(sql,new {id=id });
                return lst.FirstOrDefault();
            }
        }
        public bool UpdateDate(Person person) 
        {
            using (IDbConnection con=new SqlConnection(SqlHelp.ConString)) 
            {
                string sql = "update mock_data set FirstName=@FirstName,LastName=@LastName,Email=@Email where id=@Id";
                int result = con.Execute(sql,person);
                return result > 0;
            }
        }
    }

}
