using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace S60.FirmEditor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            TreeNode node;
            if(folderView.Nodes.Count == 0)
            {
                node = new TreeNode("");
                node.Tag = Application.StartupPath;
            }
            else
            {
                node = folderView.SelectedNode;
            }

            DirectoryInfo dir = new DirectoryInfo(node.Tag.ToString());

            foreach (DirectoryInfo subDir in dir.GetDirectories(searchBox.Text, SearchOption.AllDirectories))
            {
                ListViewItem item = new ListViewItem(new string[] { dir.Name, "", dir.CreationTime.ToString(), "Folder", "0x0" });
                listView.Items.Add(item);
            }
            foreach (FileInfo file in dir.GetFiles(searchBox.Text, SearchOption.AllDirectories))
            {
                ListViewItem item = new ListViewItem(new string[] {file.Name, file.Length/1024 + " kB", file.CreationTime.ToString(), file.GetType().ToString(), "0x0"});
                listView.Items.Add(item);
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
    }

}
