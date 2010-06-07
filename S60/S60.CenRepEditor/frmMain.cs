using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace S60.CenRepEditor
{
  public partial class frmMain : Form
  {
    string CenRepDir = "";
    public frmMain()
    {
      InitializeComponent();
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
        lstCenRep.Items.Add(tlCenRep);
      }
    }
  }
}
