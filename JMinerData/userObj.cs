using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using johnLib;

namespace JMinerData
{
    public class userObj
    {
        public string UserID;
        public string UserName;
        public string Password;
        public string SearchShare;
        public string LastDataBase;
        public string Name;

        /// <summary>
        /// Constructor of User Object
        /// </summary>
        public userObj()
        { 
            //set all properties to null
            UserID = "";
            UserName = "";
            Password = "";
            SearchShare = "";
            LastDataBase = "";
            Name = "";
        }

        /// <summary>
        /// Constructor of User Object with userID
        /// </summary>
        /// <param name="userID"></param>
        public userObj(string userID)
        {
            //sql command block to get data------------------------------------
            //get data from database
            string sqlString = "select * from [users] where [userID]=" + userID + "";

            //execute the query and return data table - johnLib will do the work
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            try
            {
                //set all properties value
                UserID = ((int)dt.Rows[0]["userID"]).ToString();
                UserName = dt.Rows[0]["username"].ToString();
                Password = dt.Rows[0]["password"].ToString();
                SearchShare = dt.Rows[0]["searchShareSetting"].ToString();
                LastDataBase = dt.Rows[0]["lastDatabase"].ToString();
                Name = dt.Rows[0]["name"].ToString();                
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

        public userObj(string username, string password)
        {
            //sql command block to get data------------------------------------
            //get data from database
            string sqlString = "select * from [users] where [username]='" + username + "' and [password]='"+password+"'";

            //execute the query and return data table - johnLib will do the work
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            try
            {
                //set all properties value
                UserID = ((int)dt.Rows[0]["userID"]).ToString();
                UserName = dt.Rows[0]["username"].ToString();
                Password = dt.Rows[0]["password"].ToString();
                SearchShare = dt.Rows[0]["searchShareSetting"].ToString();
                LastDataBase = dt.Rows[0]["lastDatabase"].ToString();
                Name = dt.Rows[0]["name"].ToString();
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
        /// Insert new user
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="SearchShareSetting"></param>
        /// <param name="LastDatabase"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool insert(string username, string password, string searchShareSetting, string lastDatabase, string name)
        {
            //initialise the return value
            bool result = false;

            //sql command block to insert data------------------------------------
            //construct of sql command
            string sqlString = "insert into [users]([name],[username],[password],[searchShareSetting],[lastDatabase]) values(N'" + name + "',N'" + username + "',N'" + password + "',N'" + searchShareSetting + "',N'" + lastDatabase + "')";

            //execute the Nonquery command.
            result = DataUtils.ExecuteNonQuery(sqlString);
            //sql command block end-------------------------------------------------

            //return the result
            return result;
        }

        /// <summary>
        /// Update User Object
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            //initialise the return value
            bool result = false;

            //sql command block to update data------------------------------------            
            //construct of sql command
            string sqlString = "update [users] set [name]=N'" + Name + "',[username]=N'" + UserName + "',[password]='" + Password + "',[searchShareSetting]=N'" + SearchShare + "',[lastDatabase]=N'" + LastDataBase + "' where [userID]=" + UserID + "";

            //execute the nonquery command
            result = DataUtils.ExecuteNonQuery(sqlString);

            //return the result
            return result;
        }

        /// <summary>
        /// Delete User with UserID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool delete(string userID)
        {
            //initialise the return value
            bool result = false;

            //sql command block to update data------------------------------------
            //construct of sql command
            string sqlString = "delete from [users] where [userID] = " + userID + "";

            //execute the sql comand
            result = DataUtils.ExecuteNonQuery(sqlString);

            //return the result
            return result;
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="searchShareSetting"></param>
        /// <param name="lastDataBase"></param>
        /// <returns></returns>
        public DataTable searchUser(string userID, string name, string username, string password, string searchShareSetting, string lastDataBase)
        {
            //sql command block to update data------------------------------------            
            //create empty sql string
            string sqlString = "";

            //generate the condition string
            string searchstring = userID + name + username + password + searchShareSetting + lastDataBase;

            //if there is no param enter --> select all
            if (searchstring == "")
            {
                sqlString = "select * from [users]";
            }
            else //else generate sql query with condition 
            {
                //process the query string (MAKE CHANGE HERE ACCORDINGLY)
                if (userID != "")
                {
                    userID = "[userID]=" + userID + " and ";
                }
                if (name != "")
                {
                    name = "[name] like N'" + name + "' and ";
                }
                if (username != "")
                {
                    username = "[username] like N'" + username + "' and ";
                }
                if (password != "")
                {
                    password = "[publicstatus] = N'" + password + "' and ";
                }
                if (searchShareSetting != "")
                {
                    searchShareSetting = "[searchShareSetting] = N'" + searchShareSetting + "' and ";
                }
                if (lastDataBase != "")
                {
                    lastDataBase = "[lastDataBase] = N'" + lastDataBase + "' and ";
                }                

                //regenerate condition string
                searchstring = userID + name + username + password + searchShareSetting + lastDataBase;
                searchstring = searchstring.Substring(0, searchstring.Length - 4);

                //generate the full
                sqlString = "select * from [users] where " + searchstring + "";
            }

            //get data from database
            DataTable dt = DataUtils.ExecuteQuery(sqlString);

            return dt;
        }      
    }
}
