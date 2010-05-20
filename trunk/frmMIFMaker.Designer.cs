namespace S60
{
  partial class frmMIFMaker
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
      this.dlgSaveMIF = new System.Windows.Forms.SaveFileDialog();
      this.lstPicFiles = new System.Windows.Forms.ListBox();
      this.dlgOpenSVG = new System.Windows.Forms.OpenFileDialog();
      this.btnAddPicture = new System.Windows.Forms.Button();
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnCreateMif = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblNumIcons = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblCsomag = new System.Windows.Forms.ToolStripStatusLabel();
      this.pbMaking = new System.Windows.Forms.ToolStripProgressBar();
      this.chkSplitPics = new System.Windows.Forms.CheckBox();
      this.dlgSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // dlgSaveMIF
      // 
      this.dlgSaveMIF.DefaultExt = "mif";
      // 
      // lstPicFiles
      // 
      this.lstPicFiles.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lstPicFiles.FormattingEnabled = true;
      this.lstPicFiles.ItemHeight = 16;
      this.lstPicFiles.Location = new System.Drawing.Point(0, 37);
      this.lstPicFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lstPicFiles.Name = "lstPicFiles";
      this.lstPicFiles.ScrollAlwaysVisible = true;
      this.lstPicFiles.Size = new System.Drawing.Size(308, 276);
      this.lstPicFiles.TabIndex = 0;
      // 
      // dlgOpenSVG
      // 
      this.dlgOpenSVG.DefaultExt = "SVG grafika (*.svg)|*.svg|";
      // 
      // btnAddPicture
      // 
      this.btnAddPicture.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnAddPicture.Location = new System.Drawing.Point(316, 167);
      this.btnAddPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnAddPicture.Name = "btnAddPicture";
      this.btnAddPicture.Size = new System.Drawing.Size(218, 28);
      this.btnAddPicture.TabIndex = 3;
      this.btnAddPicture.Text = "Hozzáadás";
      this.btnAddPicture.UseVisualStyleBackColor = true;
      this.btnAddPicture.Click += new System.EventHandler(this.OnAppendButton);
      // 
      // btnDelete
      // 
      this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnDelete.Location = new System.Drawing.Point(316, 203);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(218, 28);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "Törlés";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.OnDeleteButton);
      // 
      // btnCreateMif
      // 
      this.btnCreateMif.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnCreateMif.Location = new System.Drawing.Point(316, 239);
      this.btnCreateMif.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnCreateMif.Name = "btnCreateMif";
      this.btnCreateMif.Size = new System.Drawing.Size(218, 28);
      this.btnCreateMif.TabIndex = 5;
      this.btnCreateMif.Text = "Mentés";
      this.btnCreateMif.UseVisualStyleBackColor = true;
      this.btnCreateMif.Click += new System.EventHandler(this.OnCreateButton);
      // 
      // btnExit
      // 
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnExit.Location = new System.Drawing.Point(316, 274);
      this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(218, 28);
      this.btnExit.TabIndex = 6;
      this.btnExit.Text = "Kilépés";
      this.btnExit.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.label2.Location = new System.Drawing.Point(-3, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(181, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "Csomagolásra előkészítve :";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblNumIcons,
            this.lblCsomag,
            this.pbMaking});
      this.statusStrip1.Location = new System.Drawing.Point(0, 325);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
      this.statusStrip1.Size = new System.Drawing.Size(548, 22);
      this.statusStrip1.TabIndex = 8;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
      this.toolStripStatusLabel1.Text = "Ikonok száma :";
      // 
      // lblNumIcons
      // 
      this.lblNumIcons.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblNumIcons.Name = "lblNumIcons";
      this.lblNumIcons.Size = new System.Drawing.Size(13, 17);
      this.lblNumIcons.Text = "0";
      // 
      // lblCsomag
      // 
      this.lblCsomag.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblCsomag.Name = "lblCsomag";
      this.lblCsomag.Size = new System.Drawing.Size(72, 17);
      this.lblCsomag.Text = "Csomagolás :";
      this.lblCsomag.Visible = false;
      // 
      // pbMaking
      // 
      this.pbMaking.AutoSize = false;
      this.pbMaking.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.pbMaking.Name = "pbMaking";
      this.pbMaking.Size = new System.Drawing.Size(315, 16);
      this.pbMaking.Visible = false;
      // 
      // chkSplitPics
      // 
      this.chkSplitPics.AutoSize = true;
      this.chkSplitPics.Checked = true;
      this.chkSplitPics.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSplitPics.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.chkSplitPics.Location = new System.Drawing.Point(325, 37);
      this.chkSplitPics.Name = "chkSplitPics";
      this.chkSplitPics.Size = new System.Drawing.Size(141, 20);
      this.chkSplitPics.TabIndex = 9;
      this.chkSplitPics.Text = "Külön konvertálás";
      this.chkSplitPics.UseVisualStyleBackColor = true;
      // 
      // frmMIFMaker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.CancelButton = this.btnExit;
      this.ClientSize = new System.Drawing.Size(548, 347);
      this.Controls.Add(this.chkSplitPics);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.btnCreateMif);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnAddPicture);
      this.Controls.Add(this.lstPicFiles);
      this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frmMIFMaker";
      this.Text = "MIF Csomagolás";
      this.TopMost = true;
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SaveFileDialog dlgSaveMIF;
    private System.Windows.Forms.ListBox lstPicFiles;
    private System.Windows.Forms.OpenFileDialog dlgOpenSVG;
    private System.Windows.Forms.Button btnAddPicture;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnCreateMif;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel lblNumIcons;
    private System.Windows.Forms.ToolStripStatusLabel lblCsomag;
    private System.Windows.Forms.ToolStripProgressBar pbMaking;
    private System.Windows.Forms.CheckBox chkSplitPics;
    private System.Windows.Forms.FolderBrowserDialog dlgSaveFolder;

  }
}