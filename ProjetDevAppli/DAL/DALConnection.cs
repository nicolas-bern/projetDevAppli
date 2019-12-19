using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAL
{
    class DALConnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static MySqlConnection Connection()
        {
            if(connection == null)
            {
                server = "localhost";
                database = "projetdev";
                uid = "projetDEV";
                password = "epsi2019";
                string connect = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connect);
                connection.Open();
            }
            return connection;
        }
    }
}
