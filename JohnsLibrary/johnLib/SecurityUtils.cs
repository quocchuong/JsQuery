using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace johnLib
{
    /// <summary>
    /// Security Utils provide some functions to encrypt and decrypt string.
    /// </summary>
    public static class SecurityUtils
    {
        private static string key = "primaryd";
        private static string iv = "ivectorr";

        /// <summary>
        /// Encrypt the string and produce a new string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Encrypt(string value)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] aValue = Encoding.ASCII.GetBytes(value);
            Byte[] aKey = Encoding.ASCII.GetBytes(key);
            Byte[] aIV = Encoding.ASCII.GetBytes(iv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(aKey, aIV), CryptoStreamMode.Write);
            cs.Write(aValue, 0, aValue.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Decrypt the string and produce the original string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Decrypt(string value)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] aValue = Convert.FromBase64String(value);
            Byte[] aKey = Encoding.ASCII.GetBytes(key);
            Byte[] aIV = Encoding.ASCII.GetBytes(iv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(aKey, aIV), CryptoStreamMode.Write);
            cs.Write(aValue, 0, aValue.Length);
            cs.FlushFinalBlock();
            return Encoding.ASCII.GetString(ms.ToArray());
        }

        /// <summary>
        /// Check user login detail. This function is used for encrypted password (MD5) only.
        /// </summary>
        /// <param name="username">Username needs checking</param>
        /// <param name="password">Password needs checking</param>
        /// <param name="tableToCheck">List of accounts need checking</param>
        /// <param name="usernameFieldLabel">Label of the username field</param>
        /// <param name="passwordFieldLabel">Label of the password field</param>
        /// <returns></returns>
        public static bool checkLoginMD5(string username, string password, DataTable accountList, string usernameFieldLabel, string passwordFieldLabel)
        {
            //double check this user - check username and password
            bool processresult = false;

            //start checking username and password
            if (accountList.Rows.Count > 0)
            {
                string realUsername = accountList.Rows[0][usernameFieldLabel].ToString();
                string realPassword = accountList.Rows[0][passwordFieldLabel].ToString();

                if ((username == realUsername) && (EncryptMD5(password) == realPassword))
                {
                    processresult = true;
                }
                else
                {
                    processresult = false;
                }
            }
            else // = 0 means cant find account
            {
                processresult = false;
            }

            return processresult;
        }

        /// <summary>
        /// Check user login detail.
        /// </summary>
        /// <param name="username">Username needs checking</param>
        /// <param name="password">Password needs checking</param>
        /// <param name="tableToCheck">List of accounts need checking</param>
        /// <param name="usernameFieldLabel">Label of the username field</param>
        /// <param name="passwordFieldLabel">Label of the password field</param>
        /// <returns></returns>
        public static bool checkLogin(string username, string password, DataTable accountList, string usernameFieldLabel, string passwordFieldLabel)
        {
            //double check this user - check username and password
            bool processresult = false;

            //start checking username and password
            if (accountList.Rows.Count > 0)
            {
                string realUsername = accountList.Rows[0][usernameFieldLabel].ToString();
                string realPassword = accountList.Rows[0][passwordFieldLabel].ToString();

                if ((username == realUsername) && (password == realPassword))
                {
                    processresult = true;
                }
                else
                {
                    processresult = false;
                }
            }
            else // = 0 means cant find account
            {
                processresult = false;
            }

            return processresult;
        }

        /// <summary>
        /// One Way encryption using MD5 encrypt provider
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncryptMD5(string value)
        {
            //create the encrypter
            MD5CryptoServiceProvider md5Encrypter = new MD5CryptoServiceProvider();

            //transform the original string to byte and encrypt it
            byte[] origin = Encoding.UTF8.GetBytes(value);
            byte[] encrypted = md5Encrypter.ComputeHash(origin);

            //return the encrypted string 
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encrypted), "-", "").ToLower();
        }

        /// <summary>
        /// Remove sql injection
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string RemoveSQLInjection(string sourceString)
        {
            string result="";

            //if there is a signle quote (') charater , add one more after it
            //split string into string array        
            char[] spliter = new char[] {'\''};
            string[] originalString = sourceString.Split(spliter);

            if (sourceString == "")
            {
                result = "";
            }
            else
            {
                //generate original string
                for (int i = 0; i < originalString.Length; i++)
                {
                    result += originalString[i];
                    result += "''";
                }

                //if at the end of source string has ' --> do nothing
                if (sourceString.LastIndexOf("'") == sourceString.Length - 1)
                {
                    //do nothing
                }
                else //remove it
                {
                    result = result.Substring(0, result.Length - 2);
                }
            }

            //return string
            return result;
        }        

        /// <summary>
        /// Validate Email String
        /// </summary>
        /// <param name="emailString"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string emailString)
        { 
            //declare return result
            bool returnResult = false;

            //declare a pattern for validating email
            string pattern = "^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\\-+)|([A-Za-z0-9]+\\.+)|([A-Za-z0-9]+\\++))*[A-Za-z0-9]+@((\\w+\\-+)|(\\w+\\.))*\\w{1,63}\\.[a-zA-Z]{2,6}$";

            //create a match of string
            Match match = Regex.Match(emailString, pattern);

            //if input string is validate successfully --> return true 
            if (match.Success)
            {
                returnResult = true;
            }

            return returnResult;
        }

        /// <summary>
        /// Validate any string, ValidatePattern (Regex) must be provided
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool ValidateString(string inputString, string pattern)
        {
            //declare return result
            bool returnResult = false;            

            //create a match of string
            Match match = Regex.Match(inputString, pattern);

            //if input string is validate successfully --> return true 
            if (match.Success)
            {
                returnResult = true;
            }

            return returnResult;
        }
    }
}
