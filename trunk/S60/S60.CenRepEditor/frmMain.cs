using System;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.CenRepEditor.Properties;
using S60.Lib.CenRep;

namespace S60.CenRepEditor
{
  using System.Collections.Generic;

// ReSharper disable InconsistentNaming
  public partial class frmMain : Form
// ReSharper restore InconsistentNaming
  {
    string _cenRepDir = "";
    readonly string _rootProgDir = Application.StartupPath;
// ReSharper disable InconsistentNaming
    public XMLPlugin plugin;
// ReSharper restore InconsistentNaming
    readonly XMLPlugin _phones;
// ReSharper disable FieldCanBeMadeReadOnly.Local
    private frmSettings _frmMySettings = new frmSettings();
// ReSharper restore FieldCanBeMadeReadOnly.Local
    private frmInternalEditor _frmMyEditor;
    private readonly ImageList _patchIcons;

    public frmMain()
    {
      InitializeComponent();
      _patchIcons = new ImageList();
      _patchIcons.Images.Add( Resources.Checked_Shield_Green );
      _patchIcons.Images.Add( Resources.Shield_Red );
      if ( !File.Exists( _rootProgDir + @"\XML\CenRep.xml" ) ) return;
      plugin = new XMLPlugin(_rootProgDir + @"\XML\CenRep.xml", "CENREP");
      _phones = new XMLPlugin(_rootProgDir + @"\XML\Phones.xml", "PHONES");
      plugin.Filter = "";
      _phones.Filter = "";
      cmbName.Items.Clear();
      for (int i = 0; i < _phones.Count; i++)
      {
// ReSharper disable PossibleNullReferenceException
        cmbName.Items.Add(_phones[i].Attribute("type").Value);
// ReSharper restore PossibleNullReferenceException
      }
      lstCenRep.LargeImageList = _patchIcons;
      lstCenRep.SmallImageList = _patchIcons;
    }

// ReSharper disable UnusedMember.Local
    private void BatchPatch()
// ReSharper restore UnusedMember.Local
    {
      List<string > requirePatch = ( from ListViewItem lvItem in lstCenRep.Items where lvItem.SubItems[4].Text == Resources._YES select lvItem.SubItems[0].Text ).ToList();
      foreach(string s in requirePatch)
      {
        TCenRepParser cParser = new TCenRepParser(_cenRepDir+@"\"+s+@".txt");
        foreach (XElement xActPatch in plugin[s].Elements("PATCH"))
        {
          cParser.ApplyPatch(xActPatch);
        }
        cParser.Save();
      }
    }

    private void OpenRofsDir(object sender, EventArgs e)
    {
      if (dlgOpenRofs.ShowDialog() == DialogResult.Cancel)
        return;
      if (!Directory.Exists(dlgOpenRofs.SelectedPath+@"\private\10202be9"))
      {
        MessageBox.Show(Resources.ERROR_NO_CENREP,Resources.ERROR_TITLE);
        return;
      }
      _cenRepDir = dlgOpenRofs.SelectedPath + @"\private\10202be9";
      DirectoryInfo dirInfo = new DirectoryInfo(_cenRepDir);
      foreach (FileInfo f in dirInfo.GetFiles("*.txt"))
      {
        ListViewItem tlCenRep = new ListViewItem(new[] {
          f.Name,
          f.Length > 2040 ? (f.Length/2048)+" Kb" : f.Length+" b",
          f.CreationTime.ToLongDateString(),
          "No","No","No","Not available"
        },1);
        if (null != plugin)
        {
          string strFn = Path.GetFileNameWithoutExtension(f.Name);
          XElement x = plugin[strFn];
          if ( x.HasAttribute("description"))
          {
// ReSharper disable PossibleNullReferenceException
            if (x != null) tlCenRep.SubItems[6].Text = x.Attribute("description").Value;
// ReSharper restore PossibleNullReferenceException
            if ( x != null )
              if (x.Elements( "PATCH" ).Count()>0 )
              {
                tlCenRep.SubItems[4].Text = Resources._YES;
                tlCenRep.ImageIndex = 0;
              }
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

    private void ChangeModell(object sender, EventArgs e)
    {
      cmbModel.Items.Clear();
      cmbModel.Text = "";
      cmbFirm.Items.Clear();
      cmbFirm.Text = "";
      foreach (XElement xel in
        _phones[cmbName.SelectedIndex].Elements().Where(xel => xel != null).Where(xel => xel != null))
      {
// ReSharper disable PossibleNullReferenceException
        if (xel != null) cmbModel.Items.Add(xel.Attribute("name").Value);
// ReSharper restore PossibleNullReferenceException
      }
    }

    private void ChangeType(object sender, EventArgs e)
    {
      cmbFirm.Items.Clear();
      cmbFirm.Text = "";
// ReSharper disable PossibleNullReferenceException
      foreach (XElement xel in _phones[cmbName.SelectedIndex].Element("MODEL").Elements())
// ReSharper restore PossibleNullReferenceException
      {
        cmbFirm.Items.Add(xel.Value);
      }
    }

    private void ClickSettings(object sender, EventArgs e)
    {
      _frmMySettings.Show();
    }

    private void ClickEditWithBuiltIn( object sender, EventArgs e )
    {
      string crFileName = string.Format("{0}\\{1}",_cenRepDir, lstCenRep.SelectedItems[0].SubItems[0].Text);
      StringBuilder sb = new StringBuilder(cmbName.Text==""?"*":cmbName.Text).
        Append(";").
        Append(cmbModel.Text==""?"*":cmbModel.Text).
        Append(";").
        Append(cmbFirm.Text==""?"*":cmbFirm.Text);
      _frmMyEditor = new frmInternalEditor(crFileName, sb.ToString(),plugin);
      _frmMyEditor.Show();
    }

    private void OnMakePatch( object sender, EventArgs e )
    {
      string fn = _cenRepDir+@"\" +lstCenRep.SelectedItems[0].SubItems[0].Text+".txt";
      TCenRepParser cenRep = new TCenRepParser( fn );
      ofdOpenCenrep.DefaultExt = "txt";
      ofdOpenCenrep.FileName = lstCenRep.SelectedItems[0].SubItems[0].Text + ".txt";
      ofdOpenCenrep.InitialDirectory=@"C:\";
      if ( ofdOpenCenrep.ShowDialog() != DialogResult.OK ) return;
      XElement xPatch = cenRep.CreatePatch( ofdOpenCenrep.SafeFileName );
      plugin.Add( xPatch );
      plugin.Save();
    }

    private void OnApplyPatch(object sender, EventArgs e)
    {
      if (lstCenRep.SelectedItems.Count>1)
      {
        if (MessageBox.Show("Patching all selected items?","Multiple secetion",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
        {
          MessageBox.Show("Patching aborted...");
          return;
        }
      }
      foreach (ListViewItem lvItem in lstCenRep.SelectedItems)
      {
        string fn = _cenRepDir + @"\" + lvItem.SubItems[0].Text + ".txt";
        //File.Copy(fn,); //Backup
        lvItem.SubItems[3].Text = "YES";
        TCenRepParser cenrPatcher = new TCenRepParser(fn);
        if (lvItem.SubItems[4].Text=="YES")
        {
          cenrPatcher.ApplyPatch(plugin[lvItem.SubItems[0].Text]);

        }
      }
    }
  }
}
