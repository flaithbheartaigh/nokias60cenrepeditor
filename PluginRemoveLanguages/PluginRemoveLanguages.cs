using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlugInCore.InterFaces;
using PlugInCore.Attributes;
using System.Xml;
using System.Windows.Forms;

namespace PluginRemoveLanguages
{
  [CenRepPluginAttributes("Felesleges nyelvek eltávolítása")]
  public class PluginRemoveLanguages : ICenRepPlugins
  {
    public string PluginMenuName()
    {
      return "Nyelvek eltávolítása";
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
      MessageBox.Show("Nyelvek eltávolítása plugin elindult!");
    }
    public void myHandler(object sender, System.EventArgs e)
    {
    }
  }
}
