using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using S60.Plugins.Interfaces;

namespace S60.Plugins.TestPlugin
{
  class TestPluginOne:ICenRepPlugins
  {
    #region ICenrepPlugins rutinok
    
    public string PluginMenuName()
    {
      return "Teszt";
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
    }

    public void myHandler(object sender, System.EventArgs e)
    {
    }

    #endregion
    #region Változók
    #endregion
  }
}
