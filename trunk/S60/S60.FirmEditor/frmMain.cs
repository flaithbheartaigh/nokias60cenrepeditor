using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.FirmEditor;
using System.Diagnostics;


namespace S60.FirmEditor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Utils.Check();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            listView.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\");

            foreach (DirectoryInfo subDir in dir.GetDirectories("*",SearchOption.AllDirectories))
            {
                if (subDir.Name.Contains(searchBox.Text))
                {
                    ListViewItem item = new ListViewItem(new string[] { subDir.FullName.Substring(Application.StartupPath.Length + 1), "", dir.CreationTime.ToString(), "Folder", "0x0" });
                    listView.Items.Add(item);
                }
            }
            foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                if (file.Name.Contains(searchBox.Text))
                {
                    ListViewItem item = new ListViewItem(new string[] { file.Name, file.Length / 1024 + " kB", file.CreationTime.ToString(), file.GetType().ToString(), "0x0" });
                    listView.Items.Add(item);
                }
            }

            if (searchBox.Text == String.Empty)
            {
                listView.Items.Clear();
            }
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPluginManager pluginMan = new frmPluginManager();
            pluginMan.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!searchBox.Items.Contains(searchBox.Text))
                {
                    searchBox.Items.Add(searchBox.Text);
                }
            }
        }

        private void exitFEdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

    }

}
