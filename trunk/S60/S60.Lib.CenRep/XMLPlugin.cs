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
    private XElement nullElement = XElement.Parse(@"<root><ERROR></ERROR></root>");
    private XElement myDoc;
    private string strFilter = "";
    private readonly string strRootEntry;
    private List<XElement> xmlList = new List<XElement>();


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
        xmlList = new List<XElement>();
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
      throw new NotImplementedException();
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

    #region IEnumerator Members

    public object Current
    {
      get { throw new NotImplementedException(); }
    }

    public bool MoveNext()
    {
      throw new NotImplementedException();
    }

    public void Reset()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IList Members

    public int Add(object value)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public bool Contains(object value)
    {
      throw new NotImplementedException();
    }

    public int IndexOf(object value)
    {
      throw new NotImplementedException();
    }

    public void Insert(int index, object value)
    {
      throw new NotImplementedException();
    }

    public bool IsFixedSize
    {
      get { throw new NotImplementedException(); }
    }

    public bool IsReadOnly
    {
      get { throw new NotImplementedException(); }
    }

    public void Remove(object value)
    {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new NotImplementedException();
    }


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
    }

    public int Count
    {
      get
      {
        return xmlList.Count;
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

    #endregion

    #region ICollection Members

    public void CopyTo(Array array, int index)
    {
      throw new NotImplementedException();
    }

    public bool IsSynchronized
    {
      get { throw new NotImplementedException(); }
    }

    public object SyncRoot
    {
      get { throw new NotImplementedException(); }
    }

    #endregion


    #region IList Members


    object IList.this[int index]
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

    #region ICollection Members


    int ICollection.Count
    {
      get { throw new NotImplementedException(); }
    }

    #endregion
  }
}
