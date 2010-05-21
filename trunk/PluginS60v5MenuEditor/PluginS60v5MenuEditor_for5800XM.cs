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
  public sealed class PluginS60v5MenuEditor_for5800XM : ICenRepPlugins
  {
    private sealed class DTDParser : IDisposable
    {
      private struct struParser
      {
        public string strID { get; set; }
        public string strRegex { get; set; }
      }
      private List<struParser> myParser = new List<struParser>();
      private Regex reParser;
      private OpenFileDialog ofdGetDTDName = new OpenFileDialog();
      private string[] dtdLines;
      private string dtdFileName;
      private Func<string, string, string> regexParser;
      
      public DTDParser(string sourcedir)
      {
        ofdGetDTDName.InitialDirectory = sourcedir;
        ofdGetDTDName.Multiselect = false;
        ofdGetDTDName.CheckFileExists = true;
        ofdGetDTDName.DefaultExt = ".dtd";
        ofdGetDTDName.Filter = @"DTD XML specifikáció (*.dtd)|*.dtd";
        if (ofdGetDTDName.ShowDialog() == DialogResult.Cancel)
        {
          dtdFileName = sourcedir + @"17\appshelldata.dtd";
        }
        else
        {
          dtdFileName = ofdGetDTDName.FileName;
        }
        if ( !File.Exists(dtdFileName ))
        {
          throw new ArgumentException("A megadott fájl nem létezik!!!! -> Objektum nem létrehozható");
          return;
        }
      }

      public string Parse(string content)
      {
        // <!ENTiTY....> hivatkozások kifejtése
        string rcontent = content;
        regexParser = (reg,strReplace) =>
          {
            Regex re = new Regex(reg);
            if (re.Match(rcontent).Success)
            {
              rcontent = re.Replace(rcontent, strReplace);
            }
            return rcontent;
          };
        foreach (struParser sParse in myParser)
        {
          rcontent = regexParser(sParse.strRegex, sParse.strID);
        }
        return rcontent;
      }

      public void Dispose()
      {
        
      }

    }
    private XElement xMenu;
    private frmMenuEditor frmEditor = new frmMenuEditor();
    private string strDTDString = "<!DOCTYPE xcfwml SYSTEM \"appshelldata.dtd\">";

    public string PluginMenuName()
    {
      return "Menü szerkesztő 5800XM";
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
      MessageBox.Show("Menü szerkesztő elindult.");
      XmlNodeList nodes = xmlParameters.DocumentElement.GetElementsByTagName("ROFSDIR");
      string xmlmenu;
      if (!System.IO.Directory.Exists(nodes[0].FirstChild.Value))
      {
        MessageBox.Show("A megadott ROFS útvonal érvénytelen!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      xmlmenu = nodes[0].FirstChild.Value + @"\private\101f4cd2\content\appshelldata.xml";
      string dtdfile = nodes[0].FirstChild.Value + @"\private\101f4cd2\content\";
      //xMenu = new XElement();
      StreamReader rXml = new StreamReader(xmlmenu);
      string xmlcontent = rXml.ReadToEnd();
      Regex reRemoveDTD = new Regex(@"<!DOC[^>]+>");
      xmlcontent = reRemoveDTD.Replace(xmlcontent, "");
      if (Regex.Match(xmlcontent, @"&qtn[^;]+;").Success)
      {
        // Nem kifejtett nemzetközi menü
        DTDParser myParser = new DTDParser(dtdfile);
        xmlcontent = myParser.Parse(xmlcontent);
      }
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
