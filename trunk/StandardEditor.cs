using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NokiaS60CenrepEditor
{
  public partial class StandardEditor : Form
  {

    private string FN;
    public StandardEditor(string strFN)
    {
      InitializeComponent();
      FN = strFN;
      lblFileName.Text = FN;
      if (System.IO.File.Exists(FN))
      {
        StreamReader fCenrep = System.IO.File.OpenText(FN);
        string bf = "";
        while ((bf=fCenrep.ReadLine()) != null )
        {
          txtEditor.Text = txtEditor.Text + bf + "\r\n";
        }
        fCenrep.Close();
        txtEditor.Modified = false;
      }
    }

    public void SaveFile()
    {
      if (txtEditor.Modified)
      {
        if (!File.Exists(Application.StartupPath + @"\Temp\Backup\" + System.IO.Path.GetFileName(lblFileName.Text)))
          System.IO.File.Copy(lblFileName.Text, Application.StartupPath + @"\Temp\Backup\" + System.IO.Path.GetFileName(lblFileName.Text));
        //Változás flag beállítás -> megírni
        
        StreamWriter sw = System.IO.File.CreateText(lblFileName.Text);
        sw.Write(txtEditor.Text);
        sw.Flush();
        sw.Close();
      }
      else
      {
      }
    }

    private void ExitStdEditor(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      SaveFile();
    }

  }
}
