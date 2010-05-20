using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using S60.Tools.MIF;

namespace S60
{
  public partial class frmMIFMaker : Form
  {
    private MIFWriterClass myMif = new MIFWriterClass();
    private Dictionary<int, string> SvgDict = new Dictionary<int, string>();
    public frmMIFMaker()
    {
      InitializeComponent();
    }

    private void OnAppendButton(object sender, EventArgs e)
    {
      dlgOpenSVG.Filter = "SVG grafika (*.SVG)|*.svg|JPG kép (*.jpg,*.jpeg)|*.jpg;*.jpeg|Minden támogatott formátum|*.jpg;*.jpeg;*.svg;*.*";
      if (dlgOpenSVG.ShowDialog() == DialogResult.OK)
      {
        string Fn = Path.GetFileName(dlgOpenSVG.FileName);
        lstPicFiles.Items.Add(Fn);
        if (Path.GetExtension(Fn) == "svg")
        {
          SvgDict.Add(lstPicFiles.Items.Count - 1, dlgOpenSVG.FileName);
        }
        else
        {
          Bitmap xImage = new Bitmap(Fn);
          int w = xImage.Width;
          int h = xImage.Height;
          xImage.Dispose();
          SvgDict.Add(lstPicFiles.Items.Count-1, myMif.Jpeg2SVG(dlgOpenSVG.FileName, w, h));
        }
      }
    }

    private void OnCreateButton(object sender, EventArgs e)
    {
      lblCsomag.Visible = true;
      pbMaking.Visible = true;
      pbMaking.Maximum = lstPicFiles.Items.Count;
      pbMaking.Minimum = 0;
      if (!chkSplitPics.Checked)
      {
        foreach (string fn in lstPicFiles.Items)
        {
          string fullpath = SvgDict[lstPicFiles.Items.IndexOf(fn)];
          StreamReader xReader = new StreamReader(fullpath);
          string svgstring = xReader.ReadToEnd();
          xReader.Dispose();
          myMif.AddFile(svgstring);
          pbMaking.Increment(1);
        }
        dlgSaveMIF.AddExtension = true;
        dlgSaveMIF.Filter = "Symbian Multi Icon File (*.mif)|*.mif";
        if (dlgSaveMIF.ShowDialog() == DialogResult.OK)
        {
          myMif.WriteMIFtoFile(dlgSaveMIF.FileName);
        }
        dlgSaveMIF.Dispose();
      }
      else
      {
        if (!Directory.Exists(Application.StartupPath + @"\MIF"))
          Directory.CreateDirectory(Application.StartupPath + @"\MIF");
        //dlgSaveFolder.RootFolder = Application.StartupPath + @"\MIF";
        string mifname;
        int i =0;
        foreach (string fn in lstPicFiles.Items)
        {
          mifname =  Path.GetFileNameWithoutExtension(fn)+".mif";
          myMif = new MIFWriterClass();
          myMif.AddFile(SvgDict[lstPicFiles.Items.IndexOf(fn)]);
        };
      }
      lblCsomag.Visible = false;
      pbMaking.Visible = false;
    }

    private void OnDeleteButton(object sender, EventArgs e)
    {

    }
  }
}
