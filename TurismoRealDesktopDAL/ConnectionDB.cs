using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace TurismoRealDesktopDAL
{
    public class ConnectionDB
    {
        private static OracleConnection conn = null;


        private static readonly string conString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=turismopdb)));User Id=turismopdb_admin;Password=1234;";

        private ConnectionDB()
        {

        }

        public static OracleConnection Connection
        {
            get
            {
                if (conn == null)
                    conn = new OracleConnection(conString);

                if (conn.ConnectionString == "")
                    conn.ConnectionString = conString;

                return conn;
            }
        }
    }
}
