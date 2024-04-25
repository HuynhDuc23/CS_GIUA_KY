using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace CRUDuser
{
    internal class ConnectionDB
    {
       public static  SqlConnection _connectionString = null;

        public ConnectionDB (string url)
        {
            _connectionString = new SqlConnection(url);
            
        }

        public static SqlConnection get()
        {
            return _connectionString;
        }

        public static void conect()
        {
            _connectionString.Open();
        }

        public static void disConect()
        {
            _connectionString.Close();
        }
        
    }
}
