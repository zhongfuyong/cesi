using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLite数据库
{
    public class DBHelp
    {
        public static string  SQLiteCon 
        {
            get { return ConfigurationManager.ConnectionStrings["sqlite"].ConnectionString; }
        }
    }
}
