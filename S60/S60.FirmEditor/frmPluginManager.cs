using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using S60.PluginInterface;

namespace S60.FirmEditor
{
    public partial class frmPluginManager : Form
    {
      private List<PluginHost> m_plugins;

      public frmPluginManager()
      {
        InitializeComponent();
        m_plugins = PluginHostProvider.Plugins;
        foreach (PluginHost loadedPlugins in m_plugins)
        {
          TreeNode tmpNode = new TreeNode(loadedPlugins.GetPluginName());
          treeView1.Nodes.Add(tmpNode);
        }
      }

      private void button1_Click(object sender, EventArgs e)
      {
        this.Close();
      }
    }
}
