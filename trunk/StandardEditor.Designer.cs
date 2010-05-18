namespace NokiaS60CenrepEditor
{
  partial class StandardEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StandardEditor));
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblFileName = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnPlugin = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnFind = new System.Windows.Forms.Button();
      this.btnReplace = new System.Windows.Forms.Button();
      this.btnReload = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.txtEditor = new System.Windows.Forms.TextBox();
      this.mnuTeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Controls.Add(this.lblFileName);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btnPlugin);
      this.panel1.Controls.Add(this.label1);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // lblFileName
      // 
      resources.ApplyResources(this.lblFileName, "lblFileName");
      this.lblFileName.Name = "lblFileName";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // btnPlugin
      // 
      resources.ApplyResources(this.btnPlugin, "btnPlugin");
      this.btnPlugin.Name = "btnPlugin";
      this.btnPlugin.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // tableLayoutPanel1
      // 
      resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
      this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnFind, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.btnReplace, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.btnReload, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 4);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      // 
      // btnSave
      // 
      resources.ApplyResources(this.btnSave, "btnSave");
      this.btnSave.Name = "btnSave";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnFind
      // 
      resources.ApplyResources(this.btnFind, "btnFind");
      this.btnFind.Name = "btnFind";
      this.btnFind.UseVisualStyleBackColor = true;
      // 
      // btnReplace
      // 
      resources.ApplyResources(this.btnReplace, "btnReplace");
      this.btnReplace.Name = "btnReplace";
      this.btnReplace.UseVisualStyleBackColor = true;
      // 
      // btnReload
      // 
      resources.ApplyResources(this.btnReload, "btnReload");
      this.btnReload.Name = "btnReload";
      this.btnReload.UseVisualStyleBackColor = true;
      // 
      // btnExit
      // 
      resources.ApplyResources(this.btnExit, "btnExit");
      this.btnExit.Name = "btnExit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.ExitStdEditor);
      // 
      // txtEditor
      // 
      this.txtEditor.AcceptsReturn = true;
      this.txtEditor.ContextMenuStrip = this.mnuTeMenu;
      this.txtEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
      resources.ApplyResources(this.txtEditor, "txtEditor");
      this.txtEditor.Name = "txtEditor";
      // 
      // mnuTeMenu
      // 
      this.mnuTeMenu.Name = "contextMenuStrip1";
      resources.ApplyResources(this.mnuTeMenu, "mnuTeMenu");
      // 
      // StandardEditor
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtEditor);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.panel1);
      this.Name = "StandardEditor";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox txtEditor;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.Button btnReplace;
    private System.Windows.Forms.Button btnReload;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.ContextMenuStrip mnuTeMenu;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnPlugin;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblFileName;
  }
}