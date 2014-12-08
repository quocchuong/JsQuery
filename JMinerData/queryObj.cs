using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using johnLib;

namespace JMinerData
{
    public class queryObj
    {
        public string QueryID;
        public string UserID;
        public string Description;
        public string QueryContent;
        public string SharedFlag;
        public string ActiveFlag;
        public string LastSaved;

        /// <summary>
        /// Constructor of a null Query object
        /// </summary>
        public queryObj()
        { 
             //set all attribute to null
             QueryID = "";
             UserID = "";
             Description = "";
             QueryContent = "";
             SharedFlag = "";
             ActiveFlag = "";
             LastSaved = "";
        }

        /// <summary>
        /// Constructor of Query Object with query ID
        /// </summary>
        /// <param name="queryID"></param>
        public queryObj(string queryID)
        { 
            //sql command block to get data------------------------------------
            //get data from database
            string sqlString = "select * from [query] where [queryID]=" + queryID + "";

            //execute the query and return data table - johnLib will do the work
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            try
            {
                //set all properties value
                QueryID = ((int)dt.Rows[0]["queryID"]).ToString();
                UserID = ((int)dt.Rows[0]["userID"]).ToString();                
                Description = dt.Rows[0]["description"].ToString();
                LastSaved = ((DateTime)dt.Rows[0]["lastSaved"]).ToString("MM/dd/yyyy HH:mm:ss");
                QueryContent = dt.Rows[0]["querycontent"].ToString();
                SharedFlag = dt.Rows[0]["sharedFlag"].ToString();
                ActiveFlag = dt.Rows[0]["activeFlag"].ToString();
            }
            catch (SqlException se)
            {
                string mess = se.Message;
            }
            catch (Exception e)
            {
                string mess2 = e.Message;
            }
        }

        /// <summary>
        /// Insert new Query
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="description"></param>
        /// <param name="querycontent"></param>
        /// <param name="sharedflag"></param>
        /// <param name="activeflag"></param>
        /// <returns></returns>
        public bool insert(string userID, string description, string querycontent, string sharedflag, string activeflag)
        {
            //initialise the return value
            bool result = false;

            //sql command block to insert data------------------------------------
            //construct of sql command
            string sqlString = "insert into [query]([userID],[description],[querycontent],[sharedflag],[activeflag],[lastsaved]) values(" + userID + ",N'" + description + "',N'" + querycontent + "',N'" + sharedflag + "',N'" + activeflag + "','" + CommonUtils.getDateTimeNow() + "')";

            //execute the Nonquery command.
            result = DataUtils.ExecuteNonQuery(sqlString);
            //sql command block end-------------------------------------------------

            //return the result
            return result;
        }

        /// <summary>
        /// Update Query - DO NOT need to specified last saved
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            //initialise the return value
            bool result = false;

            //sql command block to update data------------------------------------            
            //construct of sql command
            string sqlString = "update [query] set [userID]=" + UserID + ",[description]=N'" + Description + "',[querycontent]='" + QueryContent + "',[sharedflag]=N'" + SharedFlag + "',[activeflag]=N'" + ActiveFlag + "',[lastSaveD]='" + CommonUtils.getDateTimeNow() + "' where [queryID]=" + QueryID + "";

            //execute the nonquery command
            result = DataUtils.ExecuteNonQuery(sqlString);

            //return the result
            return result;
        }

        /// <summary>
        /// Delete query with QueryID
        /// </summary>
        /// <param name="queryID"></param>
        /// <returns></returns>
        public bool delete(string queryID)
        {
            //initialise the return value
            bool result = false;

            //sql command block to update data------------------------------------
            //construct of sql command
            string sqlString = "delete from [query] where [queryID] = " + queryID + "";

            //execute the sql comand
            result = DataUtils.ExecuteNonQuery(sqlString);

            //return the result
            return result;
        }

        /// <summary>
        /// Search Query
        /// </summary>
        /// <param name="queryID"></param>
        /// <param name="userID"></param>
        /// <param name="description"></param>
        /// <param name="querycontent"></param>
        /// <param name="sharedflag"></param>
        /// <param name="activeflag"></param>
        /// <returns></returns>
        public DataTable searchQuery(string queryID, string userID, string description, string querycontent, string sharedflag, string activeflag)
        {
            //sql command block to update data------------------------------------            
            //create empty sql string
            string sqlString = "";

            //generate the condition string
            string searchstring = queryID + userID + description + querycontent + sharedflag + activeflag;

            //if there is no param enter --> select all
            if (searchstring == "")
            {
                sqlString = "select * from [query]";
            }
            else //else generate sql query with condition 
            {
                //process the query string (MAKE CHANGE HERE ACCORDINGLY)
                if (queryID != "")
                {
                    queryID = "[queryID]=" + queryID + " and ";
                }
                if (userID != "")
                {
                    userID = "[userID]=" + userID + " and ";
                }
                if (description != "")
                {
                    description = "[description] like N'%" + description + "%' and ";
                }
                if (querycontent != "")
                {
                    querycontent = "[querycontent] like N'%" + querycontent + "%' and ";
                }
                if (sharedflag != "")
                {
                    sharedflag = "[sharedflag] = N'" + sharedflag + "' and ";
                }
                if (activeflag != "")
                {
                    activeflag = "[activeflag] = N'" + activeflag + "' and ";
                }                

                //regenerate condition string
                searchstring = queryID + userID + description + querycontent + sharedflag + activeflag;
                searchstring = searchstring.Substring(0, searchstring.Length - 4);

                //generate the full
                sqlString = "select * from [query] where " + searchstring + "";
            }

            //get data from database
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            return dt;
        }

        public DataTable searchMyQuery(string myID, string searchTerm)
        {
            //create empty sql string
            string sqlString = "select queryid, [description] from query where userID = " + myID + " and ([queryID] like '%" + searchTerm + "%' or [description] like '%" + searchTerm + "%' or querycontent like '%" + searchTerm + "%')";
            
            //get data from database
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            return dt;
        }

        public DataTable searchSomeOneQuery(string someoneID, string searchTerm)
        {
            //sql command block to update data------------------------------------            
            //create empty sql string
            string sqlString = "select queryid, [description] from query where userID = " + someoneID + " and ([queryID] like '%" + searchTerm + "%' or [description] like '%" + searchTerm + "%' or querycontent like '%" + searchTerm + "%') and sharedFlag = 'T'";

            //get data from database
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            return dt;
        }

        public DataTable searchAllSharedQuery(string searchTerm)
        {
            //sql command block to update data------------------------------------            
            //create empty sql string
            string sqlString = "select queryid, [description] from query where sharedFlag = 'T' and ([queryID] like '%" + searchTerm + "%' or [description] like '%" + searchTerm + "%' or querycontent like '%" + searchTerm + "%')";

            //get data from database
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            return dt;
        }

        /// <summary>
        /// get latest queryID
        /// </summary>
        /// <returns></returns>
        public string getLatestQueryID()
        {
            //create empty sql string
            string sqlString = "select IDENT_CURRENT('query')";

            //get data from database
            string IdentID = DataUtils.ExecuteScalar(sqlString).ToString();

            return IdentID;
        } 
    }
}
