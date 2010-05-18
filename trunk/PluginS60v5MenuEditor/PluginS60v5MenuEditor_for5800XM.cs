using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using PlugInCore;
using PlugInCore.InterFaces;
using PlugInCore.Attributes;

namespace PluginS60v5MenuEditor
{
  [CenRepPluginAttributes("Menü szerkesztő 5800XM")]
  public class PluginS60v5MenuEditor_for5800XM : ICenRepPlugins
  {
    private XmlDocument xMenu;
    public string PluginMenuName()
    {
      return "Menü szerkesztő 5800XM";
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
      MessageBox.Show("Menü szerkesztő elindult.");
      XmlNodeList nodes = xmlParameters.DocumentElement.GetElementsByTagName("CENREPDIR");
      if (!System.IO.Directory.Exists(nodes[0].Value))
      {
        MessageBox.Show("A megadott CenRep útvonal érvénytelen!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      xMenu = new XmlDocument();
      
    }
    public void myHandler(object sender, System.EventArgs e)
    {
    }
  }
}
