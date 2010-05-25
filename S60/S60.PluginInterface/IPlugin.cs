using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace S60.PluginInterface
{
    public interface IPlugin
    {
      string PluginMenuName();
      void RunPlugin();
      void RunPlugin(XmlDocument xParams);
      void myHandler(object sender, System.EventArgs e);
      string GetPluginName();
    }
}
