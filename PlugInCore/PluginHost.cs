using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using S60.Plugins.Interfaces;
using S60.Plugins.TestPlugin;


namespace S60.Plugins
{
  public class PluginHost
  {
    public PluginHost(ICenRepPlugins iPlugin)
    {
      m_plugin = iPlugin;
    }
    public PluginHost():this(new TestPluginOne()) {}
    private ICenRepPlugins m_plugin;

    public void RunPlugin(XmlDocument xParams)
    {
      m_plugin.RunPlugin(xParams);
    }

    public string GetMenuName()
    {
      return m_plugin.PluginMenuName();
    }
    
  }
}
