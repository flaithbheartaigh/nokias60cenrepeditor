using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using S60.Plugins;
using S60.Plugins.Interfaces;
using S60.Plugins.Attributes;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace S60.Plugins.MenuEditor
{
  [CenRepPluginAttributes("Menü szerkesztő 5800XM")]
  public class PluginS60v5MenuEditor_for5800XM : ICenRepPlugins
  {
    private XElement xMenu;
    private frmMenuEditor frmEditor = new frmMenuEditor();
    public string PluginMenuName()
    {
      return "Menü szerkesztő 5800XM";
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
      MessageBox.Show("Menü szerkesztő elindult.");
      XmlNodeList nodes = xmlParameters.DocumentElement.GetElementsByTagName("CENREPDIR");
      string xmlmenu;
      if (!System.IO.Directory.Exists(nodes[0].Value))
      {
        MessageBox.Show("A megadott CenRep útvonal érvénytelen!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      xmlmenu = nodes[0].Value+@"\101f4cd2\content\appshelldata.xml";
      //xMenu = new XElement();
      StreamReader rXml = new StreamReader(xmlmenu);
      string xmlcontent = rXml.ReadToEnd();
      Regex reRemoveDTD = new Regex(@"<!DOC[^>]+>");
      xmlcontent = reRemoveDTD.Replace(xmlcontent, "");
      xMenu = XElement.Parse(xmlcontent);
      var xFolders = from xItem in xMenu.Elements("appshell:folder")
                     select new
                     {
                       name = (string)xItem.Attribute("short_name").Value
                     };
      foreach (var x in xFolders)
      {
        TreeNode trnFolder = new TreeNode(x.name);
        
      }
    }
    public void myHandler(object sender, System.EventArgs e)
    {
    }
  }
}
