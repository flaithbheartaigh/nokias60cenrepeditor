using System;
using System.Windows.Forms;

namespace S60.CenRepEditor
{
  public partial class frmSettings : Form
  {
// ReSharper disable FieldCanBeMadeReadOnly.Local
    private CenRepEditorSettings _mySettings = new CenRepEditorSettings();
// ReSharper restore FieldCanBeMadeReadOnly.Local
    public string ModderName
    {
      get
      {
        return txtModderName.Text;
      }
      set
      {
        txtModderName.Text = value;
      }
    }
    public frmSettings()
    {
      InitializeComponent();
    }

    private void ObjectLoader( object sender, EventArgs e )
    {
      txtModderName.DataBindings.Add( "ModderName", _mySettings, "ModderName" );
      DataBindings.Add( "txtModderEmail", _mySettings, "ModderEmail" );
      DataBindings.Add( "txtModderHomePage", _mySettings, "ModderHome" );
      DataBindings.Add( "chkAutoBackup", _mySettings, "AutoBackup" );
    }

    private void SaveSettings( object sender, EventArgs e )
    {
      _mySettings.Save();
    }
  }
}
