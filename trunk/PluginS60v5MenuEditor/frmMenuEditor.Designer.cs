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
      this.treMenu = new System.Windows.Forms.TreeView();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.SuspendLayout();
      // 
      // treMenu
      // 
      this.treMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.treMenu.Location = new System.Drawing.Point(3, 12);
      this.treMenu.Name = "treMenu";
      this.treMenu.Size = new System.Drawing.Size(453, 242);
      this.treMenu.TabIndex = 0;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point(0, 255);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(780, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // frmMenuEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(780, 277);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.treMenu);
      this.Name = "frmMenuEditor";
      this.Text = "frmMenuEditor";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView treMenu;
    private System.Windows.Forms.StatusStrip statusStrip1;
  }
}