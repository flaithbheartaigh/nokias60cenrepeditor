﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace PlugInCore.InterFaces
{
  public interface ICenRepPlugins
  {
    string PluginMenuName();
    void RunPlugin(XmlDocument xmlParameters);
    void myHandler(object sender, System.EventArgs e);
  }
}
