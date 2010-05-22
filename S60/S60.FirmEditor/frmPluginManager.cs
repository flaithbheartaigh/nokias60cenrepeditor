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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pluginsLoad()
        {
            // Clear the treeview
            treeView1.Nodes.Clear();

            // Add root nodes
            TreeNode firmNode = new TreeNode("Firmware plugins");
            TreeNode fileNode = new TreeNode("File plugins");
            treeView1.Nodes.Add(firmNode);
            treeView1.Nodes.Add(fileNode);

            // Load plugins
            m_plugins = PluginHostProvider.Plugins;

            // Go through all plugins and add them to the corresponding tree
            foreach (PluginHost loadedPlugins in m_plugins)
            {
                /* if(pluginType == firmPlugin) akkor adja hozzá a FirmPlugin fához */
                TreeNode tmpNode = new TreeNode(loadedPlugins.GetPluginName());

                firmNode.Nodes.Add(tmpNode);
                fileNode.Nodes.Add(tmpNode);
            }
        }
    }
}
