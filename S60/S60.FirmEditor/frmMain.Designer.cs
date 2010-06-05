namespace S60.FirmEditor
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
          this.mnuMain = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.openFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.fromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this.closeFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
          this.exitFEdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.firmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.pluginManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.librariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.pluginSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.fileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.contentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutProjectS60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutFEdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.statusStrip = new System.Windows.Forms.StatusStrip();
          this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
          this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
          this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
          this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
          this.folderView = new System.Windows.Forms.TreeView();
          this.contextMenuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
          this.folderInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.listviewFileList = new System.Windows.Forms.ListView();
          this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.Flag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
          this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.searchBox = new System.Windows.Forms.ComboBox();
          this.searchButton = new System.Windows.Forms.Button();
          this.mnuMain.SuspendLayout();
          this.statusStrip.SuspendLayout();
          this.contextMenuStripTreeView.SuspendLayout();
          this.contextMenuStripListView.SuspendLayout();
          this.SuspendLayout();
          // 
          // mnuMain
          // 
          this.mnuMain.BackColor = System.Drawing.Color.LightSteelBlue;
          this.mnuMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.firmwareToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
          this.mnuMain.Location = new System.Drawing.Point(0, 0);
          this.mnuMain.Name = "mnuMain";
          this.mnuMain.Size = new System.Drawing.Size(842, 24);
          this.mnuMain.TabIndex = 0;
          this.mnuMain.Text = "menuStrip";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFirmwareToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeFirmwareToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitFEdToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
          this.fileToolStripMenuItem.Text = "File";
          // 
          // openFirmwareToolStripMenuItem
          // 
          this.openFirmwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.fromFolderToolStripMenuItem});
          this.openFirmwareToolStripMenuItem.Name = "openFirmwareToolStripMenuItem";
          this.openFirmwareToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.openFirmwareToolStripMenuItem.Text = "Open firmware";
          // 
          // fromFileToolStripMenuItem
          // 
          this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
          this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
          this.fromFileToolStripMenuItem.Text = "From file";
          // 
          // fromFolderToolStripMenuItem
          // 
          this.fromFolderToolStripMenuItem.Name = "fromFolderToolStripMenuItem";
          this.fromFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
          this.fromFolderToolStripMenuItem.Text = "From folder";
          this.fromFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenROFSFolder);
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          this.toolStripSeparator4.Size = new System.Drawing.Size(158, 6);
          // 
          // closeFirmwareToolStripMenuItem
          // 
          this.closeFirmwareToolStripMenuItem.Name = "closeFirmwareToolStripMenuItem";
          this.closeFirmwareToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.closeFirmwareToolStripMenuItem.Text = "Close firmware";
          // 
          // toolStripSeparator5
          // 
          this.toolStripSeparator5.Name = "toolStripSeparator5";
          this.toolStripSeparator5.Size = new System.Drawing.Size(158, 6);
          // 
          // exitFEdToolStripMenuItem
          // 
          this.exitFEdToolStripMenuItem.Name = "exitFEdToolStripMenuItem";
          this.exitFEdToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.exitFEdToolStripMenuItem.Text = "Exit FEd";
          this.exitFEdToolStripMenuItem.Click += new System.EventHandler(this.exitFEdToolStripMenuItem_Click);
          // 
          // firmwareToolStripMenuItem
          // 
          this.firmwareToolStripMenuItem.Name = "firmwareToolStripMenuItem";
          this.firmwareToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
          this.firmwareToolStripMenuItem.Text = "Firmware";
          // 
          // pluginsToolStripMenuItem
          // 
          this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.pluginManagerToolStripMenuItem});
          this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
          this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
          this.pluginsToolStripMenuItem.Text = "Plugins";
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.BackColor = System.Drawing.Color.CornflowerBlue;
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
          // 
          // pluginManagerToolStripMenuItem
          // 
          this.pluginManagerToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
          this.pluginManagerToolStripMenuItem.Name = "pluginManagerToolStripMenuItem";
          this.pluginManagerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
          this.pluginManagerToolStripMenuItem.Text = "Plugin Manager";
          this.pluginManagerToolStripMenuItem.Click += new System.EventHandler(this.pluginManagerToolStripMenuItem_Click);
          // 
          // settingsToolStripMenuItem
          // 
          this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.librariesToolStripMenuItem,
            this.pluginSettingsToolStripMenuItem,
            this.fileSettingsToolStripMenuItem});
          this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
          this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
          this.settingsToolStripMenuItem.Text = "Settings";
          // 
          // settingsToolStripMenuItem1
          // 
          this.settingsToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
          this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
          this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
          this.settingsToolStripMenuItem1.Text = "Settings";
          // 
          // librariesToolStripMenuItem
          // 
          this.librariesToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
          this.librariesToolStripMenuItem.Name = "librariesToolStripMenuItem";
          this.librariesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.librariesToolStripMenuItem.Text = "Libraries";
          // 
          // pluginSettingsToolStripMenuItem
          // 
          this.pluginSettingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
          this.pluginSettingsToolStripMenuItem.Name = "pluginSettingsToolStripMenuItem";
          this.pluginSettingsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.pluginSettingsToolStripMenuItem.Text = "Plugin Settings";
          // 
          // fileSettingsToolStripMenuItem
          // 
          this.fileSettingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
          this.fileSettingsToolStripMenuItem.Name = "fileSettingsToolStripMenuItem";
          this.fileSettingsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
          this.fileSettingsToolStripMenuItem.Text = "File Settings";
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutUsToolStripMenuItem,
            this.aboutProjectS60ToolStripMenuItem,
            this.aboutFEdToolStripMenuItem,
            this.toolStripSeparator3,
            this.updateToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
          this.helpToolStripMenuItem.Text = "Help";
          // 
          // contentToolStripMenuItem
          // 
          this.contentToolStripMenuItem.Name = "contentToolStripMenuItem";
          this.contentToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
          this.contentToolStripMenuItem.Text = "Content";
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
          // 
          // aboutUsToolStripMenuItem
          // 
          this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
          this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
          this.aboutUsToolStripMenuItem.Text = "About us...";
          // 
          // aboutProjectS60ToolStripMenuItem
          // 
          this.aboutProjectS60ToolStripMenuItem.Name = "aboutProjectS60ToolStripMenuItem";
          this.aboutProjectS60ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
          this.aboutProjectS60ToolStripMenuItem.Text = "About Project S60";
          // 
          // aboutFEdToolStripMenuItem
          // 
          this.aboutFEdToolStripMenuItem.Name = "aboutFEdToolStripMenuItem";
          this.aboutFEdToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
          this.aboutFEdToolStripMenuItem.Text = "About FEd";
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
          // 
          // updateToolStripMenuItem
          // 
          this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
          this.updateToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
          this.updateToolStripMenuItem.Text = "Update";
          // 
          // statusStrip
          // 
          this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1});
          this.statusStrip.Location = new System.Drawing.Point(0, 542);
          this.statusStrip.Name = "statusStrip";
          this.statusStrip.Size = new System.Drawing.Size(842, 24);
          this.statusStrip.TabIndex = 2;
          this.statusStrip.Text = "statusStrip1";
          // 
          // toolStripProgressBar1
          // 
          this.toolStripProgressBar1.Name = "toolStripProgressBar1";
          this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 18);
          this.toolStripProgressBar1.Step = 1;
          this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
          // 
          // toolStripStatusLabel2
          // 
          this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
          this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Black;
          this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
          this.toolStripStatusLabel2.Size = new System.Drawing.Size(225, 19);
          this.toolStripStatusLabel2.Spring = true;
          this.toolStripStatusLabel2.Text = "File Size:";
          this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // toolStripStatusLabel3
          // 
          this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                      | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
          this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Red;
          this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
          this.toolStripStatusLabel3.Size = new System.Drawing.Size(225, 19);
          this.toolStripStatusLabel3.Spring = true;
          this.toolStripStatusLabel3.Text = "Max Size:";
          this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // toolStripStatusLabel1
          // 
          this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
          this.toolStripStatusLabel1.Size = new System.Drawing.Size(225, 19);
          this.toolStripStatusLabel1.Spring = true;
          this.toolStripStatusLabel1.Text = "By jandras and fonix232";
          this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // folderView
          // 
          this.folderView.ContextMenuStrip = this.contextMenuStripTreeView;
          this.folderView.Location = new System.Drawing.Point(13, 57);
          this.folderView.Name = "folderView";
          this.folderView.Size = new System.Drawing.Size(243, 478);
          this.folderView.TabIndex = 3;
          this.folderView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DirectorySelect);
          // 
          // contextMenuStripTreeView
          // 
          this.contextMenuStripTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFolderToolStripMenuItem,
            this.toolStripSeparator7,
            this.folderInfoToolStripMenuItem});
          this.contextMenuStripTreeView.Name = "contextMenuStripTreeView";
          this.contextMenuStripTreeView.Size = new System.Drawing.Size(142, 54);
          // 
          // deleteFolderToolStripMenuItem
          // 
          this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
          this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
          this.deleteFolderToolStripMenuItem.Text = "Delete folder";
          // 
          // toolStripSeparator7
          // 
          this.toolStripSeparator7.Name = "toolStripSeparator7";
          this.toolStripSeparator7.Size = new System.Drawing.Size(138, 6);
          // 
          // folderInfoToolStripMenuItem
          // 
          this.folderInfoToolStripMenuItem.Name = "folderInfoToolStripMenuItem";
          this.folderInfoToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
          this.folderInfoToolStripMenuItem.Text = "Folder info";
          // 
          // listviewFileList
          // 
          this.listviewFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.fileSize,
            this.Date,
            this.Type,
            this.Flag});
          this.listviewFileList.ContextMenuStrip = this.contextMenuStripListView;
          this.listviewFileList.FullRowSelect = true;
          this.listviewFileList.GridLines = true;
          this.listviewFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
          this.listviewFileList.LabelEdit = true;
          this.listviewFileList.LabelWrap = false;
          this.listviewFileList.Location = new System.Drawing.Point(261, 27);
          this.listviewFileList.Name = "listviewFileList";
          this.listviewFileList.ShowItemToolTips = true;
          this.listviewFileList.Size = new System.Drawing.Size(572, 508);
          this.listviewFileList.TabIndex = 4;
          this.listviewFileList.UseCompatibleStateImageBehavior = false;
          this.listviewFileList.View = System.Windows.Forms.View.Details;
          // 
          // fileName
          // 
          this.fileName.Text = "Name";
          this.fileName.Width = 200;
          // 
          // fileSize
          // 
          this.fileSize.Text = "Size";
          this.fileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          this.fileSize.Width = 100;
          // 
          // Date
          // 
          this.Date.Text = "Date";
          this.Date.Width = 147;
          // 
          // Type
          // 
          this.Type.Text = "Type";
          this.Type.Width = 61;
          // 
          // Flag
          // 
          this.Flag.Text = "Flag";
          // 
          // contextMenuStripListView
          // 
          this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.toolStripSeparator6,
            this.deleteFileToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.propertiesToolStripMenuItem});
          this.contextMenuStripListView.Name = "contextMenuStripListView";
          this.contextMenuStripListView.Size = new System.Drawing.Size(132, 98);
          // 
          // openFileToolStripMenuItem
          // 
          this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
          this.openFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
          this.openFileToolStripMenuItem.Text = "Open file...";
          // 
          // toolStripSeparator6
          // 
          this.toolStripSeparator6.Name = "toolStripSeparator6";
          this.toolStripSeparator6.Size = new System.Drawing.Size(128, 6);
          // 
          // deleteFileToolStripMenuItem
          // 
          this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
          this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
          this.deleteFileToolStripMenuItem.Text = "Delete";
          // 
          // infoToolStripMenuItem
          // 
          this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
          this.infoToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
          this.infoToolStripMenuItem.Text = "Info";
          // 
          // propertiesToolStripMenuItem
          // 
          this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
          this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
          this.propertiesToolStripMenuItem.Text = "Properties";
          // 
          // searchBox
          // 
          this.searchBox.FormattingEnabled = true;
          this.searchBox.Location = new System.Drawing.Point(13, 30);
          this.searchBox.Name = "searchBox";
          this.searchBox.Size = new System.Drawing.Size(213, 21);
          this.searchBox.TabIndex = 5;
          this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
          this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
          // 
          // searchButton
          // 
          this.searchButton.Location = new System.Drawing.Point(231, 27);
          this.searchButton.Name = "searchButton";
          this.searchButton.Size = new System.Drawing.Size(24, 24);
          this.searchButton.TabIndex = 6;
          this.searchButton.Text = "C";
          this.searchButton.UseVisualStyleBackColor = true;
          this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
          // 
          // frmMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(842, 566);
          this.Controls.Add(this.searchButton);
          this.Controls.Add(this.searchBox);
          this.Controls.Add(this.folderView);
          this.Controls.Add(this.listviewFileList);
          this.Controls.Add(this.statusStrip);
          this.Controls.Add(this.mnuMain);
          this.MainMenuStrip = this.mnuMain;
          this.MaximizeBox = false;
          this.MaximumSize = new System.Drawing.Size(850, 600);
          this.MinimumSize = new System.Drawing.Size(850, 600);
          this.Name = "frmMain";
          this.Text = "Project S60 FEd";
          this.mnuMain.ResumeLayout(false);
          this.mnuMain.PerformLayout();
          this.statusStrip.ResumeLayout(false);
          this.statusStrip.PerformLayout();
          this.contextMenuStripTreeView.ResumeLayout(false);
          this.contextMenuStripListView.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView folderView;
        private System.Windows.Forms.ListView listviewFileList;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Flag;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem librariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSettingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pluginManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFirmwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem closeFirmwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem exitFEdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProjectS60ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutFEdToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeView;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem folderInfoToolStripMenuItem;

    }
}

