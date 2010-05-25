namespace S60.Plugins.MenuEditor
{
  partial class frmMenuEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMenuEditor ) );
      this.treMenu = new System.Windows.Forms.TreeView();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.mnuEditorMain = new System.Windows.Forms.MenuStrip();
      this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.btnSet = new System.Windows.Forms.Button();
      this.mnuEditorMain.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // treMenu
      // 
      this.treMenu.Font = new System.Drawing.Font( "Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 238 ) ) );
      this.treMenu.Location = new System.Drawing.Point( 0, 52 );
      this.treMenu.Name = "treMenu";
      this.treMenu.Size = new System.Drawing.Size( 453, 357 );
      this.treMenu.TabIndex = 0;
      this.treMenu.Click += new System.EventHandler( this.procItemSelected );
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point( 0, 412 );
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size( 780, 22 );
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // mnuEditorMain
      // 
      this.mnuEditorMain.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 238 ) ) );
      this.mnuEditorMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem} );
      this.mnuEditorMain.Location = new System.Drawing.Point( 0, 0 );
      this.mnuEditorMain.Name = "mnuEditorMain";
      this.mnuEditorMain.Size = new System.Drawing.Size( 780, 24 );
      this.mnuEditorMain.TabIndex = 2;
      this.mnuEditorMain.Text = "menuStrip1";
      // 
      // fájlToolStripMenuItem
      // 
      this.fájlToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem} );
      this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
      this.fájlToolStripMenuItem.Size = new System.Drawing.Size( 37, 20 );
      this.fájlToolStripMenuItem.Text = "File";
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size( 104, 22 );
      this.saveToolStripMenuItem.Text = "Save";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size( 104, 22 );
      this.exitToolStripMenuItem.Text = "Exit";
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size( 46, 20 );
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem} );
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size( 43, 20 );
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // helpToolStripMenuItem1
      // 
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new System.Drawing.Size( 113, 22 );
      this.helpToolStripMenuItem1.Text = "Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size( 113, 22 );
      this.aboutToolStripMenuItem.Text = "About";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1} );
      this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size( 780, 25 );
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripButton1
      // 
      this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = ( ( System.Drawing.Image ) ( resources.GetObject( "toolStripButton1.Image" ) ) );
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButton1.Text = "toolStripButton1";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
      this.tableLayoutPanel1.Controls.Add( this.tableLayoutPanel2, 0, 1 );
      this.tableLayoutPanel1.Controls.Add( this.groupBox1, 0, 0 );
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 459, 52 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 61.90476F ) );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 38.09524F ) );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 321, 357 );
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.Controls.Add( this.button1, 0, 0 );
      this.tableLayoutPanel2.Controls.Add( this.button2, 1, 0 );
      this.tableLayoutPanel2.Controls.Add( this.button3, 0, 1 );
      this.tableLayoutPanel2.Controls.Add( this.button4, 1, 1 );
      this.tableLayoutPanel2.Controls.Add( this.button5, 0, 2 );
      this.tableLayoutPanel2.Controls.Add( this.button6, 1, 2 );
      this.tableLayoutPanel2.Location = new System.Drawing.Point( 3, 224 );
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 3;
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 33.33333F ) );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 33.33333F ) );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 33.33333F ) );
      this.tableLayoutPanel2.Size = new System.Drawing.Size( 315, 130 );
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point( 3, 3 );
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size( 145, 37 );
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point( 160, 3 );
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size( 152, 37 );
      this.button2.TabIndex = 1;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point( 3, 46 );
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size( 151, 36 );
      this.button3.TabIndex = 2;
      this.button3.Text = "button3";
      this.button3.UseVisualStyleBackColor = true;
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point( 160, 46 );
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size( 152, 37 );
      this.button4.TabIndex = 3;
      this.button4.Text = "button4";
      this.button4.UseVisualStyleBackColor = true;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point( 3, 89 );
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size( 151, 38 );
      this.button5.TabIndex = 4;
      this.button5.Text = "button5";
      this.button5.UseVisualStyleBackColor = true;
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point( 160, 89 );
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size( 152, 38 );
      this.button6.TabIndex = 5;
      this.button6.Text = "button6";
      this.button6.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add( this.btnSet );
      this.groupBox1.Controls.Add( this.textBox1 );
      this.groupBox1.Controls.Add( this.checkedListBox1 );
      this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size( 315, 215 );
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Attribútumok :";
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new System.Drawing.Point( 6, 21 );
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size( 303, 157 );
      this.checkedListBox1.TabIndex = 0;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point( 6, 187 );
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size( 210, 22 );
      this.textBox1.TabIndex = 1;
      // 
      // btnSet
      // 
      this.btnSet.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 238 ) ) );
      this.btnSet.Location = new System.Drawing.Point( 231, 187 );
      this.btnSet.Name = "btnSet";
      this.btnSet.Size = new System.Drawing.Size( 75, 23 );
      this.btnSet.TabIndex = 2;
      this.btnSet.Text = "Set";
      this.btnSet.UseVisualStyleBackColor = true;
      // 
      // frmMenuEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 780, 434 );
      this.Controls.Add( this.tableLayoutPanel1 );
      this.Controls.Add( this.toolStrip1 );
      this.Controls.Add( this.statusStrip1 );
      this.Controls.Add( this.mnuEditorMain );
      this.Controls.Add( this.treMenu );
      this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 238 ) ) );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ( ( System.Drawing.Icon ) ( resources.GetObject( "$this.Icon" ) ) );
      this.MainMenuStrip = this.mnuEditorMain;
      this.MaximizeBox = false;
      this.Name = "frmMenuEditor";
      this.Text = "Nokia 5800XM Menu Editor by JAndras";
      this.mnuEditorMain.ResumeLayout( false );
      this.mnuEditorMain.PerformLayout();
      this.toolStrip1.ResumeLayout( false );
      this.toolStrip1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel2.ResumeLayout( false );
      this.groupBox1.ResumeLayout( false );
      this.groupBox1.PerformLayout();
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView treMenu;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.MenuStrip mnuEditorMain;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.Button btnSet;
    private System.Windows.Forms.TextBox textBox1;
  }
}