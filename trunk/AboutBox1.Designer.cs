namespace S60
{
    partial class AboutBox1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox1));
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.button1 = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          this.tableLayoutPanel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // pictureBox1
          // 
          resources.ApplyResources(this.pictureBox1, "pictureBox1");
          this.pictureBox1.Name = "pictureBox1";
          this.pictureBox1.TabStop = false;
          // 
          // tableLayoutPanel1
          // 
          resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
          this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          // 
          // button1
          // 
          resources.ApplyResources(this.button1, "button1");
          this.button1.Name = "button1";
          this.button1.UseVisualStyleBackColor = true;
          // 
          // AboutBox1
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tableLayoutPanel1);
          this.Controls.Add(this.pictureBox1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AboutBox1";
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          this.tableLayoutPanel1.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;

    }
}
