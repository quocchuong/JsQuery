using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Configuration;
using System.Web;

namespace johnLib
{
    /// <summary>
    /// DataUtils class provide ConnectionString, ExecuteQuery, ExecuteNonQuery, ExecuteScalar to interact with database (LIB COMPLETE)
    /// </summary>
    public static class DataUtils
    {
        //declare null sqlConnection object
        private static SqlConnection con;

        //------------------------------configuration for config file------------------------
        // <configuration>
        //     <connectionStrings>
        //         <add name="ContactManageConnectionString" connectionString="Data Source=.\sqlexpress;Initial Catalog=ContactManage;Integrated Security=True" providerName="System.Data.SqlClient"/>
        //     </connectionStrings>
        // </configuration>
        //------------------------------configuration for config file------------------------

        /// <summary>        
        /// Return the connection to sqldatabase .
        /// Configuration file need to be added into the project for the dataprovider to work.                
        /// </summary>
        /// <returns>sqlConnection</returns>
        public static SqlConnection getSQLConnection()
        {
            // the "ContactManageConnectionString" is the name if the connection string in <connectionStrings> tab
            string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            //try to connect to database using delared connection string
            try
            {
                con = new SqlConnection(conStr);
            }
            catch (SqlException e)
            {
                string mess = e.Message;
            }

            return con;
        }

        /// <summary>
        /// ExecuteQuery use mainly to SELECT data from database - return DataTable
        /// </summary>
        /// <param name="query">SQL Query string</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string query)
        {
            //get connection to database
            SqlConnection con = getSQLConnection();

            //get data from database
            string sqlString = query;
            SqlDataAdapter da = new SqlDataAdapter(sqlString, con);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                //throw new expception
                //throw new Exception(ex.Message, ex);                
                string message = ex.Message;
            }
            finally
            {
                //close connection in case opened
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            //return the DataTable
            return ds.Tables[0];
        }

        /// <summary>
        /// ExecuteScalar use mainly to SELECT ONE return value from database - return ONE DATA object.
        /// </summary>
        /// <param name="query">SQl Query String</param>
        /// <returns></returns>
        public static object ExecuteScalar(string query)
        {
            object returnValue;

            SqlConnection con = getSQLConnection();
            string sqlString = query;
            SqlCommand sqlcom = new SqlCommand(sqlString, con);
            try
            {
                con.Open();
                returnValue = sqlcom.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //throw new exception
                throw new Exception(ex.Message, ex);
                //string message = ex.Message;
            }
            finally
            {
                //close connection in case opened
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            //return the object
            return returnValue;
        }

        /// <summary>
        /// ExecuteNonQuery use mainly to INSERT, UPDATE, DELETE value from database - return BOOL object (TRUE/FALSE).
        /// </summary>
        /// <param name="query">SQl Query String</param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string query)
        {
            bool result = false;

            SqlConnection con = getSQLConnection();
            string sqlString = query;
            SqlCommand sqlcom = new SqlCommand(sqlString, con);
            try
            {
                con.Open();
                sqlcom.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException ex)
            {
                //return false if query cannot be execute
                result = false;
                //throw exception
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //close connection in case opened
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            //return result TRUE/FALSE
            return result;
        }

        public static OdbcConnection getOdbcConnection(string DSNName)
        {
            //connection string
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection("DSN=" + DSNName + ";UID=sa;PWD=polaroid;");

            return conn;
        }
    }
}
