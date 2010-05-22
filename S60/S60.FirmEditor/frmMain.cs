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
using S60.PluginInterface;
using System.Text.RegularExpressions;

namespace S60.FirmEditor
{
  public partial class frmMain : Form
  {
    private List<PluginHost> mPlugins;
    public frmMain()
    {
      InitializeComponent();
      Utils.Check();
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

















      InitializeComponent();
      mPlugins = PluginHostProvider.Plugins;
      foreach (PluginHost loadedPlugin in mPlugins)
      {
        string strMenuName = loadedPlugin.GetMenuName();
        string[] strNames = Regex.Split(strMenuName,"/");
        if (strNames.Length < 2)
          UpdateMenu("Plugins",strNames[0],loadedPlugin.myHandler);
        else
          UpdateMenu(strNames[0],strNames[1],loadedPlugin.myHandler);
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
          return;
            Utils.Check();
        }
      }
      ToolStripMenuItem newDropDown = new ToolStripMenuItem(strParent);
      newDropDown.DropDownItems.Add(dynamicMenu);
      mnuMain.Items.Add(newDropDown);
   }
    }

    private void UpdateMenu(string parent, string txt, EventHandler myHandler)
    {
      ToolStripMenuItem mnuDynamicMenu = new ToolStripMenuItem(txt);
      mnuDynamicMenu.Click += myHandler;
      foreach (ToolStripMenuItem mnuTmp in mnuMain.Items)
            if (searchBox.Text == String.Empty)
      {
        if (mnuTmp.Text == parent)
        {
          mnuTmp.DropDownItems.Add(mnuDynamicMenu);
          return;
        }
            {
                listView.Items.Clear();
            }
        }

    private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmPluginManager pluginMan = new frmPluginManager();
      pluginMan.Show();
    }
      }
      ToolStripMenuItem mnuDropDown = new ToolStripMenuItem(parent);
      mnuDropDown.DropDownItems.Add(mnuDynamicMenu);
      mnuMain.Items.Add(mnuDropDown);
    }

    private void searchBox_TextChanged(object sender, EventArgs e)
    {
      listView.Items.Clear();
      DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\");

      foreach (DirectoryInfo subDir in dir.GetDirectories("*", SearchOption.AllDirectories))
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
        if (!searchBox.Items.Contains(searchBox.Text))
        {
          ListViewItem item = new ListViewItem(new string[] { file.Name, file.Length / 1024 + " kB", file.CreationTime.ToString(), file.GetType().ToString(), "0x0" });
          listView.Items.Add(item);
        }
      }

      if (searchBox.Text == String.Empty)
   private void exitFEdToolStripMenuItem_Click(object sender, EventArgs e)
      {
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
}

