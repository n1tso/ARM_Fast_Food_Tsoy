using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Fast_Food
{
    internal class DB
    {

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=root; database=fastfooddb");

        public DB(MySqlConnection connection)
        {
            this.connection = connection;
        }

        public DB()
        {

        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}