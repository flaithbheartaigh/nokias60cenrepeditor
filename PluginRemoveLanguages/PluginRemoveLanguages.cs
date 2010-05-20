using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S60.Plugins.Interfaces;
using S60.Plugins.Attributes;
using System.Xml;
using System.Windows.Forms;

namespace S60.Plugins
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
