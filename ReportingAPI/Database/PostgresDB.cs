using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingAPI.Database
{
    class PostgresDB
    {
        private const string ConnectionString = "";
        NpgsqlConnection conn;


        public PostgresDB()
        {

            conn = new NpgsqlConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                throw ex;
            }

        }

        public NpgsqlConnection Postgresclose()
        {
            try
            {
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                throw ex;
            }
            return conn;
        }
    }
}
