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
using S60.Lib.Firmware;

namespace S60.FirmEditor
{
  public partial class frmMain : Form
  {

    private List<PluginHost> mPlugins;
    private string strROFSDir = "";
    private ImageList _smallImageList = new ImageList();
    private ImageList _largeImageList = new ImageList();
    private IconListManager _iconListManager;
    private ImageList _foldericon = new ImageList();

    public frmMain()
    {
      InitializeComponent();

      _foldericon.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small,IconReader.FolderType.Closed));
      _foldericon.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Open));

      _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
      _largeImageList.ColorDepth = ColorDepth.Depth32Bit;

      _smallImageList.ImageSize = new System.Drawing.Size(16, 16);
      _largeImageList.ImageSize = new System.Drawing.Size(32, 32);

      _iconListManager = new IconListManager(_smallImageList, _largeImageList);

      listviewFileList.SmallImageList = _smallImageList;
      listviewFileList.LargeImageList = _largeImageList;

      Utils.Check();
      
      folderView.PathSeparator = @"\";
      folderView.ImageList = _foldericon;

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

    private void populateDirView(string folder, TreeNode rootNode)
    {
      DirectoryInfo dir = new DirectoryInfo(folder);
      foreach (DirectoryInfo d in dir.GetDirectories())
      {
        TreeNode subnode = new TreeNode(d.Name);
        subnode.Tag = d.FullName;
        subnode.ImageIndex = 0;
        subnode.SelectedImageIndex = 1;
       
        if (null == rootNode)
          folderView.Nodes.Add(subnode);
        else
          rootNode.Nodes.Add(subnode);

        populateDirView(d.FullName, subnode);
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
      TreeNode rootNode = new TreeNode("ROOT");
      rootNode.Tag = strKonyvtar;
      populateDirView(strKonyvtar,rootNode);
      folderView.Nodes.Add(rootNode);
      strROFSDir = strKonyvtar;
      folderView.SelectedNode = folderView.TopNode;
      DirectorySelect(null, null);
      //File ablak feltöltés...
    }

  
    private void DirectorySelect(object sender, TreeViewEventArgs e)
    {
      string strFullPath = folderView.SelectedNode.Tag.ToString();
      DirectoryInfo dirInfo = new DirectoryInfo(strFullPath);
      listviewFileList.Items.Clear();
      foreach (DirectoryInfo dir in dirInfo.GetDirectories())
      {
        ListViewItem item = new ListViewItem(new string[] { dir.Name,"",dir.CreationTime.ToString() });
        item.ImageIndex = 0;
        item.Tag = dir.FullName;
        listviewFileList.Items.Add(item);
      }
      foreach (FileInfo file in dirInfo.GetFiles())
      {
        ListViewItem item = new ListViewItem(new string[] { file.Name, (file.Length>2048)?(file.Length / 1024).ToString()+" Kb":file.Length.ToString()+" b", file.CreationTime.ToString(),"under develop.", "0x00" });
        item.ImageIndex = _iconListManager.AddFileIcon(file.FullName);
        item.Tag = file.FullName;
        listviewFileList.Items.Add(item);
      }

    }

    private void OpenFirmWare(object sender, EventArgs e)
    {
      FwFile myFirm = new FwFile();
      myFirm.outputDir = Application.StartupPath + @"\ROFSIMAGE";
      if (FirmOpenDialog.ShowDialog() == DialogResult.Cancel)
        return;
      string firmFile = FirmOpenDialog.FileName;
      myFirm.Test(firmFile);
      UseExternalTools.ExtractImage(Application.StartupPath + @"\Tools", Application.StartupPath + @"\ROFSIMAGE\rofsImage.bin", Application.StartupPath + @"\ROFSROOT");
      TreeNode rootNode = new TreeNode(Path.GetFileName(firmFile));
      strROFSDir = Application.StartupPath + @"\ROFSROOT";
      rootNode.Tag = strROFSDir;
      populateDirView(strROFSDir, rootNode);
      folderView.Nodes.Add(rootNode);
      folderView.SelectedNode = folderView.TopNode;
      DirectorySelect(null, null);

    }

    private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

  }

}


