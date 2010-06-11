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
      this.tpApplication = new System.Windows.Forms.TabPage();
      this.tabControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tpModder);
      this.tabControl1.Controls.Add(this.tpApplication);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(385, 225);
      this.tabControl1.TabIndex = 0;
      // 
      // tpModder
      // 
      this.tpModder.Location = new System.Drawing.Point(4, 22);
      this.tpModder.Name = "tpModder";
      this.tpModder.Padding = new System.Windows.Forms.Padding(3);
      this.tpModder.Size = new System.Drawing.Size(377, 199);
      this.tpModder.TabIndex = 0;
      this.tpModder.Text = "Modder";
      this.tpModder.UseVisualStyleBackColor = true;
      // 
      // tpApplication
      // 
      this.tpApplication.Location = new System.Drawing.Point(4, 22);
      this.tpApplication.Name = "tpApplication";
      this.tpApplication.Padding = new System.Windows.Forms.Padding(3);
      this.tpApplication.Size = new System.Drawing.Size(377, 199);
      this.tpApplication.TabIndex = 1;
      this.tpApplication.Text = "Application";
      this.tpApplication.UseVisualStyleBackColor = true;
      // 
      // frmSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(382, 266);
      this.Controls.Add(this.tabControl1);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Name = "frmSettings";
      this.Text = "CenRep Editor Settings";
      this.tabControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tpModder;
    private System.Windows.Forms.TabPage tpApplication;
  }
}