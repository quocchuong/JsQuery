namespace SQLMiner
{
    partial class frmCellContents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCellContents));
            this.txtCellContents = new ScintillaNET.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.txtCellContents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCellContents
            // 
            this.txtCellContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCellContents.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.txtCellContents.Location = new System.Drawing.Point(0, 0);
            this.txtCellContents.Name = "txtCellContents";
            this.txtCellContents.Size = new System.Drawing.Size(384, 362);
            this.txtCellContents.Styles.BraceBad.Size = 12F;
            this.txtCellContents.Styles.BraceLight.Size = 12F;
            this.txtCellContents.Styles.ControlChar.Size = 12F;
            this.txtCellContents.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtCellContents.Styles.Default.Size = 12F;
            this.txtCellContents.Styles.IndentGuide.Size = 12F;
            this.txtCellContents.Styles.LastPredefined.Size = 12F;
            this.txtCellContents.Styles.LineNumber.Size = 12F;
            this.txtCellContents.Styles.Max.Size = 12F;
            this.txtCellContents.TabIndex = 0;
            // 
            // frmCellContents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.txtCellContents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "frmCellContents";
            this.Text = "JsQuery - Cell Contents";
            ((System.ComponentModel.ISupportInitialize)(this.txtCellContents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla txtCellContents;
    }
}