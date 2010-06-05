using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.PluginInterface;
using System.Text.RegularExpressions;
using S60.FirmEditor;
using System.Diagnostics;
using S60.Lib.Imaging;

namespace S60.FirmEditor
{
  public partial class frmMain : Form
  {

    private List<PluginHost> mPlugins;
    private string strROFSDir = "";
    private ImageList _smallImageList = new ImageList();
    private ImageList _largeImageList = new ImageList();
    private IconListManager _iconListManager;

    public frmMain()
    {
      InitializeComponent();
      _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
      _largeImageList.ColorDepth = ColorDepth.Depth32Bit;

      _smallImageList.ImageSize = new System.Drawing.Size(16, 16);
      _largeImageList.ImageSize = new System.Drawing.Size(32, 32);

      _iconListManager = new IconListManager(_smallImageList, _largeImageList);

      listviewFileList.SmallImageList = _smallImageList;
      listviewFileList.LargeImageList = _largeImageList;
      Utils.Check();
      folderView.PathSeparator = @"\";
      mPlugins = PluginHostProvider.Plugins;
      foreach (PluginHost loadedPlugins in mPlugins)
      {
        string strMenuName = loadedPlugins.GetMenuName();
        string[] strNames = Regex.Split(strMenuName, "/");
        if (strNames.Length < 2)
          UpdateMenu("Plugins", strNames[0], loadedPlugins.myHandler);
        else
          UpdateMenu(strNames[0], strNames[1], loadedPlugins.myHandler);
      }
    }

    private void UpdateMenu(string strParent, string txt, EventHandler cmdHandler)
    {
      ToolStripMenuItem dynamicMenu = new ToolStripMenuItem();

      dynamicMenu.Text = txt;
      dynamicMenu.Click += cmdHandler;
      
      foreach (ToolStripMenuItem parent in mnuMain.Items)
      {
        if (parent.Text == strParent)
        {
          parent.DropDownItems.Add(dynamicMenu);
          Utils.Check();
          return;
        }
      }
      ToolStripMenuItem newDropDown = new ToolStripMenuItem(strParent);
      newDropDown.DropDownItems.Add(dynamicMenu);
      mnuMain.Items.Add(newDropDown);
    }

    private void searchBox_TextChanged(object sender, EventArgs e)
    {
      listviewFileList.Items.Clear();
      DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\");

      foreach (DirectoryInfo subDir in dir.GetDirectories("*", SearchOption.AllDirectories))
      {
        if (subDir.Name.Contains(searchBox.Text))
        {
          ListViewItem item = new ListViewItem(new string[] { subDir.FullName.Substring(Application.StartupPath.Length + 1), "", dir.CreationTime.ToString(), "Folder", "0x0" });
          listviewFileList.Items.Add(item);
        }
      }
      foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
      {
        if (file.Name.Contains(searchBox.Text))
        {
          if (!searchBox.Items.Contains(searchBox.Text))
          {
            ListViewItem item = new ListViewItem(new string[] { file.Name, file.Length / 1024 + " kB", file.CreationTime.ToString(), file.GetType().ToString(), "0x0" });
            listviewFileList.Items.Add(item);
          }
        }

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

    private Icon GetExtensionIcon(string ext)
    {
      throw new NotImplementedException();
    }

    private void FillDirTree(string strDir,TreeNode parent)
    {
      string[] dirArray = Directory.GetDirectories(strDir);
      try
      {
        if (dirArray.Length != 0)
        {
          Regex reSubDir = new Regex(@".+\\(?<sbdir>.+)$",RegexOptions.Compiled);
          foreach (string directory in dirArray)
          {
            Match maSubDir = reSubDir.Match(directory);
            TreeNode myNode;
            if (null == parent)
            {
              myNode = folderView.Nodes.Add(maSubDir.Groups["sbdir"].Value);
            }
            else
            {
              myNode = parent.Nodes.Add(maSubDir.Groups["sbdir"].Value);
            }
            FillDirTree(directory, myNode);
          }
        }
      }
      catch
      {
        if (null == parent)
          folderView.Nodes.Add("Access denied");
        else
          parent.Nodes.Add("Access denied");
      }
    }

    private void OpenROFSFolder(object sender, EventArgs e)
    {
      string strKonyvtar;
      FolderBrowserDialog openFolder = new FolderBrowserDialog();
      openFolder.SelectedPath = @"C:\";
      openFolder.Description = "Open firmware directory";
      if (openFolder.ShowDialog() == DialogResult.Cancel)
      {
        openFolder.Dispose();
        return;
      }
      strKonyvtar = openFolder.SelectedPath;
      openFolder.Dispose();
      if (!Directory.Exists(strKonyvtar))
      {
        MessageBox.Show("Directory doesn't exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      folderView.Nodes.Clear();
      FillDirTree(strKonyvtar, null);
      strROFSDir = strKonyvtar;
      folderView.SelectedNode = folderView.TopNode;
      ClickDirectory(null, null);
      //File ablak feltöltés...
    }

    private void ClickDirectory(object sender, EventArgs e)
    {
      string strFullPath = strROFSDir + @"\" + folderView.SelectedNode.FullPath;
      DirectoryInfo dirInfo = new DirectoryInfo(strFullPath);
      listviewFileList.Clear();
      foreach (FileInfo file in dirInfo.GetFiles())
      {
        ListViewItem item = new ListViewItem(new string[] { file.Name, (file.Length / 1024).ToString(), file.GetType().ToString(), "0x00" },_iconListManager.AddFileIcon(file.FullName));
        listviewFileList.Items.Add(item);
      }
    }

  }

}


