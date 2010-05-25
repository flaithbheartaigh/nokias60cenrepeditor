using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using S60.PluginInterface;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Resources;
using S60.Lib.Extenders;

namespace S60.Plugins.MenuEditor
{
  [PluginAttributes("Menü szerkesztő 5800XM")]
  public sealed class MenuEditor : IPlugin
  {
    // ******************DTDParser******************
    private sealed class DTDParser : IDisposable
    {
      private struct struParser
      {
        public string strKifejt { get; set; }
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
        }
        StreamReader dtdReader = new StreamReader(dtdFileName);
        dtdLines = dtdReader.ReadAllLines((x) => { return Regex.IsMatch(x,@"^<!ENTITY");}) ;
        foreach ( string ln in dtdLines )
        {
          Match regMatch = Regex.Match( ln, @"(?<qtn>qtn_\w+)\s+" + "\"" + @"(?<kifejt>[^" + "\"" + @"]+)" + "\"" );
          struParser ParserRec = new struParser
          {
            strKifejt = regMatch.Groups["kifejt"].Value,
            strRegex = @"\&"+regMatch.Groups["qtn"].Value+";"
          };
          myParser.Add( ParserRec );
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
          rcontent = regexParser(sParse.strRegex, sParse.strKifejt);
        }
        return rcontent;
      }

      public void Dispose()
      {
        
      }

    }
    // ******************DTDParser******************
    private enum ItemType
    {
      ITM_Unknown = 0,
      ITM_Folder,
      ITM_SisApp,
      ITM_JavaApp,
      ITM_Widget,
      ITM_Link
    }
    private struct ItemStruct
    {
      public ItemType itmType { get; set; }
      public Dictionary<string,string> menuAttr;
    };

    private XElement xMenu;
    private frmMenuEditor frmEditor = new frmMenuEditor();
    private string strDTDString = "<!DOCTYPE xcfwml SYSTEM \"appshelldata.dtd\">";
    private Dictionary<string,string> dctApplications = new Dictionary<string, string>();
    private Dictionary<TreeNode,ItemStruct> menuItemAttrs = new Dictionary<TreeNode, ItemStruct>();

    public string PluginMenuName()
    {
      return "Menü szerkesztő 5800XM";
    }
    public string GetPluginName()
    {
      return "Nokia 5800XM Menu Editor";
    }

    public void RunPlugin()
    {
      FolderBrowserDialog fbdOpenROFSDir = new FolderBrowserDialog();
      fbdOpenROFSDir.SelectedPath = @"C:\";
      fbdOpenROFSDir.Description = "ROFS könyvtár megnyitása";
      if (fbdOpenROFSDir.ShowDialog() == DialogResult.OK)
      {
        XmlDocument xmlParams = new XmlDocument();
        if (!File.Exists(fbdOpenROFSDir.SelectedPath + @"\private\101f4cd2\content\appshelldata.xml"))
        {
          MessageBox.Show("Érvénytelen útvonal. Menü fájl nem található a struktúrában.", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        xmlParams.LoadXml("<parameters><ROFSDIR>" + fbdOpenROFSDir.SelectedPath + "</ROFSDIR></parameters>");
        this.RunPlugin(xmlParams);
      }
    }

    public void RunPlugin(XmlDocument xmlParameters)
    {
      //MessageBox.Show("Menü szerkesztő elindult.");
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
      xmlcontent = Regex.Replace( xmlcontent, "appshell:", "", RegexOptions.Multiline );
      xMenu = XElement.Parse(xmlcontent);
      TreeNode trn = GenerateNodes( xMenu, null );
      frmEditor.AddMenuFolder( trn );
      frmEditor.Show();
    }
    public void myHandler(object sender, System.EventArgs e)
    {
      RunPlugin();
    }

    private TreeNode GenerateNodes( XElement element, TreeNode mnu )
    {
      TreeNode menuNodes = null;
      var xFolder = from xItem in element.Elements()
                         select xItem;
      foreach ( XElement xItem in xFolder )
      {
        ItemStruct tmpItem = new ItemStruct();
        switch (xItem.Name.ToString())
        {
          case "folder":
            tmpItem.itmType = ItemType.ITM_Folder;
            foreach ( var xAttr in xItem.Attributes() )
            {
              tmpItem.menuAttr.Add( xAttr.Name.ToString(), xAttr.Value.ToString() );
            }
            menuNodes = new TreeNode( xItem.Attribute( "short_name" ).Value );
            menuItemAttrs.Add( menuNodes, tmpItem );
            if ( null == mnu )
              mnu = GenerateNodes( xItem, menuNodes );
            else
              mnu.Nodes.Add( GenerateNodes( xItem, menuNodes ) );
            break;
          case "application":
            menuNodes = mnu.Nodes.Add( xItem.Attribute( "uid" ).Value );

            break;
          case "mmc":
            continue;
        }
      }
      return mnu;
    }

    /************************************************ MENTÉS **********************************************/
    private void SaveMenu()
    {
    }
    /************************************************ MENTÉS **********************************************/
  }
}
