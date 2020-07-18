using System;
using System.Data;
using System.Data.SqlClient;

namespace ReportingAPI.Database
{
    class SQLDBConnection
    {
        private const string ConnectionString = "";
        SqlConnection conn;


        /// <summary>
        /// SQL Connection
        /// </summary
        public SQLDBConnection()
        {
          
          conn = new SqlConnection(ConnectionString);
          try
          {
              conn.Open();
          }
          catch (SqlException ex)
          {
             Console.WriteLine("Cannot connect to db, Exception caught : {0}", ex);
             throw ex;
          }
                
        }



        /// <summary>
        /// Use this method if the query returns more than one column
        /// </summary
        public DataTable ExecuteQuery(string querystring)
        {
            DataTable dt = new DataTable();
            if (null == conn)
            {
                conn = new SqlConnection(ConnectionString);
            }
           else
            {
                
                try
                {
                    SqlCommand cmd = new SqlCommand(querystring, conn);
                    SqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }
               
            }

            return dt;
        }



        /// <summary>
        /// Close SQL Connection
        /// </summary
        public SqlConnection sqlclose()
        {
       
            try
            {
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Cannot close connection, Exception caught.{0}", ex);
                throw ex;
            }
            return conn;
        }

        //Execute query
        //get result from query

    }
}
