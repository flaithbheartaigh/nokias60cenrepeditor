using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.Lib.CenRep;

namespace S60.CenRepEditor
{
  public partial class frmMain : Form
  {
    string CenRepDir = "";
    string rootProgDir = Application.StartupPath;
    XMLPlugin plugin = null;
    XMLPlugin phones = null;
    public frmMain()
    {
      InitializeComponent();
      if (File.Exists(rootProgDir+@"\XML\CenRep.xml"))
      {
        plugin = new XMLPlugin(rootProgDir + @"\XML\CenRep.xml", "CENREP");
        phones = new XMLPlugin(rootProgDir + @"\XML\Phones.xml", "PHONES");
        plugin.Filter = "";
        phones.Filter = "";
        cmbName.Items.Clear();
        foreach (XElement xel in phones.rootDoc)
        {

        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      frmProperties prop = new frmProperties();
      prop.Show();
    }

    private void OpenRofsDir(object sender, EventArgs e)
    {
      if (dlgOpenRofs.ShowDialog() == DialogResult.Cancel)
        return;
      if (!Directory.Exists(dlgOpenRofs.SelectedPath+@"\private\10202be9"))
      {
        MessageBox.Show("The selected path dosn't contains Central Repository!!!","ERROR");
        return;
      }
      CenRepDir = dlgOpenRofs.SelectedPath + @"\private\10202be9";
      DirectoryInfo dirInfo = new DirectoryInfo(CenRepDir);
      foreach (FileInfo f in dirInfo.GetFiles("*.txt"))
      {
        ListViewItem tlCenRep = new ListViewItem(new string[] {
          f.Name,
          f.Length > 2040 ? (f.Length/2048).ToString()+" Kb" : f.Length.ToString()+" b",
          f.CreationTime.ToLongDateString(),
          "No","No","No","Not available"
        });
        if (null != plugin)
        {
          string strFN = Path.GetFileNameWithoutExtension(f.Name);
          XElement x = plugin[strFN];
          if ( x.HasAttribute("description"))
          {
            tlCenRep.SubItems[6].Text = x.Attribute("description").Value;
          }
        }
        lstCenRep.Items.Add(tlCenRep);
      }
      //lstCenRep.ContextMenu = mnuRightClick.
    }

    private void ExitClick( object sender, EventArgs e )
    {
      Application.Exit();
    }

    private void ChangeOrder( object sender, ColumnClickEventArgs e )
    {

    }
  }
}
