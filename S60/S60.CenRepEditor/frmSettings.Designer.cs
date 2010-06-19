namespace S60.CenRepEditor
{
  partial class frmSettings
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tpModder = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.txtModderName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtModderEmail = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtModderHomePage = new System.Windows.Forms.TextBox();
      this.tpApplication = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
      this.checkBox4 = new System.Windows.Forms.CheckBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
      this.chkAutoBackup = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.btnApply = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.tabControl1.SuspendLayout();
      this.tpModder.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tpApplication.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tableLayoutPanel5.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add( this.tpModder );
      this.tabControl1.Controls.Add( this.tpApplication );
      this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size( 385, 225 );
      this.tabControl1.TabIndex = 0;
      // 
      // tpModder
      // 
      this.tpModder.Controls.Add( this.tableLayoutPanel1 );
      this.tpModder.Location = new System.Drawing.Point( 4, 22 );
      this.tpModder.Name = "tpModder";
      this.tpModder.Padding = new System.Windows.Forms.Padding( 3 );
      this.tpModder.Size = new System.Drawing.Size( 377, 199 );
      this.tpModder.TabIndex = 0;
      this.tpModder.Text = "Modder";
      this.tpModder.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 27.00535F ) );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 72.99465F ) );
      this.tableLayoutPanel1.Controls.Add( this.label1, 0, 0 );
      this.tableLayoutPanel1.Controls.Add( this.txtModderName, 1, 0 );
      this.tableLayoutPanel1.Controls.Add( this.label2, 0, 1 );
      this.tableLayoutPanel1.Controls.Add( this.txtModderEmail, 1, 1 );
      this.tableLayoutPanel1.Controls.Add( this.label3, 0, 2 );
      this.tableLayoutPanel1.Controls.Add( this.txtModderHomePage, 1, 2 );
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 17 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 374, 182 );
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point( 3, 0 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 86, 13 );
      this.label1.TabIndex = 0;
      this.label1.Text = "Modder Name :";
      // 
      // txtModderName
      // 
      this.txtModderName.Location = new System.Drawing.Point( 104, 3 );
      this.txtModderName.Name = "txtModderName";
      this.txtModderName.Size = new System.Drawing.Size( 267, 22 );
      this.txtModderName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point( 3, 28 );
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size( 38, 13 );
      this.label2.TabIndex = 2;
      this.label2.Text = "EMail:";
      // 
      // txtModderEmail
      // 
      this.txtModderEmail.Location = new System.Drawing.Point( 104, 31 );
      this.txtModderEmail.Name = "txtModderEmail";
      this.txtModderEmail.Size = new System.Drawing.Size( 267, 22 );
      this.txtModderEmail.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point( 3, 56 );
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size( 69, 13 );
      this.label3.TabIndex = 4;
      this.label3.Text = "Homepage :";
      // 
      // txtModderHomePage
      // 
      this.txtModderHomePage.Location = new System.Drawing.Point( 104, 59 );
      this.txtModderHomePage.Name = "txtModderHomePage";
      this.txtModderHomePage.Size = new System.Drawing.Size( 267, 22 );
      this.txtModderHomePage.TabIndex = 5;
      // 
      // tpApplication
      // 
      this.tpApplication.Controls.Add( this.tableLayoutPanel2 );
      this.tpApplication.Location = new System.Drawing.Point( 4, 22 );
      this.tpApplication.Name = "tpApplication";
      this.tpApplication.Padding = new System.Windows.Forms.Padding( 3 );
      this.tpApplication.Size = new System.Drawing.Size( 377, 199 );
      this.tpApplication.TabIndex = 1;
      this.tpApplication.Text = "Application";
      this.tpApplication.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.Controls.Add( this.groupBox1, 0, 0 );
      this.tableLayoutPanel2.Controls.Add( this.groupBox2, 1, 0 );
      this.tableLayoutPanel2.Location = new System.Drawing.Point( 0, 19 );
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 180F ) );
      this.tableLayoutPanel2.Size = new System.Drawing.Size( 377, 180 );
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add( this.tableLayoutPanel4 );
      this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size( 182, 171 );
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Editing && Patching";
      // 
      // tableLayoutPanel4
      // 
      this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel4.ColumnCount = 1;
      this.tableLayoutPanel4.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel4.Controls.Add( this.checkBox4, 0, 0 );
      this.tableLayoutPanel4.Location = new System.Drawing.Point( 6, 21 );
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 5;
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
      this.tableLayoutPanel4.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
      this.tableLayoutPanel4.Size = new System.Drawing.Size( 170, 144 );
      this.tableLayoutPanel4.TabIndex = 0;
      // 
      // checkBox4
      // 
      this.checkBox4.AutoSize = true;
      this.checkBox4.Location = new System.Drawing.Point( 4, 4 );
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new System.Drawing.Size( 162, 17 );
      this.checkBox4.TabIndex = 0;
      this.checkBox4.Text = "Auto apply modder settings";
      this.checkBox4.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add( this.tableLayoutPanel5 );
      this.groupBox2.Location = new System.Drawing.Point( 191, 3 );
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size( 183, 171 );
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Other";
      // 
      // tableLayoutPanel5
      // 
      this.tableLayoutPanel5.AllowDrop = true;
      this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel5.ColumnCount = 1;
      this.tableLayoutPanel5.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel5.Controls.Add( this.chkAutoBackup, 0, 0 );
      this.tableLayoutPanel5.Controls.Add( this.checkBox2, 0, 2 );
      this.tableLayoutPanel5.Controls.Add( this.checkBox1, 0, 3 );
      this.tableLayoutPanel5.Controls.Add( this.checkBox3, 0, 4 );
      this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.tableLayoutPanel5.Location = new System.Drawing.Point( 3, 18 );
      this.tableLayoutPanel5.Name = "tableLayoutPanel5";
      this.tableLayoutPanel5.RowCount = 5;
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel5.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel5.Size = new System.Drawing.Size( 177, 144 );
      this.tableLayoutPanel5.TabIndex = 0;
      // 
      // chkAutoBackup
      // 
      this.chkAutoBackup.AutoSize = true;
      this.chkAutoBackup.Checked = true;
      this.chkAutoBackup.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAutoBackup.Location = new System.Drawing.Point( 3, 3 );
      this.chkAutoBackup.Name = "chkAutoBackup";
      this.chkAutoBackup.Size = new System.Drawing.Size( 92, 17 );
      this.chkAutoBackup.TabIndex = 0;
      this.chkAutoBackup.Text = "Auto backup";
      this.chkAutoBackup.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point( 3, 26 );
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size( 80, 17 );
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point( 3, 49 );
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size( 80, 17 );
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point( 3, 72 );
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size( 80, 17 );
      this.checkBox3.TabIndex = 3;
      this.checkBox3.Text = "checkBox3";
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel3.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel3.Controls.Add( this.btnApply, 0, 0 );
      this.tableLayoutPanel3.Controls.Add( this.btnCancel, 1, 0 );
      this.tableLayoutPanel3.Location = new System.Drawing.Point( 4, 227 );
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel3.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 37F ) );
      this.tableLayoutPanel3.Size = new System.Drawing.Size( 374, 37 );
      this.tableLayoutPanel3.TabIndex = 1;
      // 
      // btnApply
      // 
      this.btnApply.Location = new System.Drawing.Point( 3, 3 );
      this.btnApply.Name = "btnApply";
      this.btnApply.Size = new System.Drawing.Size( 181, 31 );
      this.btnApply.TabIndex = 0;
      this.btnApply.Text = "&Apply && Save";
      this.btnApply.UseVisualStyleBackColor = true;
      this.btnApply.Click += new System.EventHandler( this.SaveSettings );
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point( 190, 3 );
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size( 181, 31 );
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // frmSettings
      // 
      this.AcceptButton = this.btnApply;
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size( 382, 266 );
      this.Controls.Add( this.tableLayoutPanel3 );
      this.Controls.Add( this.tabControl1 );
      this.Font = new System.Drawing.Font( "Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( ( byte ) ( 238 ) ) );
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.HelpButton = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmSettings";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "CenRep Editor Settings";
      this.Load += new System.EventHandler( this.ObjectLoader );
      this.tabControl1.ResumeLayout( false );
      this.tpModder.ResumeLayout( false );
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel1.PerformLayout();
      this.tpApplication.ResumeLayout( false );
      this.tableLayoutPanel2.ResumeLayout( false );
      this.groupBox1.ResumeLayout( false );
      this.tableLayoutPanel4.ResumeLayout( false );
      this.tableLayoutPanel4.PerformLayout();
      this.groupBox2.ResumeLayout( false );
      this.tableLayoutPanel5.ResumeLayout( false );
      this.tableLayoutPanel5.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tpModder;
    private System.Windows.Forms.TabPage tpApplication;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtModderName;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtModderEmail;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtModderHomePage;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button btnApply;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    private System.Windows.Forms.CheckBox chkAutoBackup;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
  }
}