namespace SQLMiner
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gpbDatabase = new System.Windows.Forms.GroupBox();
            this.btnReloadDatabase = new System.Windows.Forms.Button();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dgrMyQuery = new System.Windows.Forms.DataGridView();
            this.chkSearchShared = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpContent = new System.Windows.Forms.GroupBox();
            this.lblLastSave = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.txtQueryContent = new ScintillaNET.Scintilla();
            this.chkShare = new System.Windows.Forms.CheckBox();
            this.btnNewQuery = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.gprResult = new System.Windows.Forms.GroupBox();
            this.dgpResults = new System.Windows.Forms.DataGridView();
            this.bgrWorkerRunQuery = new System.ComponentModel.BackgroundWorker();
            this.cntxMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxMenuMakeString = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemCheckReg = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCheckRes = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxMenuQuery = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatCodeF7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentCodeF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentCodesF9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgrGetQuery = new System.ComponentModel.BackgroundWorker();
            this.bgrAutocomplete = new System.ComponentModel.BackgroundWorker();
            this.bgrAutocompleteColumn = new System.ComponentModel.BackgroundWorker();
            this.txtSeach = new wmgCMS.WaterMarkTextBox();
            this.txtQueryDescription = new wmgCMS.WaterMarkTextBox();
            this.gpbDatabase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMyQuery)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryContent)).BeginInit();
            this.gprResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgpResults)).BeginInit();
            this.cntxMenuMain.SuspendLayout();
            this.cntxMenuQuery.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDatabase
            // 
            this.gpbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDatabase.Controls.Add(this.btnReloadDatabase);
            this.gpbDatabase.Controls.Add(this.cmbDatabase);
            this.gpbDatabase.Location = new System.Drawing.Point(6, 7);
            this.gpbDatabase.Name = "gpbDatabase";
            this.gpbDatabase.Size = new System.Drawing.Size(291, 54);
            this.gpbDatabase.TabIndex = 0;
            this.gpbDatabase.TabStop = false;
            this.gpbDatabase.Text = "ODBC Database";
            // 
            // btnReloadDatabase
            // 
            this.btnReloadDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadDatabase.Location = new System.Drawing.Point(232, 18);
            this.btnReloadDatabase.Name = "btnReloadDatabase";
            this.btnReloadDatabase.Size = new System.Drawing.Size(53, 23);
            this.btnReloadDatabase.TabIndex = 1;
            this.btnReloadDatabase.Text = "Refresh";
            this.btnReloadDatabase.UseVisualStyleBackColor = true;
            this.btnReloadDatabase.Click += new System.EventHandler(this.btnReloadDatabase_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(6, 19);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(220, 21);
            this.cmbDatabase.TabIndex = 0;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClearSearch);
            this.groupBox1.Controls.Add(this.dgrMyQuery);
            this.groupBox1.Controls.Add(this.txtSeach);
            this.groupBox1.Controls.Add(this.chkSearchShared);
            this.groupBox1.Location = new System.Drawing.Point(6, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 693);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search SQL";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.Location = new System.Drawing.Point(267, 17);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(18, 23);
            this.btnClearSearch.TabIndex = 3;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // dgrMyQuery
            // 
            this.dgrMyQuery.AllowUserToAddRows = false;
            this.dgrMyQuery.AllowUserToOrderColumns = true;
            this.dgrMyQuery.AllowUserToResizeColumns = false;
            this.dgrMyQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrMyQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrMyQuery.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgrMyQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrMyQuery.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgrMyQuery.Location = new System.Drawing.Point(6, 68);
            this.dgrMyQuery.MultiSelect = false;
            this.dgrMyQuery.Name = "dgrMyQuery";
            this.dgrMyQuery.ReadOnly = true;
            this.dgrMyQuery.RowHeadersVisible = false;
            this.dgrMyQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrMyQuery.Size = new System.Drawing.Size(279, 616);
            this.dgrMyQuery.TabIndex = 2;
            this.dgrMyQuery.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrMyQuery_CellMouseClick);
            this.dgrMyQuery.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrMyQuery_MouseUp);
            this.dgrMyQuery.SelectionChanged += new System.EventHandler(this.dgrMyQuery_SelectionChanged);
            // 
            // chkSearchShared
            // 
            this.chkSearchShared.AutoSize = true;
            this.chkSearchShared.Location = new System.Drawing.Point(6, 45);
            this.chkSearchShared.Name = "chkSearchShared";
            this.chkSearchShared.Size = new System.Drawing.Size(121, 17);
            this.chkSearchShared.TabIndex = 0;
            this.chkSearchShared.Text = "Search Shared SQL";
            this.chkSearchShared.UseVisualStyleBackColor = true;
            this.chkSearchShared.CheckedChanged += new System.EventHandler(this.chkSearchShared_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpContent);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gprResult);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1014, 757);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 2;
            // 
            // grpContent
            // 
            this.grpContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContent.Controls.Add(this.lblLastSave);
            this.grpContent.Controls.Add(this.picLoading);
            this.grpContent.Controls.Add(this.txtQueryContent);
            this.grpContent.Controls.Add(this.chkShare);
            this.grpContent.Controls.Add(this.btnNewQuery);
            this.grpContent.Controls.Add(this.btnSave);
            this.grpContent.Controls.Add(this.btnRunQuery);
            this.grpContent.Controls.Add(this.txtQueryDescription);
            this.grpContent.Location = new System.Drawing.Point(3, 4);
            this.grpContent.Name = "grpContent";
            this.grpContent.Size = new System.Drawing.Size(1008, 287);
            this.grpContent.TabIndex = 0;
            this.grpContent.TabStop = false;
            this.grpContent.Text = "SQL Query Content";
            // 
            // lblLastSave
            // 
            this.lblLastSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastSave.AutoSize = true;
            this.lblLastSave.Location = new System.Drawing.Point(834, 23);
            this.lblLastSave.Name = "lblLastSave";
            this.lblLastSave.Size = new System.Drawing.Size(133, 13);
            this.lblLastSave.TabIndex = 8;
            this.lblLastSave.Text = "Last Saved : <Not Saved>";
            // 
            // picLoading
            // 
            this.picLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picLoading.Image = global::SQLMiner.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(305, 255);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(25, 25);
            this.picLoading.TabIndex = 7;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // txtQueryContent
            // 
            this.txtQueryContent.AllowDrop = true;
            this.txtQueryContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryContent.ConfigurationManager.Language = "mssql";
            this.txtQueryContent.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.txtQueryContent.Location = new System.Drawing.Point(6, 46);
            this.txtQueryContent.Margins.Margin0.Width = 20;
            this.txtQueryContent.Name = "txtQueryContent";
            this.txtQueryContent.Size = new System.Drawing.Size(996, 204);
            this.txtQueryContent.TabIndex = 1;
            this.txtQueryContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQueryContent_KeyUp);
            this.txtQueryContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQueryContent_KeyDown);
            // 
            // chkShare
            // 
            this.chkShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShare.AutoSize = true;
            this.chkShare.Location = new System.Drawing.Point(195, 260);
            this.chkShare.Name = "chkShare";
            this.chkShare.Size = new System.Drawing.Size(104, 17);
            this.chkShare.TabIndex = 5;
            this.chkShare.Text = "Share this Query";
            this.chkShare.UseVisualStyleBackColor = true;
            this.chkShare.CheckedChanged += new System.EventHandler(this.chkShare_CheckedChanged);
            // 
            // btnNewQuery
            // 
            this.btnNewQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewQuery.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewQuery.Location = new System.Drawing.Point(927, 256);
            this.btnNewQuery.Name = "btnNewQuery";
            this.btnNewQuery.Size = new System.Drawing.Size(75, 23);
            this.btnNewQuery.TabIndex = 4;
            this.btnNewQuery.Text = "New Query";
            this.btnNewQuery.UseVisualStyleBackColor = true;
            this.btnNewQuery.Click += new System.EventHandler(this.btnNewQuery_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(114, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRunQuery.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunQuery.Location = new System.Drawing.Point(6, 256);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(102, 23);
            this.btnRunQuery.TabIndex = 2;
            this.btnRunQuery.Text = "Run Query (F5)";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);
            // 
            // gprResult
            // 
            this.gprResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gprResult.Controls.Add(this.dgpResults);
            this.gprResult.Location = new System.Drawing.Point(3, 3);
            this.gprResult.Name = "gprResult";
            this.gprResult.Size = new System.Drawing.Size(1008, 456);
            this.gprResult.TabIndex = 0;
            this.gprResult.TabStop = false;
            this.gprResult.Text = "Results";
            // 
            // dgpResults
            // 
            this.dgpResults.AllowUserToAddRows = false;
            this.dgpResults.AllowUserToOrderColumns = true;
            this.dgpResults.AllowUserToResizeRows = false;
            this.dgpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgpResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgpResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgpResults.Location = new System.Drawing.Point(6, 19);
            this.dgpResults.Name = "dgpResults";
            this.dgpResults.ReadOnly = true;
            this.dgpResults.RowHeadersVisible = false;
            this.dgpResults.Size = new System.Drawing.Size(996, 428);
            this.dgpResults.TabIndex = 0;
            this.dgpResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgpResults_CellDoubleClick);
            this.dgpResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgpResults_MouseUp);
            // 
            // bgrWorkerRunQuery
            // 
            this.bgrWorkerRunQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrWorkerRunQuery_DoWork);
            this.bgrWorkerRunQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrWorkerRunQuery_RunWorkerCompleted);
            // 
            // cntxMenuMain
            // 
            this.cntxMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntxMenuMakeString,
            this.viewCellsToolStripMenuItem,
            this.toolStripSeparator1,
            this.mnuItemCheckReg,
            this.mnuItemCheckRes});
            this.cntxMenuMain.Name = "cntxMenuMain";
            this.cntxMenuMain.Size = new System.Drawing.Size(172, 98);
            // 
            // cntxMenuMakeString
            // 
            this.cntxMenuMakeString.Name = "cntxMenuMakeString";
            this.cntxMenuMakeString.Size = new System.Drawing.Size(171, 22);
            this.cntxMenuMakeString.Text = "Turn To String";
            this.cntxMenuMakeString.Click += new System.EventHandler(this.cntxMenuMakeString_Click);
            // 
            // viewCellsToolStripMenuItem
            // 
            this.viewCellsToolStripMenuItem.Name = "viewCellsToolStripMenuItem";
            this.viewCellsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewCellsToolStripMenuItem.Text = "View Cells";
            this.viewCellsToolStripMenuItem.Click += new System.EventHandler(this.viewCellsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuItemCheckReg
            // 
            this.mnuItemCheckReg.Name = "mnuItemCheckReg";
            this.mnuItemCheckReg.Size = new System.Drawing.Size(171, 22);
            this.mnuItemCheckReg.Text = "Check AQIS Reg";
            this.mnuItemCheckReg.Click += new System.EventHandler(this.mnuItemCheckReg_Click);
            // 
            // mnuItemCheckRes
            // 
            this.mnuItemCheckRes.Name = "mnuItemCheckRes";
            this.mnuItemCheckRes.Size = new System.Drawing.Size(171, 22);
            this.mnuItemCheckRes.Text = "Check AQIS Result";
            this.mnuItemCheckRes.Click += new System.EventHandler(this.mnuItemCheckRes_Click);
            // 
            // cntxMenuQuery
            // 
            this.cntxMenuQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowOwner,
            this.mnuDeleteQuery});
            this.cntxMenuQuery.Name = "cntxMenuQuery";
            this.cntxMenuQuery.Size = new System.Drawing.Size(161, 48);
            // 
            // mnuShowOwner
            // 
            this.mnuShowOwner.Name = "mnuShowOwner";
            this.mnuShowOwner.Size = new System.Drawing.Size(160, 22);
            this.mnuShowOwner.Text = "<Owner Name>";
            this.mnuShowOwner.Click += new System.EventHandler(this.mnuShowOwner_Click);
            // 
            // mnuDeleteQuery
            // 
            this.mnuDeleteQuery.Name = "mnuDeleteQuery";
            this.mnuDeleteQuery.Size = new System.Drawing.Size(160, 22);
            this.mnuDeleteQuery.Text = "Delete";
            this.mnuDeleteQuery.Click += new System.EventHandler(this.mnuDeleteQuery_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 27);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.gpbDatabase);
            this.splitContainer2.Panel1MinSize = 300;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(1324, 763);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 5;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1348, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogOut,
            this.toolStripSeparator3,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuLogOut
            // 
            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Size = new System.Drawing.Size(126, 22);
            this.mnuLogOut.Text = "Log Out...";
            this.mnuLogOut.Click += new System.EventHandler(this.mnuLogOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(123, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(126, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePass});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // mnuChangePass
            // 
            this.mnuChangePass.Name = "mnuChangePass";
            this.mnuChangePass.Size = new System.Drawing.Size(177, 22);
            this.mnuChangePass.Text = "Change Password...";
            this.mnuChangePass.Click += new System.EventHandler(this.mnuChangePass_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatCodeF7ToolStripMenuItem,
            this.commentCodeF8ToolStripMenuItem,
            this.uncommentCodesF9ToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // formatCodeF7ToolStripMenuItem
            // 
            this.formatCodeF7ToolStripMenuItem.Name = "formatCodeF7ToolStripMenuItem";
            this.formatCodeF7ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.formatCodeF7ToolStripMenuItem.Text = "Format Codes (F7)";
            this.formatCodeF7ToolStripMenuItem.Click += new System.EventHandler(this.formatCodeF7ToolStripMenuItem_Click);
            // 
            // commentCodeF8ToolStripMenuItem
            // 
            this.commentCodeF8ToolStripMenuItem.Name = "commentCodeF8ToolStripMenuItem";
            this.commentCodeF8ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.commentCodeF8ToolStripMenuItem.Text = "Comment Codes";
            this.commentCodeF8ToolStripMenuItem.Click += new System.EventHandler(this.commentCodeF8ToolStripMenuItem_Click);
            // 
            // uncommentCodesF9ToolStripMenuItem
            // 
            this.uncommentCodesF9ToolStripMenuItem.Name = "uncommentCodesF9ToolStripMenuItem";
            this.uncommentCodesF9ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.uncommentCodesF9ToolStripMenuItem.Text = "Uncomment Codes";
            this.uncommentCodesF9ToolStripMenuItem.Click += new System.EventHandler(this.uncommentCodesF9ToolStripMenuItem_Click);
            // 
            // bgrGetQuery
            // 
            this.bgrGetQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrGetQuery_DoWork);
            this.bgrGetQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrGetQuery_RunWorkerCompleted);
            // 
            // bgrAutocomplete
            // 
            this.bgrAutocomplete.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrAutocomplete_DoWork);
            this.bgrAutocomplete.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrAutocomplete_RunWorkerCompleted);
            // 
            // bgrAutocompleteColumn
            // 
            this.bgrAutocompleteColumn.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrAutocompleteColumn_DoWork);
            this.bgrAutocompleteColumn.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrAutocompleteColumn_RunWorkerCompleted);
            // 
            // txtSeach
            // 
            this.txtSeach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSeach.Location = new System.Drawing.Point(6, 19);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.Size = new System.Drawing.Size(255, 20);
            this.txtSeach.TabIndex = 1;
            this.txtSeach.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtSeach.WaterMarkText = "Type to Search";
            this.txtSeach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSeach_KeyUp);
            // 
            // txtQueryDescription
            // 
            this.txtQueryDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtQueryDescription.Location = new System.Drawing.Point(6, 20);
            this.txtQueryDescription.Name = "txtQueryDescription";
            this.txtQueryDescription.Size = new System.Drawing.Size(822, 20);
            this.txtQueryDescription.TabIndex = 0;
            this.txtQueryDescription.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtQueryDescription.WaterMarkText = "Description for your SQL Query";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 802);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JsQuery Beta";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.gpbDatabase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMyQuery)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpContent.ResumeLayout(false);
            this.grpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryContent)).EndInit();
            this.gprResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgpResults)).EndInit();
            this.cntxMenuMain.ResumeLayout(false);
            this.cntxMenuQuery.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gprResult;
        private System.Windows.Forms.GroupBox grpContent;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private wmgCMS.WaterMarkTextBox txtQueryDescription;
        private wmgCMS.WaterMarkTextBox txtSeach;
        private System.Windows.Forms.CheckBox chkSearchShared;
        private System.Windows.Forms.Button btnRunQuery;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewQuery;
        private System.Windows.Forms.CheckBox chkShare;
        private ScintillaNET.Scintilla txtQueryContent;
        private System.Windows.Forms.DataGridView dgpResults;
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker bgrWorkerRunQuery;
        private System.Windows.Forms.Button btnReloadDatabase;
        private System.Windows.Forms.ContextMenuStrip cntxMenuMain;
        private System.Windows.Forms.ToolStripMenuItem cntxMenuMakeString;
        private System.Windows.Forms.Label lblLastSave;
        private System.Windows.Forms.DataGridView dgrMyQuery;
        private System.Windows.Forms.ContextMenuStrip cntxMenuQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuShowOwner;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteQuery;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePass;
        private System.ComponentModel.BackgroundWorker bgrGetQuery;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ToolStripMenuItem viewCellsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgrAutocomplete;
        private System.ComponentModel.BackgroundWorker bgrAutocompleteColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheckReg;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheckRes;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatCodeF7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentCodeF8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncommentCodesF9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

