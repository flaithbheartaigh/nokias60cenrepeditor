namespace S60.CenRepEditor
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
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.saveAllChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.oneFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.allChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.lstCenRep = new System.Windows.Forms.ListView();
          this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.dlgOpenRofs = new System.Windows.Forms.FolderBrowserDialog();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.label1 = new System.Windows.Forms.Label();
          this.cmbName = new System.Windows.Forms.ComboBox();
          this.label2 = new System.Windows.Forms.Label();
          this.comboBox1 = new System.Windows.Forms.ComboBox();
          this.label3 = new System.Windows.Forms.Label();
          this.comboBox2 = new System.Windows.Forms.ComboBox();
          this.menuStrip1.SuspendLayout();
          this.tableLayoutPanel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
          this.menuStrip1.Size = new System.Drawing.Size(944, 24);
          this.menuStrip1.TabIndex = 0;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // fájlToolStripMenuItem
          // 
          this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem});
          this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
          this.fájlToolStripMenuItem.Size = new System.Drawing.Size(35, 18);
          this.fájlToolStripMenuItem.Text = "File";
          // 
          // openToolStripMenuItem
          // 
          this.openToolStripMenuItem.Name = "openToolStripMenuItem";
          this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.openToolStripMenuItem.Text = "Open";
          this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenRofsDir);
          // 
          // saveToolStripMenuItem
          // 
          this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.saveAllChangesToolStripMenuItem});
          this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
          this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.saveToolStripMenuItem.Text = "Save ";
          // 
          // saveFileToolStripMenuItem
          // 
          this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
          this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
          this.saveFileToolStripMenuItem.Text = "Save file";
          // 
          // saveAllChangesToolStripMenuItem
          // 
          this.saveAllChangesToolStripMenuItem.Name = "saveAllChangesToolStripMenuItem";
          this.saveAllChangesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
          this.saveAllChangesToolStripMenuItem.Text = "Save All Changes";
          // 
          // restoreToolStripMenuItem
          // 
          this.restoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneFileToolStripMenuItem,
            this.allChangesToolStripMenuItem});
          this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
          this.restoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.restoreToolStripMenuItem.Text = "Restore";
          // 
          // oneFileToolStripMenuItem
          // 
          this.oneFileToolStripMenuItem.Name = "oneFileToolStripMenuItem";
          this.oneFileToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
          this.oneFileToolStripMenuItem.Text = "One file";
          // 
          // allChangesToolStripMenuItem
          // 
          this.allChangesToolStripMenuItem.Name = "allChangesToolStripMenuItem";
          this.allChangesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
          this.allChangesToolStripMenuItem.Text = "All Changes";
          // 
          // exitToolStripMenuItem
          // 
          this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
          this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.exitToolStripMenuItem.Text = "Exit";
          // 
          // toolsToolStripMenuItem
          // 
          this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
          this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 18);
          this.toolsToolStripMenuItem.Text = "Tools";
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.donateToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 18);
          this.helpToolStripMenuItem.Text = "Help";
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
          this.aboutToolStripMenuItem.Text = "About";
          // 
          // helpToolStripMenuItem1
          // 
          this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
          this.helpToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
          this.helpToolStripMenuItem1.Text = "Help";
          // 
          // donateToolStripMenuItem
          // 
          this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
          this.donateToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
          this.donateToolStripMenuItem.Text = "Donate";
          // 
          // statusStrip1
          // 
          this.statusStrip1.Location = new System.Drawing.Point(0, 519);
          this.statusStrip1.Name = "statusStrip1";
          this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
          this.statusStrip1.Size = new System.Drawing.Size(944, 22);
          this.statusStrip1.TabIndex = 1;
          this.statusStrip1.Text = "statusStrip1";
          // 
          // lstCenRep
          // 
          this.lstCenRep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
          this.lstCenRep.FullRowSelect = true;
          this.lstCenRep.GridLines = true;
          this.lstCenRep.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this.lstCenRep.Location = new System.Drawing.Point(12, 63);
          this.lstCenRep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
          this.lstCenRep.Name = "lstCenRep";
          this.lstCenRep.Size = new System.Drawing.Size(920, 366);
          this.lstCenRep.TabIndex = 2;
          this.lstCenRep.UseCompatibleStateImageBehavior = false;
          this.lstCenRep.View = System.Windows.Forms.View.Details;
          // 
          // columnHeader1
          // 
          this.columnHeader1.Text = "Fájlnév";
          this.columnHeader1.Width = 196;
          // 
          // columnHeader2
          // 
          this.columnHeader2.Text = "Méret";
          this.columnHeader2.Width = 101;
          // 
          // columnHeader3
          // 
          this.columnHeader3.Text = "Fájl dátum";
          this.columnHeader3.Width = 105;
          // 
          // columnHeader4
          // 
          this.columnHeader4.Text = "Módosítva";
          this.columnHeader4.Width = 81;
          // 
          // columnHeader5
          // 
          this.columnHeader5.Text = "Patch";
          // 
          // columnHeader6
          // 
          this.columnHeader6.Text = "Mentve";
          // 
          // columnHeader7
          // 
          this.columnHeader7.Text = "Leírás";
          this.columnHeader7.Width = 542;
          // 
          // dlgOpenRofs
          // 
          this.dlgOpenRofs.Description = "ROFS(x) directory";
          this.dlgOpenRofs.RootFolder = System.Environment.SpecialFolder.MyComputer;
          this.dlgOpenRofs.ShowNewFolderButton = false;
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // tableLayoutPanel1
          // 
          this.tableLayoutPanel1.ColumnCount = 6;
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 359F));
          this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
          this.tableLayoutPanel1.Controls.Add(this.cmbName, 1, 0);
          this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
          this.tableLayoutPanel1.Controls.Add(this.comboBox1, 3, 0);
          this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
          this.tableLayoutPanel1.Controls.Add(this.comboBox2, 5, 0);
          this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          this.tableLayoutPanel1.RowCount = 1;
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 29);
          this.tableLayoutPanel1.TabIndex = 3;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(3, 0);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(51, 17);
          this.label1.TabIndex = 0;
          this.label1.Text = "Phone :";
          // 
          // cmbName
          // 
          this.cmbName.FormattingEnabled = true;
          this.cmbName.Items.AddRange(new object[] {
            "Nokia",
            "Sony",
            "LG",
            "Samsung"});
          this.cmbName.Location = new System.Drawing.Point(63, 3);
          this.cmbName.Name = "cmbName";
          this.cmbName.Size = new System.Drawing.Size(121, 25);
          this.cmbName.TabIndex = 1;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(193, 0);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(53, 17);
          this.label2.TabIndex = 2;
          this.label2.Text = "Model :";
          // 
          // comboBox1
          // 
          this.comboBox1.FormattingEnabled = true;
          this.comboBox1.Location = new System.Drawing.Point(254, 3);
          this.comboBox1.Name = "comboBox1";
          this.comboBox1.Size = new System.Drawing.Size(121, 25);
          this.comboBox1.TabIndex = 3;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(383, 0);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(68, 17);
          this.label3.TabIndex = 4;
          this.label3.Text = "Firmware :";
          // 
          // comboBox2
          // 
          this.comboBox2.FormattingEnabled = true;
          this.comboBox2.Location = new System.Drawing.Point(457, 3);
          this.comboBox2.Name = "comboBox2";
          this.comboBox2.Size = new System.Drawing.Size(185, 25);
          this.comboBox2.TabIndex = 5;
          // 
          // frmMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(944, 541);
          this.Controls.Add(this.tableLayoutPanel1);
          this.Controls.Add(this.lstCenRep);
          this.Controls.Add(this.statusStrip1);
          this.Controls.Add(this.menuStrip1);
          this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.MainMenuStrip = this.menuStrip1;
          this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
          this.Name = "frmMain";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Project S60 Central Repository Editor";
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.tableLayoutPanel1.ResumeLayout(false);
          this.tableLayoutPanel1.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lstCenRep;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenRofs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;

    }
}

