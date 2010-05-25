using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace S60.Plugins.MenuEditor
{
  public partial class frmMenuEditor : Form
  {
    enum VIEW { TREE_VIEW = 0 };
    string XMLInputFile = null;
    string FileSize = "";
    string WorkingDirectory = Directory.GetCurrentDirectory();
    string OrigFormTitle = "";
    bool bFileLoaded = false;
    int CurrentView = (int)VIEW.TREE_VIEW;
    Object NodeTag = null;
    TreeNode RootNode = null;
    Point ClickedPoint = new Point(0, 0);
    ArrayList TreeNodeArray = new ArrayList();
    ImageList tr_il = new ImageList();
    ImageList tb_il = new ImageList();

    public frmMenuEditor()
    {
      InitializeComponent();
    }


    public void AddMenuFolder(TreeNode xNode)
    {
      treMenu.Nodes.Add(xNode);
    }

    private void procItemSelected( object sender, EventArgs e )
    {

    }
  }
}
