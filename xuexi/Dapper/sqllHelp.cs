using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace dapperssss
{
    public class SqlHelp
    {
        public static string ConString 
        {
            get { return ConfigurationManager.ConnectionStrings["conString"].ConnectionString; }
        }
    }
}
