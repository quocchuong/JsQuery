using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Win32;

namespace johnLib
{
    public static class CommonUtils
    {
        /// <summary>
        /// Return DateTime with "MM/dd/yyyy HH:mm:ss" format
        /// </summary>
        /// <returns></returns>
        public static string getDateTimeNow()
        {
            return DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Turn Data Table intogrid view and BIND GridView - WEB ONLY
        /// </summary>
        /// <param name="dataTable">Source DataTable</param>
        /// <param name="yourGridView"></param>
        public static void turnDataTableTOGridView(DataTable dataTable, GridView yourGridView)
        {
            //cleare gridview content
            while (yourGridView.Columns.Count > 0)
            {
                yourGridView.Columns.Remove(yourGridView.Columns[0]);
            }

            //Iterate through the columns of the datatable to set the data bound field dynamically.
            foreach (DataColumn col in dataTable.Columns)
            {
                //Declare the bound field and allocate memory for the bound field.
                BoundField bfield = new BoundField();

                //Initalize the DataField value.
                bfield.DataField = col.ColumnName;

                //Initialize the HeaderText field value.
                bfield.HeaderText = col.ColumnName;

                //Add the newly created bound field to the GridView.
                yourGridView.Columns.Add(bfield);
            }

            ////Initialize the DataSource
            yourGridView.DataSource = dataTable;

            ////Bind the datatable with the GridView.
            yourGridView.DataBind();
        }

        /// <summary>
        /// Turn Data Table intogrid view and BIND GridView - Transform one column into control - WEB ONLY
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="yourGridView"></param>
        /// <param name="ColumnNeedControl"></param>
        /// <param name="ControlType"></param>
        /// <param name="CommandName"></param>
        public static void turnDataTableTOGridView(DataTable dataTable, GridView yourGridView, string ColumnNeedControl, ButtonType ControlType, string CommandName)
        {
            //cleare gridview content
            while (yourGridView.Columns.Count > 0)
            {
                yourGridView.Columns.Remove(yourGridView.Columns[0]);
            }

            //Iterate through the columns of the datatable to set the data bound field dynamically.
            foreach (DataColumn col in dataTable.Columns)
            {
                if (col.ColumnName == ColumnNeedControl)
                {
                    //Declare the bound field and allocate memory for the bound field.
                    ButtonField bfield = new ButtonField();

                    //choose the type of button
                    bfield.ButtonType = ControlType;

                    //Initalize the DataField value.
                    bfield.DataTextField = col.ColumnName;

                    //Initialize the HeaderText field value.
                    bfield.HeaderText = col.ColumnName;

                    bfield.CommandName = CommandName;

                    //Add the newly created bound field to the GridView.
                    yourGridView.Columns.Add(bfield);
                }
                else
                {
                    //Declare the bound field and allocate memory for the bound field.
                    BoundField bfield = new BoundField();

                    //Initalize the DataField value.
                    bfield.DataField = col.ColumnName;

                    //Initialize the HeaderText field value.
                    bfield.HeaderText = col.ColumnName;

                    //Add the newly created bound field to the GridView.
                    yourGridView.Columns.Add(bfield);
                }
            }

            ////Initialize the DataSource
            yourGridView.DataSource = dataTable;

            ////Bind the datatable with the GridView.
            yourGridView.DataBind();
        }

        /// <summary>
        /// Turn Data Table into GridView - Aadd one control into the grid as well - WEB ONLY
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="yourGridView"></param>
        /// <param name="newColumnName"></param>
        /// <param name="buttonText"></param>
        /// <param name="columnPosition"></param>
        /// <param name="buttonType"></param>
        /// <param name="newCommandName"></param>
        public static void turnDataTableTOGridView(DataTable dataTable, GridView yourGridView, string newColumnName, string newButtonText, int columnPosition, ButtonType buttonType, string newCommandName)
        {
            //cleare gridview content
            while (yourGridView.Columns.Count > 0)
            {
                yourGridView.Columns.Remove(yourGridView.Columns[0]);
            }

            // create a column
            ButtonField newColumn = new ButtonField();
            newColumn.ButtonType = buttonType;
            newColumn.HeaderText = newColumnName;
            newColumn.Text = newButtonText;
            newColumn.CommandName = newCommandName;

            //add column from 0 to desire position - 2
            for (int i = 0; i < (columnPosition - 1); i++)
            {
                //Declare the bound field and allocate memory for the bound field.
                BoundField bfield = new BoundField();

                //Initalize the DataField value.
                bfield.DataField = dataTable.Columns[i].ColumnName;

                //Initialize the HeaderText field value.
                bfield.HeaderText = dataTable.Columns[i].ColumnName;

                //Add the newly created bound field to the GridView.
                yourGridView.Columns.Add(bfield);
            }

            //add new column
            yourGridView.Columns.Add(newColumn);

            //add column from desire position - 1 to end original grid
            for (int i = (columnPosition - 1); i < dataTable.Columns.Count; i++)
            {
                //Declare the bound field and allocate memory for the bound field.
                BoundField bfield = new BoundField();

                //Initalize the DataField value.
                bfield.DataField = dataTable.Columns[i].ColumnName;

                //Initialize the HeaderText field value.
                bfield.HeaderText = dataTable.Columns[i].ColumnName;

                //Add the newly created bound field to the GridView.
                yourGridView.Columns.Add(bfield);
            }

            //Initialize the DataSource
            yourGridView.DataSource = dataTable;

            //Bind the datatable with the GridView.
            yourGridView.DataBind();
        }

        /// <summary>
        /// Generate Unique Key String
        /// </summary>
        /// <returns></returns>
        public static string getUniqueKeyString()
        {
            return System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// List ODBC DataSources
        /// </summary>
        /// <returns></returns>
        public static List<string> ListODBCSources()
        {
            List<string> list = new List<string>();
            list.AddRange(EnumDsn(Registry.CurrentUser));
            list.AddRange(EnumDsn(Registry.LocalMachine));
            return list;
        }
        
        private static IEnumerable<string> EnumDsn(RegistryKey rootKey)
        {
            RegistryKey regKey = rootKey.OpenSubKey(@"Software\ODBC\ODBC.INI\ODBC Data Sources");
            if (regKey != null)
            {
                foreach (string name in regKey.GetValueNames())
                {
                    string value = regKey.GetValue(name, "").ToString();
                    yield return name;
                }
            }
        }
    }
}
