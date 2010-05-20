using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using S60.Plugins;
using S60.Tools.MIF;

namespace S60
{
  public partial class frmNokia : Form
  {
    public string strROFSDir = "";
    public string strCenRepDir = "";
    public string strMyDir = "";
    private StandardEditor xStEditor;
    private List<PluginHost> mPlugins; 

    public frmNokia()
    {
      InitializeComponent();
      strMyDir = Application.StartupPath;
      if (!System.IO.Directory.Exists(strMyDir+"\\Plugins") )
      {
        System.IO.Directory.CreateDirectory(strMyDir+"\\Plugins");
      }
      if ( !System.IO.Directory.Exists(strMyDir+"\\Patches") )
      {
        System.IO.Directory.CreateDirectory(strMyDir+"\\Patches");
      }
      if ( !System.IO.Directory.Exists(strMyDir+"\\Mods") )
      {
        System.IO.Directory.CreateDirectory(strMyDir+"\\Mods");
      }
      if ( !System.IO.Directory.Exists(strMyDir+"\\XMLPlugins") )
      {
        System.IO.Directory.CreateDirectory(strMyDir+"\\XMLPlugins");
      }
      if ( !System.IO.Directory.Exists(strMyDir+"\\Temp") )
      {
        System.IO.Directory.CreateDirectory(strMyDir+"\\Temp");
      }
      if ( !System.IO.Directory.Exists(strMyDir+@"\Temp\Patch"))
        System.IO.Directory.CreateDirectory(strMyDir + "\\Temp\\Patch");
      if ( !System.IO.Directory.Exists(strMyDir+@"\Temp\Mods"))
        System.IO.Directory.CreateDirectory(strMyDir + "\\Temp\\Mods");
      if ( !System.IO.Directory.Exists(strMyDir+@"\Temp\Other"))
        System.IO.Directory.CreateDirectory(strMyDir + "\\Temp\\Other");
      if (!System.IO.Directory.Exists(strMyDir + @"\Temp\Backup"))
        System.IO.Directory.CreateDirectory(strMyDir + @"\Temp\Backup");

      DisableCR_Controls();
      mPlugins = PluginHostProvider.Plugins;
      foreach (PluginHost myPlugins in mPlugins)
      {
        ToolStripItem xt = mnuPlugins.DropDownItems.Add(myPlugins.GetMenuName(),null,new EventHandler(NewLoad));
      }
    }

    private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    private void NewLoad(object sender, System.EventArgs e)
    {
      ToolStripItem ts = (ToolStripItem)sender;
      for (int i = 0; i < mPlugins.Count; i++)
      {
        if (mPlugins.ElementAt(i).GetMenuName() == ts.Text)
        {
          XmlDocument xml = new XmlDocument();
          xml.LoadXml("<root><CENREPDIR>" + strCenRepDir + "</CENREPDIR><PROGDIR>" + Application.StartupPath + "</PROGDIR></root>");
          mPlugins.ElementAt(i).RunPlugin(xml);
        }
      }
    }

    private void rOFSKönyvtárMegnyitásaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool bRetry = true;
      while (bRetry)
      {
        if (this.dlgOpenDir.ShowDialog() == DialogResult.OK)
        {
          strROFSDir = this.dlgOpenDir.SelectedPath;
          if (!System.IO.Directory.Exists(strROFSDir + "\\private\\10202be9"))
          {
            if (MessageBox.Show("A megadott könyvtár nem tartalmaz CenRep-et", "HIBA!", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
              bRetry = false;
          }
          else
            bRetry = false;
        }
      }
      strCenRepDir = strROFSDir + "\\private\\10202be9";
      this.tptDirectory.Text = strROFSDir;
      ReadCenrep();
      EnableCR_Controls();
      fsWatcher.Path = strCenRepDir;
      fsWatcher.Changed += new System.IO.FileSystemEventHandler(CRFileChanged);
      fsWatcher.EnableRaisingEvents = true;
    }
    
    private void CRFileChanged(object source, FileSystemEventArgs e)
    {
      string crFile = e.Name.Substring(0, 8);
      SetChanged(crFile);
    }
    void SetChanged(string x)
    {
      foreach (DataGridViewRow actrow in lstCenRep.Rows)
      {
        if ((string)actrow.Cells[0].Value == x)
        {
          actrow.Cells[2].Value = true;
          break;
        }
      }
    }
    private void EnableCR_Controls()
    {
      btnAplyPatch.Enabled = true;
      btnEditor.Enabled = true;
      btnMakePatch.Enabled = true;
      btRevoke.Enabled = true;
      mnuCenRep.Enabled = true;
      lstCenRep.Enabled = true;
    }

    private void DisableCR_Controls()
    {
      btnAplyPatch.Enabled = false;
      btnEditor.Enabled = false;
      btnMakePatch.Enabled = false;
      btRevoke.Enabled = false;
      mnuCenRep.Enabled = false;
      lstCenRep.Enabled = false;
    }


    private void ReadCenrep()
    {
      string[] strCFiles;
      strCFiles = System.IO.Directory.GetFiles(strCenRepDir,"*.txt");
      int counter = 0;
      foreach (string strCF in strCFiles)
      {
        string stmp = xLeft(xRight(strCF,12),8);
        string stPl = "Nincs telepített plugin";
        if (System.IO.File.Exists(strMyDir+"\\XMLPlugins\\"+stmp+".xml"))
        {
          stPl="Van plugin!!!!";
          // parseXMLPlugin(strMyDir + "\\XMLPlugins\\" + stmp + ".xml");
        }
        object[] tmpRow = {stmp,stPl,false};
        lstCenRep.Rows.Add(tmpRow);
        counter++;
      }
      lstCenRep.RowCount = counter;
      lstCenRep.ScrollBars = ScrollBars.None;
      lstCenRep.ScrollBars = ScrollBars.Vertical;
      lstCenRep.Hide();
      lstCenRep.Show();
      if (counter != lstCenRep.RowCount)
      {
        lstCenRep.Invalidate();
        lstCenRep.Refresh();
      }
    }

    private string xRight(string source, int chnum)
    {
      int idx;
      string retval = "";
      for (idx = chnum; idx != 0; idx--)
        retval = retval + source[source.Length - idx];
      return retval;
    }

    private string xLeft(string source, int chnum)
    {
      int idx;
      string retval = "";
      for (idx = 0; idx < chnum; idx++)
        retval = retval + source[idx];
      return retval;
    }

    private void MNUCrInit(object sender, CancelEventArgs e)
    {
      int sl = lstCenRep.CurrentRow.Index;
    }

    private void parseXMLPlugin(string xmlpugfile)
    {
      XmlDocument xDoc = new XmlDocument();
      xDoc.Load(xmlpugfile);

    }

    private void BackupCenrep(string sUID)
    {
      string source;
      string destination;
      source = strCenRepDir + @"\" + sUID + ".txt";
      destination = Application.StartupPath + @"\Temp\Backup\" + sUID + ".txt";
      System.IO.File.Copy(source, destination);
    }

    private void mnuEditPlugin(object sender, EventArgs e)
    {
      int sl = lstCenRep.CurrentRow.Index;
      string fn = (string)lstCenRep.Rows[sl].Cells[0].Value;
      fn = Application.StartupPath + "\\XMLPlugins\\" + fn + ".xml";
      if (System.IO.File.Exists(fn))
      {
        /* parseXMLPlugin(fn); */
        //CXMLPlugin xP = new CXMLPlugin(fn);
      }
      else
      {
        MessageBox.Show("Az UID-hez nincs telepített plugin!!!", "HIBA!!!");
      }

    }

    private void FindUID(object sender, EventArgs e)
    {
      Form dlgFind = new dlgFindUID();
      dlgFind.ShowDialog();
      
    }

    private void StdEdit(object sender, EventArgs e)
    {
      StandardEditor frmEditor;
      string fn = strCenRepDir+@"\"+lstCenRep.Rows[lstCenRep.CurrentRow.Index].Cells[0].Value+".txt";
      if (System.IO.File.Exists(fn))
      {
        xStEditor = new StandardEditor(fn);
        xStEditor.Show();
      }
      else
      {
        MessageBox.Show("A megadott file nem létezik!", "HIBA!", MessageBoxButtons.OK);
      }
    }

    private void ClosingBefore(object sender, FormClosingEventArgs e)
    {
      if (System.IO.Directory.GetFiles(Application.StartupPath + @"\Temp\Backup\","*.txt").Length != 0)
      {
        if (MessageBox.Show("A rendszerben mentés állományok találhatóak. Kilépés előtt töröljük?", "Figyelem!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          foreach (string fd in System.IO.Directory.GetFiles(Application.StartupPath + @"\Temp\Backup\", "*.txt"))
          {
            System.IO.File.Delete(fd);
          }
        }
      }
    }
    
    private void RestoreBackup(bool flAll)
    {
      if (flAll)
      {
        foreach (DataGridViewRow row in lstCenRep.Rows)
        {
          if ((bool)row.Cells[2].Value)
          {
            if (File.Exists(Application.StartupPath + @"\Temp\Backup\" + row.Cells[0].Value + ".txt"))
            {
              File.Copy(Application.StartupPath + @"\Temp\Backup\" + row.Cells[0].Value + ".txt", strCenRepDir + @"\" + row.Cells[0].Value + ".txt", true);
              row.Cells[2].Value = false;
            }
            else
              MessageBox.Show("Nem található backup állomány! ("+row.Cells[0].Value+")", "HIBA!");
          }
        }
      }
      else
      {
        if ((bool)lstCenRep.CurrentRow.Cells[2].Value)
        {
          if (System.IO.File.Exists(Application.StartupPath + @"\Temp\Backup\" + lstCenRep.CurrentRow.Cells[0].Value + ".txt"))
          {
            File.Copy(Application.StartupPath + @"\Temp\Backup\" + lstCenRep.CurrentRow.Cells[0].Value + ".txt", strCenRepDir + @"\" + lstCenRep.CurrentRow.Cells[0].Value + ".txt", true);
            lstCenRep.CurrentRow.Cells[2].Value = false;
          }
          else
            MessageBox.Show("Nem található backup állomány!", "HIBA!");
        }
      }
    }

    private void DoUndo(object sender, EventArgs e)
    {
      RestoreBackup(false);
    }

    private void onMakeMIF(object sender, EventArgs e)
    {
      MIFWriterClass myMif = new MIFWriterClass();
      frmMIFMaker x = new frmMIFMaker();
      x.ShowDialog();
    }

  }
}
