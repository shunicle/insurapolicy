using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insurapolicy.db
{
    internal class DatabaseHelper
    {
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["policy"].ConnectionString;
        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(ConnectionString);
        }
    }
}
