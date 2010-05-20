using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S60.Plugins.Interfaces;
using S60.Plugins.Attributes;
using S60.Plugins;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace S60.Plugins
{
  [CenRepPluginAttributes("ROFS2/ROFS3 csomagolás")]
  public class PluginWorkWithROMS : ICenRepPlugins
  {
    private FwFile fwROM;
    public void RunPlugin(XmlDocument xml)
    {
      fwROM = new FwFile();
      OpenFileDialog myOpen = new OpenFileDialog();
      myOpen.Multiselect = false;
      myOpen.InitialDirectory = "";
      myOpen.SupportMultiDottedExtensions=true;
      myOpen.Filter = "ROFS2 képfájl (*.v??)|*.V??|ROFS3 képfájl (*.rofs3.fpsx)|*.rofs3.fpsx|UDA képfájl (*.uda.fpsx)|*.uda.fpsx";
      if (myOpen.ShowDialog() == DialogResult.OK)
      {
        string tmpFN = myOpen.FileName;
        if (tmpFN.Contains("V0"))
        {
          fwROM.outputDir=Application.StartupPath+"\\ROFS2";
        }
        else if (tmpFN.Contains("rofs3"))
        {
          fwROM.outputDir = Application.StartupPath + "\\ROFS3";
        }
        else if (tmpFN.Contains("uda"))
        {
          fwROM.outputDir = Application.StartupPath + "\\UDA";
        }
        else
        {
          MessageBox.Show("Nem támogatott fájltípus!", "HIBA!");
          return;
        }
        fwROM.Test(tmpFN);
      }
    }

    public string PluginMenuName()
    {
      return "ROM feldolgozó";
    }

    public void myHandler(object sender, System.EventArgs e)
    {
    }
  }
}
