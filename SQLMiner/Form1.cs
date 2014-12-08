using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using johnLib;
using JMinerData;
using PoorMansTSqlFormatterLib;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;

namespace SQLMiner
{
    public partial class frmMain : Form
    {
        OdbcDataAdapter specialda;
        DataTable specialdTable;
        DataTable specialQueryTable;
        string DSNname;
        string CurrentUserID;
        string CurrentQueryID;
        string SomeoneID;
        string CurrentContent;
        string NewContent;
        bool FormLoading = true;
        bool ClickingShowShareButton = false;
        bool SelectingQuery = true;
        bool newQuery = false;
        bool SearchingQuery = false;
        bool UserUpdateLastDatabase = false;
        login LoginForm;
        string CurrentSearchTerm;
        List<string> autoCollection = new List<string>();

        public frmMain(string userID, login loginForm)
        {
            InitializeComponent();
            CurrentUserID = userID;
            LoginForm = loginForm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                btnSave.Text = "Save";

                FormLoading = true;

                //load ODBC database
                btnReloadDatabase_Click(this, EventArgs.Empty);

                //check my show share setting
                userObj myObject = new userObj(CurrentUserID);

                //show my list of queries
                if (myObject.SearchShare.ToUpper() == "T")
                {
                    try
                    {
                        chkSearchShared.Checked = true;
                        picLoading.Visible = true;

                        bgrGetQuery.RunWorkerAsync("showallshared");
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
                else
                {
                    try
                    {
                        chkSearchShared.Checked = false;
                        picLoading.Visible = true;

                        bgrGetQuery.RunWorkerAsync("showmineonly");
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }

                FormLoading = false;
            }
            catch (Exception exm)
            {
                string mess = exm.Message;
            }
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            picLoading.Visible = true;
            
            //check if the space is empty, otherwise run query
            if (txtQueryContent.Text == "")
            {
                MessageBox.Show("Uh! Are we missing an SQL query somewhere here?");
                picLoading.Visible = false;
            }
            else
            {
                try
                {
                    //get the query
                    string sqlQuery = txtQueryContent.Text;

                    bgrWorkerRunQuery.RunWorkerAsync(sqlQuery);
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                }
            }
        }

        private void bgrWorkerRunQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string queryString = (string)e.Argument;
                e.Result = PopulateDataGrid(queryString);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show("Error: " + message);
            }
        }

        private void bgrWorkerRunQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //populate the grid with data
            PopulateGrid();

            //update the notice table
            gprResult.Text = specialdTable.Rows.Count + " results found.";

            picLoading.Visible = false;
        }

        //process data and query
        private DataTable PopulateDataGrid(string sqlquery)
        {               
            //get connection to database using the selected DSN from the database selection box
            OdbcConnection con = johnLib.DataUtils.getOdbcConnection(DSNname);
                        
            //build the data adapter
            string sqlString = sqlquery;
            specialda = new OdbcDataAdapter(sqlString, con);

            //create a DataTable to hold the query results
            specialdTable = new DataTable();

            try
            {
                con.Open();
                //fill the DataTable
                specialda.Fill(specialdTable);
            }
            catch (SqlException ex)
            {
                string mess = ex.Message;
                MessageBox.Show("Error: " + mess);
            }
            catch (Exception e)
            {
                string mess = e.Message;
                MessageBox.Show("Error: " + mess);
            }
            finally
            {
                con.Close();
            }

            return specialdTable;
        }

        //draw the grid
        private void PopulateGrid()
        {
            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();

            //set the BindingSource DataSource
            bSource.DataSource = specialdTable;

            //set the datasource of the gridview to null
            dgpResults.DataSource = null;

            //set the DataGridView DataSource
            dgpResults.DataSource = bSource;
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSNname = cmbDatabase.Text;

            //update the setting for this user
            if (FormLoading == false)
            {
                UserUpdateLastDatabase = true;

                userObj thisUser = new userObj(CurrentUserID);
                thisUser.LastDataBase = DSNname;
                thisUser.update();

                UserUpdateLastDatabase = false;
            }            
        }

