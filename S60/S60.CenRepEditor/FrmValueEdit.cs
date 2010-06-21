using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using S60.CenRepEditor.Properties;

namespace S60.CenRepEditor
{
  public sealed partial class FrmValueEdit : Form
  {
    private ListViewItem _edited;
    public bool GetAccepted { get; private set; }

    public FrmValueEdit(ListViewItem editedItem)
    {
      GetAccepted = false;
      InitializeComponent();
      _edited = editedItem;
      Text = Resources.EditeKey + _edited.SubItems[0].Text;
      txtValue.Text = _edited.SubItems[2].Text;

    }

    private void OnAccept(object sender, EventArgs e)
    {
      _edited.SubItems[2].Text = txtValue.Text;
      GetAccepted = true;
      this.Hide();
    }

    private void OnCancel(object sender, EventArgs e)
    {
      this.Hide();
    }
  }
}
