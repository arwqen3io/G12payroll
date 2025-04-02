using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data;



namespace PROJECT_DEFENCE
{
    class mycon
    {
        public MySqlConnection con;
        public MySqlDataReader dr;
        public MySqlCommand cmd;
        public DataTable dt;

        public void connect()
        {
            con = new MySqlConnection("datasource=localhost;Database=dbpayroll;username=root");
            con.Open();
        }

        public void Disconnect()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Dispose();
        }
    }
}
