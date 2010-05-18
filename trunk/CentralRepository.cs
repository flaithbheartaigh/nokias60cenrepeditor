using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NokiaS60CenrepEditor
{
  public delegate CRItem GenCrItem(string line);
  public delegate bool CHK(string x);
  public delegate bool CheckHeadLine(string line,string regex);

  sealed class InteligentHeadCheck
  {
    #region Internal Classes
    /* ************************************************************** */

    private struct ExprItem
    {
      public string expr {get;set;}
      public bool optional { get; set; }
      public bool repetable { get; set; }
    }

    /* ************************************************************** */
    /* ************************************************************** */

    private class Section
    {
      string SectName { get; set; }
      bool optional {get;set;}
      List<ExprItem> regulars = new List<ExprItem>(); /* Opcionális kifejezés kezdete-> o:: */
      /* ***************************************** */
      public Section(string sname,bool opt,List<string> rules)
      {
        SectName = sname;
        optional = opt;
        foreach (string s in rules)
        {
          Regex r = new Regex(@"^(?<opti>o[r]?::)?(?<other>.+)$");
          Match m = r.Match(s);
          ExprItem eItem;
          eItem.expr = m.Groups["other"].Value;
          eItem.optional = m.Groups["opti"].Value.ToString() == "o::";
          regulars.Add(eItem);
        }
      }

      private List<bool> ValidateRules()
      {
      }

      public bool Validate()
      {
      }
    }
    /* ************************************************************** */
    #endregion

  }
  
  public sealed class CRItem
  {
    private Regex re = new Regex(@"^(?<key>0x[0-9a-fA-F]+)\s(?<type>\w+)\s(?<val>\w+)\s(?<other>.+)$");
    public string key {get;set;}
    public string type {get;set;}
    public string val {get;set;}
    public string other { get; set; }
    public CRItem(String line)
    {
      Match mtc = re.Match(line);
      if (mtc.Success)
      {
        key = mtc.Groups["key"].Value;
        type = mtc.Groups["type"].Value;
        val = mtc.Groups["val"].Value;
        other = mtc.Groups["other"].Value;
      }
    }
  }
  /* ********************************************************************************************* */
  class CentralRepository
  {
    private List<string> lines;
    private List<CRItem> items;

    public CentralRepository(string filename)
    {
      StreamReader rd = new StreamReader(filename);
      while ( rd.Peek() >= 0)
      {
        string ln = rd.ReadLine();
        if ( ln != "" )
          lines.Add(ln);
      }
      rd.Dispose();
    }

    public static CentralRepository CreateInst(string filename)
    {
      CentralRepository x = null;
      CheckHeadLine chkh;
      string[] regstring = {@"^cenrep",@"^version 1",@"[owner]",@"\s+([0-9])+",""};
      if (File.Exists(filename))
      {
        x = new CentralRepository(filename);
        int i = 0;
        chkh = (line, reg) =>
        {
          Regex re = new Regex(reg);
          return re.Match(line).Success;
        };
        while (x.lines[i] != "[Main]")
        {
          if ( ! chkh(x.lines[i],regstring[i]) )
            break;
          i++;
        }
        if (x.lines[i] != "[Main]")
        {
          MessageBox.Show("Hibás fejléc!", "HIBA!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return null;
        }
      }
      else
        MessageBox.Show("A megadott fájl nem létezik!", "HIBA!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return x;
    }

  }
 }
