using System;
using System.IO;
using System.Text;


namespace johnLib
{
    /// <summary>
    /// Summary description for FileUtil. (LIB COMPLETE)
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Save text file - return TRUE if action complete, return FALSE if NOT COMPLETE
        /// </summary>
        /// <param name="filepath">String - File path include file name</param>
        /// <param name="text">String - Text to insert as content of file</param>
        public static bool SaveFile(string filepath, string text)
        {
            //declare return value
            bool returnValue = false;

            //declare a new stream writer
            StreamWriter sw = null;

            //try to create file with predefine path
            try
            {
                //get the directory that contain file from filepath
                string directory = filepath.Substring(0, filepath.LastIndexOf("\\"));

                //if directory does not exist --> create new directory
                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                //write file to predefined directory with specified file path
                sw = File.CreateText(filepath);
                sw.Write(text);
                returnValue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //finally close stream write
                try
                {
                    sw.Close();
                    sw = null;
                }
                catch
                {
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Delete file - return TRUE if action complete, return FALSE if NOT COMPLETE
        /// </summary>
        /// <param name="filePath">String - File path</param>
        public static bool DeleteFile(string filePath)
        {
            //declare the return value
            bool returnValue = false;

            //try to delete file 
            try
            {
                File.Delete(filePath);
                returnValue = true;
            }
            catch
            {

            }

            return returnValue;
        }
    }
}
