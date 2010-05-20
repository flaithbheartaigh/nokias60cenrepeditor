namespace S60
{
    partial class frmNokia
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNokia));
          this.mnuMain = new System.Windows.Forms.MenuStrip();
          this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.rOFSKönyvtárMegnyitásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.műveletekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.kötegelPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.patchekVálasztásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.patchImportálásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.patchExportálásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuPlugins = new System.Windows.Forms.ToolStripMenuItem();
          this.dummyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.nyelvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.patcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.segítségToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.segítségToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.aProgramrólToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.dlgOpenDir = new System.Windows.Forms.FolderBrowserDialog();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.statusStrip1 = new System.Windows.Forms.StatusStrip();
          this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.tptDirectory = new System.Windows.Forms.ToolStripStatusLabel();
          this.tabControl1 = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.panel1 = new System.Windows.Forms.Panel();
          this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
          this.btnEditor = new System.Windows.Forms.Button();
          this.btRevoke = new System.Windows.Forms.Button();
          this.btnAplyPatch = new System.Windows.Forms.Button();
          this.btnMakePatch = new System.Windows.Forms.Button();
          this.cbChangeLog = new System.Windows.Forms.CheckBox();
          this.splitter1 = new System.Windows.Forms.Splitter();
          this.lstCenRep = new System.Windows.Forms.DataGridView();
          this.clUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.clDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.clChanged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
          this.mnuCenRep = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuFindUID = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuPluginEdit = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuTextEdit = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.drCenrepDir = new System.DirectoryServices.DirectorySearcher();
          this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
          this.fsWatcher = new System.IO.FileSystemWatcher();
          this.mnuMakeMIF = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuMain.SuspendLayout();
          this.statusStrip1.SuspendLayout();
          this.tabControl1.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tableLayoutPanel1.SuspendLayout();
          this.panel1.SuspendLayout();
          this.tableLayoutPanel2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.lstCenRep)).BeginInit();
          this.mnuCenRep.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
          this.SuspendLayout();
          // 
          // mnuMain
          // 
          resources.ApplyResources(this.mnuMain, "mnuMain");
          this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.műveletekToolStripMenuItem,
            this.beállításokToolStripMenuItem,
            this.segítségToolStripMenuItem});
          this.mnuMain.Name = "mnuMain";
          // 
          // fájlToolStripMenuItem
          // 
          this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rOFSKönyvtárMegnyitásaToolStripMenuItem,
            this.kilépésToolStripMenuItem});
          this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
          resources.ApplyResources(this.fájlToolStripMenuItem, "fájlToolStripMenuItem");
          // 
          // rOFSKönyvtárMegnyitásaToolStripMenuItem
          // 
          this.rOFSKönyvtárMegnyitásaToolStripMenuItem.Name = "rOFSKönyvtárMegnyitásaToolStripMenuItem";
          resources.ApplyResources(this.rOFSKönyvtárMegnyitásaToolStripMenuItem, "rOFSKönyvtárMegnyitásaToolStripMenuItem");
          this.rOFSKönyvtárMegnyitásaToolStripMenuItem.Click += new System.EventHandler(this.rOFSKönyvtárMegnyitásaToolStripMenuItem_Click);
          // 
          // kilépésToolStripMenuItem
          // 
          this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
          resources.ApplyResources(this.kilépésToolStripMenuItem, "kilépésToolStripMenuItem");
          this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
          // 
          // műveletekToolStripMenuItem
          // 
          this.műveletekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kötegelPatchToolStripMenuItem,
            this.patchekVálasztásaToolStripMenuItem,
            this.patchImportálásaToolStripMenuItem,
            this.patchExportálásaToolStripMenuItem,
            this.mnuPlugins,
            this.mnuMakeMIF});
          this.műveletekToolStripMenuItem.Name = "műveletekToolStripMenuItem";
          resources.ApplyResources(this.műveletekToolStripMenuItem, "műveletekToolStripMenuItem");
          // 
          // kötegelPatchToolStripMenuItem
          // 
          this.kötegelPatchToolStripMenuItem.Name = "kötegelPatchToolStripMenuItem";
          resources.ApplyResources(this.kötegelPatchToolStripMenuItem, "kötegelPatchToolStripMenuItem");
          // 
          // patchekVálasztásaToolStripMenuItem
          // 
          this.patchekVálasztásaToolStripMenuItem.Name = "patchekVálasztásaToolStripMenuItem";
          resources.ApplyResources(this.patchekVálasztásaToolStripMenuItem, "patchekVálasztásaToolStripMenuItem");
          // 
          // patchImportálásaToolStripMenuItem
          // 
          this.patchImportálásaToolStripMenuItem.Name = "patchImportálásaToolStripMenuItem";
          resources.ApplyResources(this.patchImportálásaToolStripMenuItem, "patchImportálásaToolStripMenuItem");
          // 
          // patchExportálásaToolStripMenuItem
          // 
          this.patchExportálásaToolStripMenuItem.Name = "patchExportálásaToolStripMenuItem";
          resources.ApplyResources(this.patchExportálásaToolStripMenuItem, "patchExportálásaToolStripMenuItem");
          // 
          // mnuPlugins
          // 
          this.mnuPlugins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem});
          this.mnuPlugins.Name = "mnuPlugins";
          resources.ApplyResources(this.mnuPlugins, "mnuPlugins");
          // 
          // dummyToolStripMenuItem
          // 
          this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
          resources.ApplyResources(this.dummyToolStripMenuItem, "dummyToolStripMenuItem");
          // 
          // beállításokToolStripMenuItem
          // 
          this.beállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nyelvToolStripMenuItem,
            this.patcToolStripMenuItem});
          this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
          resources.ApplyResources(this.beállításokToolStripMenuItem, "beállításokToolStripMenuItem");
          // 
          // nyelvToolStripMenuItem
          // 
          this.nyelvToolStripMenuItem.Name = "nyelvToolStripMenuItem";
          resources.ApplyResources(this.nyelvToolStripMenuItem, "nyelvToolStripMenuItem");
          // 
          // patcToolStripMenuItem
          // 
          this.patcToolStripMenuItem.Name = "patcToolStripMenuItem";
          resources.ApplyResources(this.patcToolStripMenuItem, "patcToolStripMenuItem");
          // 
          // segítségToolStripMenuItem
          // 
          this.segítségToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.segítségToolStripMenuItem1,
            this.aProgramrólToolStripMenuItem});
          this.segítségToolStripMenuItem.Name = "segítségToolStripMenuItem";
          resources.ApplyResources(this.segítségToolStripMenuItem, "segítségToolStripMenuItem");
          // 
          // segítségToolStripMenuItem1
          // 
          this.segítségToolStripMenuItem1.Name = "segítségToolStripMenuItem1";
          resources.ApplyResources(this.segítségToolStripMenuItem1, "segítségToolStripMenuItem1");
          // 
          // aProgramrólToolStripMenuItem
          // 
          this.aProgramrólToolStripMenuItem.Name = "aProgramrólToolStripMenuItem";
          resources.ApplyResources(this.aProgramrólToolStripMenuItem, "aProgramrólToolStripMenuItem");
          // 
          // dlgOpenDir
          // 
          this.dlgOpenDir.RootFolder = System.Environment.SpecialFolder.MyComputer;
          resources.ApplyResources(this.dlgOpenDir, "dlgOpenDir");
          this.dlgOpenDir.ShowNewFolderButton = false;
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // statusStrip1
          // 
          this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tptDirectory});
          resources.ApplyResources(this.statusStrip1, "statusStrip1");
          this.statusStrip1.Name = "statusStrip1";
          // 
          // toolStripStatusLabel1
          // 
          this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
          resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
          // 
          // tptDirectory
          // 
          resources.ApplyResources(this.tptDirectory, "tptDirectory");
          this.tptDirectory.Name = "tptDirectory";
          // 
          // tabControl1
          // 
          this.tabControl1.Controls.Add(this.tabPage1);
          this.tabControl1.Controls.Add(this.tabPage2);
          resources.ApplyResources(this.tabControl1, "tabControl1");
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedIndex = 0;
          // 
          // tabPage1
          // 
          this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
          this.tabPage1.Controls.Add(this.tableLayoutPanel1);
          resources.ApplyResources(this.tabPage1, "tabPage1");
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.UseVisualStyleBackColor = true;
          // 
          // tableLayoutPanel1
          // 
          resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
          this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
          this.tableLayoutPanel1.Controls.Add(this.lstCenRep, 0, 1);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          // 
          // panel1
          // 
          this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
          this.panel1.Controls.Add(this.tableLayoutPanel2);
          this.panel1.Controls.Add(this.cbChangeLog);
          this.panel1.Controls.Add(this.splitter1);
          resources.ApplyResources(this.panel1, "panel1");
          this.panel1.Name = "panel1";
          // 
          // tableLayoutPanel2
          // 
          resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
          this.tableLayoutPanel2.Controls.Add(this.btnEditor, 0, 0);
          this.tableLayoutPanel2.Controls.Add(this.btRevoke, 1, 0);
          this.tableLayoutPanel2.Controls.Add(this.btnAplyPatch, 0, 1);
          this.tableLayoutPanel2.Controls.Add(this.btnMakePatch, 1, 1);
          this.tableLayoutPanel2.Name = "tableLayoutPanel2";
          // 
          // btnEditor
          // 
          resources.ApplyResources(this.btnEditor, "btnEditor");
          this.btnEditor.Name = "btnEditor";
          this.btnEditor.UseVisualStyleBackColor = true;
          // 
          // btRevoke
          // 
          resources.ApplyResources(this.btRevoke, "btRevoke");
          this.btRevoke.Name = "btRevoke";
          this.btRevoke.UseVisualStyleBackColor = true;
          // 
          // btnAplyPatch
          // 
          resources.ApplyResources(this.btnAplyPatch, "btnAplyPatch");
          this.btnAplyPatch.Name = "btnAplyPatch";
          this.btnAplyPatch.UseVisualStyleBackColor = true;
          // 
          // btnMakePatch
          // 
          resources.ApplyResources(this.btnMakePatch, "btnMakePatch");
          this.btnMakePatch.Name = "btnMakePatch";
          this.btnMakePatch.UseVisualStyleBackColor = true;
          // 
          // cbChangeLog
          // 
          resources.ApplyResources(this.cbChangeLog, "cbChangeLog");
          this.cbChangeLog.Name = "cbChangeLog";
          this.cbChangeLog.UseVisualStyleBackColor = true;
          // 
          // splitter1
          // 
          resources.ApplyResources(this.splitter1, "splitter1");
          this.splitter1.Name = "splitter1";
          this.splitter1.TabStop = false;
          // 
          // lstCenRep
          // 
          this.lstCenRep.AllowUserToAddRows = false;
          this.lstCenRep.AllowUserToDeleteRows = false;
          this.lstCenRep.AllowUserToResizeRows = false;
          this.lstCenRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.lstCenRep.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
          this.lstCenRep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.lstCenRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.lstCenRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clUID,
            this.clDesc,
            this.clChanged});
          this.lstCenRep.ContextMenuStrip = this.mnuCenRep;
          this.lstCenRep.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
          resources.ApplyResources(this.lstCenRep, "lstCenRep");
          this.lstCenRep.Name = "lstCenRep";
          this.lstCenRep.ReadOnly = true;
          // 
          // clUID
          // 
          this.clUID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
          resources.ApplyResources(this.clUID, "clUID");
          this.clUID.Name = "clUID";
          this.clUID.ReadOnly = true;
          // 
          // clDesc
          // 
          resources.ApplyResources(this.clDesc, "clDesc");
          this.clDesc.Name = "clDesc";
          this.clDesc.ReadOnly = true;
          // 
          // clChanged
          // 
          this.clChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
          resources.ApplyResources(this.clChanged, "clChanged");
          this.clChanged.Name = "clChanged";
          this.clChanged.ReadOnly = true;
          this.clChanged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
          this.clChanged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
          // 
          // mnuCenRep
          // 
          resources.ApplyResources(this.mnuCenRep, "mnuCenRep");
          this.mnuCenRep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindUID,
            this.mnuPluginEdit,
            this.mnuTextEdit,
            this.toolStripMenuItem4});
          this.mnuCenRep.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
          this.mnuCenRep.Name = "mnuCenRep";
          this.mnuCenRep.Opening += new System.ComponentModel.CancelEventHandler(this.MNUCrInit);
          // 
          // mnuFindUID
          // 
          resources.ApplyResources(this.mnuFindUID, "mnuFindUID");
          this.mnuFindUID.Name = "mnuFindUID";
          this.mnuFindUID.Click += new System.EventHandler(this.FindUID);
          // 
          // mnuPluginEdit
          // 
          resources.ApplyResources(this.mnuPluginEdit, "mnuPluginEdit");
          this.mnuPluginEdit.Name = "mnuPluginEdit";
          this.mnuPluginEdit.Click += new System.EventHandler(this.mnuEditPlugin);
          // 
          // mnuTextEdit
          // 
          resources.ApplyResources(this.mnuTextEdit, "mnuTextEdit");
          this.mnuTextEdit.Name = "mnuTextEdit";
          this.mnuTextEdit.Click += new System.EventHandler(this.StdEdit);
          // 
          // toolStripMenuItem4
          // 
          resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
          this.toolStripMenuItem4.Name = "toolStripMenuItem4";
          this.toolStripMenuItem4.Click += new System.EventHandler(this.DoUndo);
          // 
          // tabPage2
          // 
          this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
          resources.ApplyResources(this.tabPage2, "tabPage2");
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.UseVisualStyleBackColor = true;
          // 
          // drCenrepDir
          // 
          this.drCenrepDir.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
          this.drCenrepDir.SearchScope = System.DirectoryServices.SearchScope.Base;
          this.drCenrepDir.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
          this.drCenrepDir.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
          // 
          // fsWatcher
          // 
          this.fsWatcher.EnableRaisingEvents = true;
          this.fsWatcher.Filter = "*.txt";
          this.fsWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
          this.fsWatcher.SynchronizingObject = this;
          // 
          // mnuMakeMIF
          // 
          this.mnuMakeMIF.Name = "mnuMakeMIF";
          resources.ApplyResources(this.mnuMakeMIF, "mnuMakeMIF");
          this.mnuMakeMIF.Click += new System.EventHandler(this.onMakeMIF);
          // 
          // frmNokia
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tabControl1);
          this.Controls.Add(this.statusStrip1);
          this.Controls.Add(this.mnuMain);
          this.MainMenuStrip = this.mnuMain;
          this.MaximizeBox = false;
          this.Name = "frmNokia";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClosingBefore);
          this.mnuMain.ResumeLayout(false);
          this.mnuMain.PerformLayout();
          this.statusStrip1.ResumeLayout(false);
          this.statusStrip1.PerformLayout();
          this.tabControl1.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.tableLayoutPanel1.ResumeLayout(false);
          this.panel1.ResumeLayout(false);
          this.panel1.PerformLayout();
          this.tableLayoutPanel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.lstCenRep)).EndInit();
          this.mnuCenRep.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOFSKönyvtárMegnyitásaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem műveletekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyelvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segítségToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segítségToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aProgramrólToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kötegelPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchekVálasztásaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchImportálásaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patchExportálásaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPlugins;
        private System.Windows.Forms.ToolStripMenuItem dummyToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tptDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnEditor;
        private System.Windows.Forms.Button btRevoke;
        private System.Windows.Forms.Button btnAplyPatch;
        private System.Windows.Forms.Button btnMakePatch;
        private System.Windows.Forms.CheckBox cbChangeLog;
        private System.Windows.Forms.Splitter splitter1;
        private System.DirectoryServices.DirectorySearcher drCenrepDir;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.IO.FileSystemWatcher fsWatcher;
        private System.Windows.Forms.DataGridView lstCenRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDesc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clChanged;
        private System.Windows.Forms.ContextMenuStrip mnuCenRep;
        private System.Windows.Forms.ToolStripMenuItem mnuFindUID;
        private System.Windows.Forms.ToolStripMenuItem mnuPluginEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuTextEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuMakeMIF;
    }
}

