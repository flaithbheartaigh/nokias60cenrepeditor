using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S60.PluginInterface;
using System.Xml;

namespace S60.Plugin.CenRepEditor
{
  [PluginAttributes("S60 Central Repository Editor")]
    public class CenRepEditor : IPlugin
    {
      public string PluginMenuName()
      {
        return "CenRep Editor";
      }

      public void RunPlugin()
      {
      }

      public void RunPlugin(XmlDocument xParams)
      {
      }

      public void myHandler(object sender, EventArgs e)
      {
      }

      public string GetPluginName()
      {
        return "S60 Central Repository Editor";
      }
    }
}
