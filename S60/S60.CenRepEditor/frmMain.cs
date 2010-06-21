/********************************************************************
  created:	2010/06/17
  created:	17:6:2010   22:15
  filename: 	F:\Projects\S60\S60\S60.CenRepEditor\frmMain.cs
  file path:	F:\Projects\S60\S60\S60.CenRepEditor
  file base:	frmMain
  file ext:	cs
  author:		Jakab András
  
  purpose:	
*********************************************************************/
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.CenRepEditor.Properties;
using S60.Lib.CenRep;

namespace S60.CenRepEditor
{
  using System.Collections;
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
    private FrmSettings _frmMySettings;
// ReSharper restore FieldCanBeMadeReadOnly.Local
    private frmInternalEditor _frmMyEditor;
    private readonly ImageList _patchIcons;
    private int _sortCol;
// ReSharper disable FieldCanBeMadeReadOnly.Local
    private Settings _mySettings = new Settings();
    private List<ListViewItem> _cloneList = new List<ListViewItem>();
// ReSharper restore FieldCanBeMadeReadOnly.Local

    public frmMain()
    {
      InitializeComponent();
      _frmMySettings = new FrmSettings( _mySettings );
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

      if (_mySettings.AttachDirectory != "")
        if (!Directory.Exists(_mySettings.AttachDirectory))
        {
          try
          {
            Directory.CreateDirectory(_mySettings.AttachDirectory);
          }
          catch (Exception)
          {
            MessageBox.Show(Resources.frmMain_AttachDoesnotExists, Resources.frmInternalEditor_frmInternalEditor_WARNING);
            _mySettings.AttachDirectory = "";
            _mySettings.Save();
           }
        }
      if(_mySettings.BackupPath !="")
        if (!Directory.Exists(_mySettings.BackupPath))
        {
          try
          {
            Directory.CreateDirectory(_mySettings.BackupPath);
          }
          catch (Exception)
          {
            MessageBox.Show(
              Resources.frmMain_Backupdoeasnotexists,
              Resources.frmInternalEditor_frmInternalEditor_WARNING);
            _mySettings.BackupPath = "";
            _mySettings.AutoBackup = false;
            _mySettings.Save();
            throw;
          }
        }
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
      if (_mySettings.DefRofsDir != "")
        dlgOpenRofs.SelectedPath = _mySettings.DefRofsDir;
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
          Resources.No,Resources.No,Resources.No,Resources.NotAvail
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
        _cloneList.Add(tlCenRep);
      }
      //lstCenRep.ContextMenu = mnuRightClick.
    }

    private void ExitClick( object sender, EventArgs e )
    {
      Application.Exit();
    }

    private void ChangeOrder( object sender, ColumnClickEventArgs e )
    {
      if ( e.Column == _sortCol )
      {
        
        lstCenRep.Sorting = lstCenRep.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
      _sortCol = e.Column;
      lstCenRep.ListViewItemSorter = new ListViewItemComparer( e.Column,lstCenRep.Sorting==SortOrder.Ascending );
    }

    private void ChangeModell(object sender, EventArgs e)
    {
      cmbModel.Items.Clear();
      cmbModel.Text = "";
      cmbFirm.Items.Clear();
      cmbFirm.Text = "";
      foreach ( XElement xel in _phones[cmbName.SelectedIndex].Elements().Where( xel => xel != null ).Where( xel => xel != null ).Where( xel => xel != null ) )
      {
        cmbModel.Items.Add(xel.Attribute("name").Value);
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
      if (null != _frmMySettings)
        _frmMySettings.Show();
      else
      {
        _frmMySettings = new FrmSettings(_mySettings);
      }
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
      if ( lstCenRep.SelectedItems.Count < 1 ) return;
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
        if (MessageBox.Show(Resources.frmMain_OnApplyPatch_Patching_all_selected_items_,Resources.frmMain_OnApplyPatch_Multiple_secetion,MessageBoxButtons.YesNo) == DialogResult.No)
        {
          MessageBox.Show(Resources.frmMain_OnApplyPatch_Patching_aborted___);
          return;
        }
      }
      foreach (ListViewItem lvItem in lstCenRep.SelectedItems)
      {
        string fn = _cenRepDir + @"\" + lvItem.SubItems[0].Text + ".txt";
        //File.Copy(fn,); //Backup
        lvItem.SubItems[3].Text = Resources._YES;
        TCenRepParser cenrPatcher = new TCenRepParser(fn);
        if (lvItem.SubItems[4].Text==Resources._YES)
        {
          cenrPatcher.ApplyPatch(plugin[lvItem.SubItems[0].Text]);

        }
      }
    }

    private void OnBtnFilterClick(object sender, EventArgs e)
    {
      foreach (ListViewItem lvItem in lstCenRep.Items)
      {
        XElement xItem = plugin[Path.GetFileNameWithoutExtension(lvItem.SubItems[0].Text)];
        lvItem.SubItems[4].Text = Resources._NO;
#pragma warning disable 168
        foreach (XElement xPatch in
#pragma warning restore 168
          xItem.Elements("PATCH").Where(
// ReSharper disable PossibleNullReferenceException
            xPatch => (xPatch.Attribute("phone").Value == cmbName.Text) || (cmbName.Text == @"*")).Where(
              xPatch => (xPatch.Attribute("type").Value == cmbModel.Text) || (cmbModel.Text == @"*")).Where(
                xPatch => (xPatch.Attribute("firmware").Value == cmbFirm.Text) || (cmbFirm.Text == @"*")))
        {
          lvItem.SubItems[4].Text = Resources._YES;
        }
// ReSharper restore PossibleNullReferenceException
      }
    }

    private void OnNameFilter(object sender, EventArgs e)
    {
      lstCenRep.BeginUpdate();
      lstCenRep.Items.Clear();
      foreach (ListViewItem lvItem in _cloneList)
      {
        lstCenRep.Items.Add(lvItem);
      }
      Regex reMatcher = new Regex(@"^"+txtNameFilter.Text,RegexOptions.Compiled);
      foreach (ListViewItem lvItem in
        lstCenRep.Items.Cast<ListViewItem>().Where(lvItem => !reMatcher.IsMatch(lvItem.SubItems[0].Text)))
      {
        lstCenRep.Items.Remove(lvItem);

      }
      lstCenRep.EndUpdate();
    }

    private void OnCloseRofs(object sender, EventArgs e)
    {
      _cenRepDir = "";
      lstCenRep.BeginUpdate();
      lstCenRep.Items.Clear();
      _cloneList = new List<ListViewItem>();
      lstCenRep.EndUpdate();
      lstCenRep.Refresh();
    }

    private void OnFactoryDefault(object sender, EventArgs e)
    {
      string destpath = (_mySettings.BackupPath != "") ? _mySettings.BackupPath : Application.StartupPath + @"\Backup";
      if (!Directory.Exists(destpath))
        Directory.CreateDirectory(destpath);
      StringBuilder sbPath = new StringBuilder(destpath);
      sbPath.Append(@"\Factory Default");
      if (!Directory.Exists(sbPath.ToString()))
        Directory.CreateDirectory(sbPath.ToString());
      if (cmbName.Text != "")
        sbPath.Append(@"\").Append(cmbName.Text);
      else
        sbPath.Append(@"\unkonwn");
      if (!Directory.Exists(sbPath.ToString()))
        Directory.CreateDirectory(sbPath.ToString());
      if (cmbModel.Text != "")
        sbPath.Append(@"\").Append(cmbModel.Text);
      else
        sbPath.Append(@"\unknown");
      if (!Directory.Exists(sbPath.ToString()))
        Directory.CreateDirectory(sbPath.ToString());
      if (cmbFirm.Text != "")
        sbPath.Append(@"\").Append(cmbFirm.Text);
      else
        sbPath.Append(@"\unknown");
      if (!Directory.Exists(sbPath.ToString()))
        Directory.CreateDirectory(sbPath.ToString());
      DirectoryInfo df = new DirectoryInfo(sbPath.ToString());
      if (df.GetFiles("*.*").Count()>0)
      {
        MessageBox.Show(Resources.FactoryBackuped, Resources.frmInternalEditor_frmInternalEditor_WARNING);
        return;
      }
      destpath = sbPath.Append(@"\").ToString();
      
      lblText.Visible = true;
      lblProcessName.Text = Resources.SFD;
      lblProcessName.Visible = true;
      tsProgress.Minimum = 0;
      tsProgress.Maximum = lstCenRep.Items.Count;
      tsProgress.Visible = true;
      foreach(ListViewItem lvItem in lstCenRep.Items)
      {
        tsProgress.Increment(1);
        string source = _cenRepDir + @"\" + lvItem.SubItems[0].Text;
        File.Copy(source,destpath+lvItem.SubItems[0].Text);
      }
      lblText.Visible = false;
      lblProcessName.Text = "";
      lblProcessName.Visible = false;
      tsProgress.Minimum = 0;
      tsProgress.Maximum = 0;
      tsProgress.Visible = false;
    }

    private void OnEditNotepad(object sender, EventArgs e)
    {
      if (_mySettings.AutoBackup)
      {
        if (!File.Exists(_mySettings.BackupPath + @"\" + lstCenRep.SelectedItems[0].SubItems[0].Text))
          File.Copy(_cenRepDir + @"\" + lstCenRep.SelectedItems[0].SubItems[0].Text,
                    _mySettings.BackupPath + @"\" + lstCenRep.SelectedItems[0].SubItems[0].Text);
      }
      Process p = Process.Start("Notepad.exe", _cenRepDir + @"\" + lstCenRep.SelectedItems[0].SubItems[0].Text);
      p.WaitForExit();
    }
  }

  public class ListViewItemComparer : IComparer
  {
    private readonly int _col;
    private readonly bool _order;

    public ListViewItemComparer(int column,bool sortorder)
    {
      _col = column;
      _order = sortorder;
    }

    public ListViewItemComparer()
    {
      _col = 0;
      _order = true;
    }

    #region IComparer Members

    public int Compare( object x, object y )
    {
      if ( _order )
        return String.Compare( ( (ListViewItem) x ).SubItems[_col].Text, ( (ListViewItem) y ).SubItems[_col].Text );
      return 1 - String.Compare( ( ( ListViewItem ) x ).SubItems[_col].Text, ( ( ListViewItem ) y ).SubItems[_col].Text );
    }

    #endregion
  }
}
