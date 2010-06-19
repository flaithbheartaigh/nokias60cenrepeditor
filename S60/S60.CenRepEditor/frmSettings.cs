using System;
using System.Windows.Forms;
using S60.CenRepEditor.Properties;

namespace S60.CenRepEditor
{
  public partial class FrmSettings : Form
  {
    private Settings _appSettings;
    public FrmSettings(Settings appsettings)
    {
      InitializeComponent();
      _appSettings = appsettings;
      txtModderName.Text = _appSettings.ModderName;
      txtModderEmail.Text = _appSettings.ModderEmail;
      txtModderHomePage.Text = _appSettings.ModderHome;
      chkAutoBackup.Checked = _appSettings.AutoBackup;
      chkGzip.Checked = _appSettings.UseGZip;
      txtAttachDir.Text = _appSettings.AttachDirectory;
      txtBackupDir.Text = _appSettings.BackupPath;
      txtRofsDir.Text = _appSettings.DefRofsDir;
      txtPatchDir.Text = _appSettings.PatchDirectory;
    }

    private void ObjectLoader( object sender, EventArgs e )
    {
    }

    private void SaveSettings( object sender, EventArgs e )
    {
      _appSettings.ModderName = txtModderName.Text;
      _appSettings.ModderEmail = txtModderEmail.Text; //_appSettings["ModderEmail"] = txtModderEmail.Text;
      _appSettings.ModderHome = txtModderHomePage.Text; //_appSettings["ModderHome"] = txtModderHomePage.Text;
      _appSettings.AutoBackup = chkAutoBackup.Checked; //_appSettings["AutoBackup"] = chkAutoBackup.Checked;
      _appSettings.UseGZip = chkGzip.Checked; //_appSettings["UseGZip"] = chkGzip.Checked;
      _appSettings.AttachDirectory = txtAttachDir.Text; //_appSettings["AttachDirectory"] = txtAttachDir.Text;
      _appSettings.PatchDirectory = txtPatchDir.Text; //_appSettings["PatchDirectory"] = txtPatchDir.Text;
      _appSettings.BackupPath = txtBackupDir.Text;
      _appSettings.DefRofsDir = txtRofsDir.Text;
      _appSettings.Save();
      Hide();
    }

    private void SetupDir(TextBox tb,string startup)
    {
      fbGetDefDirs.SelectedPath = startup;
      fbGetDefDirs.ShowNewFolderButton = true;
      if (fbGetDefDirs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        tb.Text = fbGetDefDirs.SelectedPath;
      }
    }

    private void OnFindDir(object sender, EventArgs e)
    {
      Button btn = (Button) sender;
      TextBox myTb;
      string stPath;
      switch(btn.Name)
      {
        case "btnFindBackup":
          myTb = txtBackupDir;
          stPath = Application.StartupPath;
          break;
        case "btnFindPatch":
          myTb = txtPatchDir;
          stPath = Application.StartupPath;
          break;
        case "btnFindAttach":
          myTb = txtRofsDir;
          stPath = Application.StartupPath;
          break;
        case "btnFindRofs":
          myTb = txtRofsDir;
          stPath = "";
          break;
        default:
          return;
      }
      SetupDir(myTb,stPath);
    }
  }
}
