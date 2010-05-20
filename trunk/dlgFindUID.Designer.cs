namespace S60
{
  partial class dlgFindUID
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFindUID));
      this.label1 = new System.Windows.Forms.Label();
      this.txtUID = new System.Windows.Forms.MaskedTextBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.btnFind = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // txtUID
      // 
      resources.ApplyResources(this.txtUID, "txtUID");
      this.txtUID.Name = "txtUID";
      // 
      // tableLayoutPanel1
      // 
      resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
      this.tableLayoutPanel1.Controls.Add(this.btnFind, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      // 
      // btnFind
      // 
      this.btnFind.DialogResult = System.Windows.Forms.DialogResult.OK;
      resources.ApplyResources(this.btnFind, "btnFind");
      this.btnFind.Name = "btnFind";
      this.btnFind.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // dlgFindUID
      // 
      this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.txtUID);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "dlgFindUID";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.MaskedTextBox txtUID;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Button btnCancel;
  }
}