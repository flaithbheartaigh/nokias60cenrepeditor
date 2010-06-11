using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace S60.Lib.CenRep
{
  static public class XMLExtenders
  {
    public static bool HasAttribute(this XElement xel, string attr)
    {
      try {
        string x = xel.Attribute(attr).Value;
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
  public sealed class XMLPlugin:IS60XMLParser
  {
    public Func<string, List<XElement>> listFilter;
    private XElement nullElement = XElement.Parse(@"<root><ERROR></ERROR></root>");
    private XElement myDoc;
    private string strFilter = "";
    private readonly string strRootEntry;
    private List<XElement> xmlList = new List<XElement>();
    private XElement iCurrent = null;
    private int iPointer = -1;


    #region IS60XMLParser Members

    public XElement rootDoc
    {
      get { return myDoc; }
    }

   public string Filter
    {
      get
      {
        return strFilter;
      }
      set
      {
        strFilter=value;
        RebuildList();
      }
    }
    private void RebuildList()
    {
      if (xmlList.Count > 0)
      {
        xmlList = new List<XElement>();
        iCurrent = null;
        iPointer = -1;
      }
      if (strFilter == "")
      {
        var x = from elem in myDoc.Elements() select elem;
        foreach(XElement xEl in x)
          xmlList.Add(xEl);
      }
      else
      {
        Regex reFilter = new Regex(@"^(?<attr>[^=]+)=(?<valu>.+)$");
        Match maFilter = reFilter.Match(strFilter);
        if (maFilter.Success)
        {
          var x = from elem in myDoc.Elements() select elem;
          foreach (XElement xEl in x)
          {
            if (xEl.HasAttribute(maFilter.Groups["attr"].Value))
            {
              if (xEl.Attribute(maFilter.Groups["attr"].Value).Value == maFilter.Groups["valu"].Value)
                xmlList.Add(xEl);
            }
          }
        }
      }
    }

    public XMLPlugin(string filename,string myRoot)
    {
      myDoc = XElement.Load(filename);
      strRootEntry = myRoot;
    }

    public List<XElement> SelectElementByAttribute(string selAttrib)
    {
      List<XElement> xList = new List<XElement>();
      foreach (XElement xml in xmlList)
      {
        if (xml.HasAttribute(selAttrib))
          xList.Add(xml);
      }
      return xList;
    }

    #endregion

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion


    #region IS60XMLParser Members


    public string ElementChain
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    #endregion

    public XElement this[string index]
    {
      get
      {
        XElement x = nullElement;
        foreach (XElement xel in xmlList)
        {
          if (xel.Attribute("name").Value == index)
          {
            x = xel;
            break;
          }
        }
        return x;
      }
    }

    public XElement this[int index]
    {
      get
      {
        return xmlList[index];
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public XElement this[string attr, string value]
    {
      get
      {
        XElement x = nullElement;
        foreach (XElement xel in xmlList)
        {
          try
          {
            if (xel.Attribute(attr).Value == value)
            {
              x = xel;
              break;
            }
          }
          catch { }
        }
        return x;
      }
    }

    #region IEnumerable<XElement> Members

    IEnumerator<XElement> IEnumerable<XElement>.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IEnumerator<XElement> Members

    public XElement Current
    {
      get { return iCurrent; }
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IEnumerator Members

    object IEnumerator.Current
    {
      get { throw new NotImplementedException(); }
    }

    public bool MoveNext()
    {
      if (iPointer < xmlList.Count)
      {
        iCurrent = xmlList[++iPointer];
        return true;
      }
      return false;
    }

    public void Reset()
    {
      iPointer = -1;
      iCurrent = null;
    }

    #endregion

    #region IList<XElement> Members

    public int IndexOf(XElement item)
    {
      throw new NotImplementedException();
    }

    public void Insert(int index, XElement item)
    {
      xmlList.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      xmlList.RemoveAt(index);
    }


    #endregion

    #region ICollection<XElement> Members

    public void Add(XElement item)
    {
      xmlList.Add(item);
    }

    public void Clear()
    {
      xmlList.Clear();
    }

    public bool Contains(XElement item)
    {
      throw new NotImplementedException();
    }

    public void CopyTo(XElement[] array, int arrayIndex)
    {
      throw new NotImplementedException();
    }

    public int Count
    {
      get { return xmlList.Count; }
    }

    public bool IsReadOnly
    {
      get { throw new NotImplementedException(); }
    }

    public bool Remove(XElement item)
    {
      return xmlList.Remove(item);
    }

    #endregion
  }
}
