using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace S60.PluginInterface
{
    public sealed class PluginHost
    {
      public PluginHost(IPlugin iPlugin)
      {
        m_plugin = iPlugin;
      }

      //public PluginHost():this(new TestPluginOne()) {}
      private IPlugin m_plugin;

      public void RunPlugin(XmlDocument xParams)
      {
        m_plugin.RunPlugin(xParams);
      }

      public string GetMenuName()
      {
        return m_plugin.PluginMenuName();
      }

      public string GetPluginName()
      {
        return m_plugin.GetPluginName();
      }

      public void myHandler(object sender, EventArgs e)
      {
        m_plugin.myHandler(sender, e);
      }
  }

}