        private void txtQueryContent_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //{
            //    btnRunQuery_Click(this, EventArgs.Empty);
            //}
        }

        private void btnReloadDatabase_Click(object sender, EventArgs e)
        {
            if (UserUpdateLastDatabase == false)
            {
                //call the function to get the DSN list
                List<string> listODBC = johnLib.CommonUtils.ListODBCSources();

                //pass the datasource list to the combobox
                cmbDatabase.DataSource = listODBC;

                //select the last database
                userObj thisuser = new userObj(CurrentUserID);
                cmbDatabase.SelectedIndex = cmbDatabase.FindStringExact(thisuser.LastDataBase.ToString());
            }
        }

        //show context menu on right click
        private void dgpResults_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dgpResults.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    cntxMenuMain.Show(dgpResults, e.Location);
                }
            }
        }

        private void cntxMenuMakeString_Click(object sender, EventArgs e)
        {
            //get the content of all selected cell
            IEnumerator selectedValue = dgpResults.SelectedCells.GetEnumerator();

            string valueList = "";
            string txtString = "";

            //run through the list and make the string
            while (selectedValue.MoveNext())
            {
                try
                {
                    string selectedCell = ((DataGridViewTextBoxCell)selectedValue.Current).Value.ToString();

                    valueList = valueList + "'" + selectedCell + "',";
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    MessageBox.Show(message);
                }
            }
            
            txtString = valueList.Substring(0,valueList.Length-1);
            Clipboard.SetText(txtString);            
            MessageBox.Show("String copied to Clipboard");
        }

        private void dgrMyQuery_MouseUp(object sender, MouseEventArgs e)
        {   
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dgrMyQuery.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    if (CurrentQueryID != "")
                    {
                        //prepare menu
                        queryObj selectedQuery = new queryObj(CurrentQueryID);
                        if (selectedQuery.UserID == CurrentUserID)
                        {
                            //this is my query
                            mnuShowOwner.Visible = false;
                            mnuDeleteQuery.Visible = true;
                        }
                        else
                        {
                            userObj otheruser = new userObj(selectedQuery.UserID);
                            SomeoneID = selectedQuery.UserID;

                            //this is my query
                            mnuShowOwner.Text = "Show " + otheruser.Name + "'s queries";
                            mnuShowOwner.Visible = true;
                            mnuDeleteQuery.Visible = false;
                        }

                        //show menu
                        cntxMenuQuery.Show(dgrMyQuery, e.Location);
                    }
                }
            }
            else
            { 
                //select if currentqueryID == ""
                if (CurrentQueryID == "")
                {
                    int countRow = dgrMyQuery.Rows.Count;

                    //check grid row
                    if (dgrMyQuery.Rows.Count > 0)
                    {
                        CurrentQueryID = dgrMyQuery.Rows[0].Cells[0].Value.ToString();

                        dgrMyQuery.Rows[0].Selected = true;

                        dgrMyQuery_SelectionChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            //reset user and id and close this window
            CurrentUserID = "";            
            SomeoneID = "";

            //hide the control panel and show login form
            this.Hide();
            LoginForm.Show();
        }

        private void bgrGetQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string searchWhat = (string)e.Argument;

                if (searchWhat == "showmineonly")
                {
                    //call the function to get all my query
                    e.Result = showMyListOfQuery();
                }
                else if (searchWhat == "showallshared")
                {
                    //call the function to get all my query
                    e.Result = showAllSharedQuery();
                }
                else if (searchWhat == "searchallshared")
                {
                    //call the function to get all my query
                    e.Result = searchAllSharedQuery();
                }
                else if (searchWhat == "searchmyonly")
                {
                    //call the function to get all my query
                    e.Result = searchMyQuery();
                }
                else if (searchWhat == "showotheronly")
                {
                    //call the function to get all my query
                    e.Result = showOtherQuery();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show("Error: " + message);
            }
        }

        private void bgrGetQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //populate the grid with data
            PopulateQueryGrid();

            picLoading.Visible = false;

            //reset the clicking sharebutton
            ClickingShowShareButton = false;
            SearchingQuery = false;
        }        

        private void PopulateQueryGrid()
        {
            //BindingSource to sync DataTable and DataGridView
            BindingSource bSource = new BindingSource();

            //set the BindingSource DataSource
            bSource.DataSource = specialQueryTable;

            //set the datasource of the gridview to null
            dgrMyQuery.DataSource = null;

            //set the DataGridView DataSource
            dgrMyQuery.DataSource = bSource;

            //set the column width
            setDataGridColumnSize();
        }

        private void setDataGridColumnSize()
        {
            DataGridViewColumn firstColumn = dgrMyQuery.Columns[0];
            firstColumn.Width = 50;
        }

        private DataTable showMyListOfQuery()
        {
            SomeoneID = "";

            //search all my querys
            userObj myUserObj = new userObj(CurrentUserID);

            //get all my queries
            queryObj newQuery = new queryObj();
            DataTable allmyQuery = newQuery.searchQuery("", myUserObj.UserID, "", "", "", "");

            //chop the table to only have 2 columns
            allmyQuery.Columns.Remove("userID");
            allmyQuery.Columns.Remove("querycontent");
            allmyQuery.Columns.Remove("sharedFlag");
            allmyQuery.Columns.Remove("activeFlag");
            allmyQuery.Columns.Remove("lastSaved");

            specialQueryTable = allmyQuery;

            //save search share setting to F
            myUserObj.SearchShare = "F";
            myUserObj.update();

            //run worker async to fill table
            return specialQueryTable;
        }

        private DataTable showOtherQuery()
        {
            userObj otherUser = new userObj(SomeoneID);

            //get all my queries
            queryObj newQuery = new queryObj();
            DataTable allmyQuery = newQuery.searchQuery("", SomeoneID, "", "", "T", "");

            //chop the table to only have 2 columns
            allmyQuery.Columns.Remove("userID");
            allmyQuery.Columns.Remove("querycontent");
            allmyQuery.Columns.Remove("sharedFlag");
            allmyQuery.Columns.Remove("activeFlag");
            allmyQuery.Columns.Remove("lastSaved");

            specialQueryTable = allmyQuery;

            //save search share setting to F
            otherUser.SearchShare = "F";
            otherUser.update();

            //run worker async to fill table
            return specialQueryTable;
        }

        private DataTable showAllSharedQuery()
        {
            //search all my querys
            userObj myUserObj = new userObj(CurrentUserID);

            //get all my queries
            queryObj newQuery = new queryObj();
            DataTable allmyQuery = newQuery.searchQuery("", "", "", "", "T", "");

            //chop the table to only have 2 columns
            allmyQuery.Columns.Remove("userID");
            allmyQuery.Columns.Remove("querycontent");
            allmyQuery.Columns.Remove("sharedFlag");
            allmyQuery.Columns.Remove("activeFlag");
            allmyQuery.Columns.Remove("lastSaved");

            specialQueryTable = allmyQuery;

            //save search share setting to T            
            myUserObj.SearchShare = "T";
            myUserObj.update();

            //run worker async to fill table
            return specialQueryTable;
        }

        private DataTable searchAllSharedQuery()
        {
            //search all my querys
            userObj myUserObj = new userObj(CurrentUserID);

            //get all my queries
            queryObj newQuery = new queryObj();
            DataTable allmyQuery = newQuery.searchAllSharedQuery(CurrentSearchTerm);

            specialQueryTable = allmyQuery;

            //run worker async to fill table
            return specialQueryTable;
        }

        private DataTable searchMyQuery()
        {
            //search all my querys
            userObj myUserObj = new userObj(CurrentUserID);

            //get all my queries
            queryObj newQuery = new queryObj();
            DataTable allmyQuery = newQuery.searchMyQuery(CurrentUserID, CurrentSearchTerm);

            specialQueryTable = allmyQuery;

            //run worker async to fill table
            return specialQueryTable;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //always set the first columnsize for query gridview to 50
            setDataGridColumnSize();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //always set the first columnsize for query gridview to 50
            setDataGridColumnSize();
        }

        private void chkSearchShared_CheckedChanged(object sender, EventArgs e)
        {
            CurrentQueryID = "";

            if (FormLoading == false)
            {
                //if check then show all shared and saved the setting to my account
                if (chkSearchShared.Checked)
                {
                    try
                    {
                        picLoading.Visible = true;

                        ClickingShowShareButton = true;

                        //show all shared
                        bgrGetQuery.RunWorkerAsync("showallshared");
                    }
                    catch (Exception ex)
                    {
                        string mess = ex.Message;
                    }
                }
                //if uncheck then show my query only
                else
                {
                    try
                    {
                        picLoading.Visible = true;

                        ClickingShowShareButton = true;

                        //show all shared
                        bgrGetQuery.RunWorkerAsync("showmineonly");
                    }
                    catch (Exception ex)
                    {
                        string mess = ex.Message;
                    }
                }
            }
        }
                
        private void txtSeach_KeyUp(object sender, KeyEventArgs e)
        {
            CurrentSearchTerm = txtSeach.Text;
            SearchingQuery = true;
            CurrentQueryID = "";

            //if search share check then search all share
            if (chkSearchShared.Checked)
            {
                try
                {
                    picLoading.Visible = true;

                    bgrGetQuery.RunWorkerAsync("searchallshared");
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
            //if search share not check then search my share only
            else
            {
                try
                {
                    picLoading.Visible = true;

                    bgrGetQuery.RunWorkerAsync("searchmyonly");
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSeach.Text = "";

            KeyEventArgs arg = new KeyEventArgs(Keys.Delete);

            txtSeach_KeyUp(sender, arg);
        }

        private void dgrMyQuery_SelectionChanged(object sender, EventArgs e)
        {
            if (FormLoading == false)
            {
                if (ClickingShowShareButton == false)
                {
                    if (newQuery == false)
                    {
                        if (SearchingQuery == false)
                        {
                            try
                            {
                                //get the queryID
                                string selectedQueryID = ""; 
                                selectedQueryID = dgrMyQuery.SelectedRows[0].Cells[0].Value.ToString();

                                if (selectedQueryID != "")
                                {
                                    //get the query
                                    queryObj selectedQuery = new queryObj(selectedQueryID);

                                    //show the query content on selection change
                                    CurrentQueryID = selectedQuery.QueryID;
                                    txtQueryDescription.Text = selectedQuery.Description;
                                    txtQueryContent.Text = ConvertContentForShowing(selectedQuery.QueryContent);
                                    lblLastSave.Text = "Last Saved: " + selectedQuery.LastSaved;

                                    CurrentContent = ConvertContentForShowing(selectedQuery.QueryContent);

                                    NewContent = txtQueryContent.Text;

                                    SelectingQuery = true;

                                    if (selectedQuery.SharedFlag.ToUpper() == "T")
                                    {
                                        chkShare.Checked = true;
                                    }
                                    else
                                    {
                                        chkShare.Checked = false;
                                    }

                                    SelectingQuery = false;

                                    //check if this query is my, if not then disable somebutton, 
                                    if (selectedQuery.UserID != CurrentUserID)
                                    {
                                        txtQueryDescription.Enabled = false;
                                        btnSave.Enabled = false;
                                        chkShare.Enabled = false;
                                    }
                                    else
                                    {
                                        txtQueryDescription.Enabled = true;
                                        btnSave.Enabled = false;
                                        btnSave.Text = "Update";
                                        chkShare.Enabled = true;
                                    }
                                }
                            }
                            catch(Exception ex)
                            { 
                                //just do nothing
                            }
                        }
                    }
                }
            }
        }

        private void txtQueryContent_KeyUp(object sender, KeyEventArgs e)
        {
            //run the query when pressing F5 - this has been disable to allow F5 on form
            if (e.KeyCode == Keys.F7)
            {
                if (txtQueryContent.Selection.Text.Length > 0)
                {
                    //reformat and replace the selected string
                    SqlFormattingManager newSQLManager = new SqlFormattingManager();
                    string formattedText = newSQLManager.Format(txtQueryContent.Selection.Text);
                    //formattedText = formattedText.Trim();

                    //replace the selected one                
                    txtQueryContent.Selection.Clear();

                    //insert the formatted string to the current cursor
                    txtQueryContent.InsertText(formattedText);
                }
                else
                { 
                    SqlFormattingManager newSQLManager = new SqlFormattingManager();
                    txtQueryContent.Text = newSQLManager.Format(txtQueryContent.Text);                    
                }
            }
            else
            {
                NewContent = txtQueryContent.Text;
                if (CurrentContent != NewContent)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false ;
                }                
            }

            if (e.Control && (e.KeyCode == Keys.Space))
            {
                picLoading.Visible = true;

                //get the string right before cursor                
                int caretPosition = txtQueryContent.Selection.Start;
                int beforeCarretPosition = caretPosition - 1;

                // now find 1 text that occurs before the caret
                string textbeforeCarret = txtQueryContent.Text.Substring(beforeCarretPosition, 1);

                //if this is not "." then get the word
                if (textbeforeCarret.ToString() == ".")
                {
                    // now find all text that occurs before the caret
                    string textUpToCaret = txtQueryContent.Text.Substring(0, caretPosition);

                    // now we can look for the last space character in the
                    // textUpToCaret to find the word
                    int lastSpaceIndex = textUpToCaret.LastIndexOf(" ");

                    if (lastSpaceIndex < 0)
                        lastSpaceIndex = 0;

                    string tablename = textUpToCaret.Substring(lastSpaceIndex);

                    //remove "."
                    tablename = tablename.Substring(0, tablename.Length - 1);

                    //call the background worker to get data for the autocomplete
                    bgrAutocompleteColumn.RunWorkerAsync(tablename);
                }
                else
                {
                    // now find all text that occurs before the caret
                    string textUpToCaret = txtQueryContent.Text.Substring(0, caretPosition);

                    // now we can look for the last space character in the
                    // textUpToCaret to find the word
                    int lastSpaceIndex = textUpToCaret.LastIndexOf(" ");

                    if (lastSpaceIndex < 0)
                        lastSpaceIndex = 0;

                    string lettersBeforeCaret = textUpToCaret.Substring(lastSpaceIndex);

                    //call the background worker to get data for the autocomplete
                    bgrAutocomplete.RunWorkerAsync(lettersBeforeCaret);
                }                
            }
        }

        private void chkShare_CheckedChanged(object sender, EventArgs e)
        {
            if (CurrentQueryID != "")
            {
                if (SelectingQuery == false)
                {
                    //update the query shareflag for this
                    queryObj currentQuery = new queryObj(CurrentQueryID);

                    if (chkShare.Checked)
                    {
                        currentQuery.SharedFlag = "T";
                        currentQuery.update();
                    }
                    else
                    {
                        currentQuery.SharedFlag = "F";
                        currentQuery.update();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                if (txtQueryDescription.Text != "" && txtQueryContent.Text != "")
                {
                    string localShareFlag = "F";

                    if (chkShare.Checked)
                    {
                        localShareFlag = "T";
                    }
                    else
                    {
                        localShareFlag = "F";
                    }

                    queryObj newQuery = new queryObj();
                    bool saveGood = newQuery.insert(CurrentUserID, SecurityUtils.RemoveSQLInjection(txtQueryDescription.Text), ConvertContentForSaving(txtQueryContent.Text), localShareFlag, "T");

                    //reload my query and show selected one
                    if (saveGood)
                    {
                        try
                        {
                            //show my queries

                            picLoading.Visible = true;

                            ClickingShowShareButton = true;

                            //show all shared
                            bgrGetQuery.RunWorkerAsync("showmineonly");

                            btnSave.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please specify description and query content before we can save it");
                }
            }
            else if (btnSave.Text == "Update")
            {
                //update the content of the query
                queryObj currentQuery = new queryObj(CurrentQueryID);

                currentQuery.QueryContent = ConvertContentForSaving(txtQueryContent.Text);
                currentQuery.Description = SecurityUtils.RemoveSQLInjection(txtQueryDescription.Text);

                currentQuery.update();

                CurrentContent = txtQueryContent.Text;

                btnSave.Enabled = false;
            }
        }

        private string ConvertContentForSaving(string content)
        {
            content = content.Replace("'", "<$>");

            return content;
        }

        private string ConvertContentForShowing(string content)
        {
            content = content.Replace("<$>", "'");

            return content;
        }

        private void btnNewQuery_Click(object sender, EventArgs e)
        {
            newQuery = true;

            //clear the grid
            dgpResults.DataSource = null;

            //reset all things
            txtQueryDescription.Enabled = true;
            txtQueryDescription.Text = "";
            txtQueryContent.Text = "";
            CurrentQueryID = "";
            btnSave.Enabled = true;
            btnSave.Text = "Save";
            chkShare.Checked = false;
            lblLastSave.Text = "Last Saved : <Not Saved>";
            dgrMyQuery.ClearSelection();

            newQuery = false;
        }

        private void dgrMyQuery_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgrMyQuery.Rows[e.RowIndex].Selected = true;
            }
        }

        private void mnuDeleteQuery_Click(object sender, EventArgs e)
        {
            //ask if want to delete this query
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this query number [" + CurrentQueryID + "]", "Delete Query", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                queryObj thisquery = new queryObj();
                bool deletedQuery = thisquery.delete(CurrentQueryID);

                if (deletedQuery)
                {
                    try
                    {
                        btnNewQuery_Click(this, EventArgs.Empty);

                        //show my queries

                        picLoading.Visible = true;

                        ClickingShowShareButton = true;

                        //show all shared
                        bgrGetQuery.RunWorkerAsync("showmineonly");
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void mnuShowOwner_Click(object sender, EventArgs e)
        {
            try
            {
                //show my queries

                picLoading.Visible = true;

                ClickingShowShareButton = true;

                //show all shared
                bgrGetQuery.RunWorkerAsync("showotheronly");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void mnuChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass passwordForm = new frmChangePass(CurrentUserID);

            passwordForm.ShowDialog();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnRunQuery_Click(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.F3)
            {
                //focus the search box
                txtSeach.Focus();
            }
        }

        private void viewCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get the list of all selected cells
            //get the content of all selected cell
            IEnumerator selectedValue = dgpResults.SelectedCells.GetEnumerator();

            //run through the list and make the string
            while (selectedValue.MoveNext())
            {
                try
                {
                    string selectedCell = ((DataGridViewTextBoxCell)selectedValue.Current).Value.ToString();

                    string[] filterVal = new string[] { "\\rtf1", "\\ansi", "\\ansicpg1252", "\\deff0", "\\deflang3081", "\\fonttbl", "\\f0", "\\fswiss", "\\fprq2", "\\fcharset0", "Calibri;", "\\f1", "System;", "\\viewkind4", "\\uc1", "\\pard", "\\fi-360", "\\li720", "\\sa200", "\\sl276", "\\slmult1", "\\tab", "\\par", "cpg1252", "\\trowd", "\\trleft-123", "\\cellx1257", "\\intbl", "\\cell", "\\row", "\\pard", "\\fbidis", "\\deflang1033", "\\colortbl", "\\red0", "\\green0", "\\blue0", "\\ltrpar", "\\b", "\\fs20", "\\fs22", "\\fs24","\\cf10","\\cf0","\\cf1","\\ul", "{", "}"};

                    //filter the string
                    for (int j = 0; j < filterVal.Length; j++)
                    {
                        selectedCell = selectedCell.Replace(filterVal[j].ToString(), "");
                    }
                    
                    //show the selected cells in a new forms
                    frmCellContents newFormCell = new frmCellContents(selectedCell);
                    newFormCell.Show();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    MessageBox.Show(message);
                }
            }            
        }

        //do work
        private void bgrAutocomplete_DoWork(object sender, DoWorkEventArgs e)
        {
            //clean out the list
            autoCollection.Clear();

            string stringtoSearch = (string)e.Argument;

            stringtoSearch = stringtoSearch.Trim();

            try
            {
                //query the database to get all table and column name   
                //get connection to database using the selected DSN from the database selection box
                OdbcConnection con = johnLib.DataUtils.getOdbcConnection(DSNname);

                //build the data adapter
                string sqlString = "select distinct(TABLE_NAME) from INFORMATION_SCHEMA.COLUMNS where [TABLE_NAME] like '" + stringtoSearch + "%'";
                OdbcDataAdapter autoDA = new OdbcDataAdapter(sqlString, con);

                //create a DataTable to hold the query results
                DataTable autocompleteTable = new DataTable();

                try
                {
                    con.Open();
                    //fill the DataTable
                    autoDA.Fill(autocompleteTable);
                }
                catch (SqlException ex)
                {
                    string mess = ex.Message;
                    MessageBox.Show("Error: " + mess);
                }
                catch (Exception exe)
                {
                    //do nothing
                }
                finally
                {
                    con.Close();
                }
                //add value to the collection

                for (int i = 0; i <= autocompleteTable.Rows.Count - 1; i++)
                {
                    autoCollection.Add(autocompleteTable.Rows[i]["TABLE_NAME"].ToString());                    
                }                
            }
            catch (Exception ex)
            {
                //do nothing
            }            
        }

        //do work after autocomplete
        private void bgrAutocomplete_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtQueryContent.AutoComplete.Show(autoCollection);

            picLoading.Visible = false;
        }

        private void bgrAutocompleteColumn_DoWork(object sender, DoWorkEventArgs e)
        {
            //clean out the list
            autoCollection.Clear();

            string stringtoSearch = (string)e.Argument;

            stringtoSearch = stringtoSearch.Trim();

            try
            {
                //query the database to get all table and column name   
                //get connection to database using the selected DSN from the database selection box
                OdbcConnection con = johnLib.DataUtils.getOdbcConnection(DSNname);

                //build the data adapter
                string sqlString = "select distinct(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS where [TABLE_NAME] = '" + stringtoSearch + "'";
                OdbcDataAdapter autoDA = new OdbcDataAdapter(sqlString, con);

                //create a DataTable to hold the query results
                DataTable autocompleteTable = new DataTable();

                try
                {
                    con.Open();
                    //fill the DataTable
                    autoDA.Fill(autocompleteTable);
                }
                catch (SqlException ex)
                {
                    string mess = ex.Message;
                    MessageBox.Show("Error: " + mess);
                }
                catch (Exception exe)
                {
                    //do nothing;
                }
                finally
                {
                    con.Close();
                }
                //add value to the collection

                for (int i = 0; i <= autocompleteTable.Rows.Count - 1; i++)
                {
                    autoCollection.Add(autocompleteTable.Rows[i]["COLUMN_NAME"].ToString());
                }
            }
            catch (Exception ex)
            {
                //do nothing
            }            
        }

        private void bgrAutocompleteColumn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtQueryContent.AutoComplete.Show(autoCollection);

            picLoading.Visible = false;
        }

        //open this file in registration folder
        private void mnuItemCheckReg_Click(object sender, EventArgs e)
        {
            //get the content of all selected cell
            IEnumerator selectedValue = dgpResults.SelectedCells.GetEnumerator();

            Boolean missingFlag = false;

            //run through the list and make the string
            while (selectedValue.MoveNext())
            {
                try
                {
                    string projectName = ((DataGridViewTextBoxCell)selectedValue.Current).Value.ToString();
                    
                    //try open file
                    try
                    {
                        string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Export\" + projectName + ".csv";
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Export\" + projectName + ".dun";
                            System.Diagnostics.Process.Start(filePath);
                        }
                        catch (Exception exi)
                        {
                            //file is missing, swith file missing flag on
                            missingFlag = true;
                        }             
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    MessageBox.Show(message);
                }
            }

            //offer to open folder when a file is missing
            if (missingFlag)
            {
                DialogResult dialogResult = MessageBox.Show("Files are missing or processed, do you want to open the folder", "Missing File", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {                    
                    //open folder
                    try
                    {
                        string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Export\";
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        MessageBox.Show(message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing
                }
            }
        }

        private void mnuItemCheckRes_Click(object sender, EventArgs e)
        {
            //get the content of all selected cell
            IEnumerator selectedValue = dgpResults.SelectedCells.GetEnumerator();

            Boolean missingFlag = false;

            //run through the list and make the string
            while (selectedValue.MoveNext())
            {
                try
                {
                    string projectName = ((DataGridViewTextBoxCell)selectedValue.Current).Value.ToString();

                    //try open file
                    try
                    {
                        string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Results\" + projectName + ".csv";
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Results\" + projectName + ".dun";
                            System.Diagnostics.Process.Start(filePath);
                        }
                        catch (Exception exi)
                        {
                            //file is missing, swith file missing flag on
                            missingFlag = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    MessageBox.Show(message);
                }
            }

            //offer to open folder when a file is missing
            if (missingFlag)
            {
                DialogResult dialogResult = MessageBox.Show("Files are missing or processed, do you want to open the folder", "Missing File", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //open folder
                    try
                    {
                        string filePath = @"\\dts.local\lab\LIMS\lw-prod\transfers\AQIS\Results\";
                        System.Diagnostics.Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        MessageBox.Show(message);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do nothing
                }
            }
        }

        private void formatCodeF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtQueryContent.Selection.Text.Length > 0)
            {
                //reformat and replace the selected string
                SqlFormattingManager newSQLManager = new SqlFormattingManager();
                string formattedText = newSQLManager.Format(txtQueryContent.Selection.Text);
                //formattedText = formattedText.Trim();

                //replace the selected one                
                txtQueryContent.Selection.Clear();

                //insert the formatted string to the current cursor
                txtQueryContent.InsertText(formattedText);
            }
            else
            {
                SqlFormattingManager newSQLManager = new SqlFormattingManager();
                txtQueryContent.Text = newSQLManager.Format(txtQueryContent.Text);
            }
        }

        private void commentCodeF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtQueryContent.Selection.Text.Length > 0)
            {
                //reformat and replace the selected string
                 string replacementString = "/*" + txtQueryContent.Selection.Text + "*/";
                //formattedText = formattedText.Trim();

                //replace the selected one                
                txtQueryContent.Selection.Clear();

                //insert the formatted string to the current cursor
                txtQueryContent.InsertText(replacementString);
            }
            else
            {
                txtQueryContent.Text = "/*" + txtQueryContent.Text + "*/";
            }
        }

        private void uncommentCodesF9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtQueryContent.Selection.Text.Length > 0)
            {
                //reformat and replace the selected string
                string replacementString = txtQueryContent.Selection.Text.Replace("/*","");
                replacementString = replacementString.Replace("*/", "");
                //formattedText = formattedText.Trim();

                //replace the selected one                
                txtQueryContent.Selection.Clear();

                //insert the formatted string to the current cursor
                txtQueryContent.InsertText(replacementString);
            }
            else
            {
                txtQueryContent.Text = txtQueryContent.Text.Replace("/*","");
                txtQueryContent.Text = txtQueryContent.Text.Replace("*/", "");
            }
        }

        private void dgpResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //simulate the right click view content            
            viewCellsToolStripMenuItem_Click(this, EventArgs.Empty);
        }
    }
}
