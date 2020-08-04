using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Dapper
{
    class SqlHelp
    {
        public static string ConString 
        {
            get { return ConfigurationManager.ConnectionStrings["conString"].ConnectionString; }
        }
        public void btnSearch_Click(object sender,EventArgs e) 
        {

        }
    }
}
