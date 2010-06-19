using System;
using System.Windows.Forms;
using S60.CenRepEditor.Properties;

namespace S60.CenRepEditor
{
  public partial class frmSettings : Form
  {
    private Settings _appSettings;
    public frmSettings(Settings appsettings)
    {
      InitializeComponent();
      _appSettings = appsettings;
      txtModderName.Text = _appSettings.ModderName;
      txtModderEmail.Text = _appSettings.ModderEmail;
      txtModderHomePage.Text = _appSettings.ModderHome;
      chkAutoBackup.Checked = _appSettings.AutoBackup;
    }

    private void ObjectLoader( object sender, EventArgs e )
    {
    }

    private void SaveSettings( object sender, EventArgs e )
    {
      _appSettings["ModderName"] = txtModderName.Text;
      _appSettings["ModderEmail"] = txtModderEmail.Text;
      _appSettings["ModderHome"] = txtModderHomePage.Text;
      _appSettings["AutoBackup"] = chkAutoBackup.Checked;
      _appSettings.Save();
    }
  }
}
