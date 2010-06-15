using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace S60.Lib.CenRep
{
  static public class XMLExtenders
  {
    public static bool HasAttribute(this XElement xel, string attr)
    {
      try {
// ReSharper disable PossibleNullReferenceException
#pragma warning disable 168
        string x = xel.Attribute(attr).Value;
        if (x == null) throw new NotImplementedException();
#pragma warning restore 168
// ReSharper restore PossibleNullReferenceException
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
    public string StrRootEntry
    {
      get { return _strRootEntry; }
    }

    public Func<string, List<XElement>> ListFilter { get; set;}
    private readonly XElement _nullElement = XElement.Parse(@"<root><ERROR></ERROR></root>");
    private readonly XElement _myDoc;
    private string _strFilter = "";
    private readonly string _strRootEntry;
    private List<XElement> _xmlList = new List<XElement>();
    private XElement _iCurrent;
    private int _iPointer = -1;
    private readonly string _fileName;


    #region IS60XMLParser Members

    public XElement rootDoc
    {
      get { return _myDoc; }
    }

   public string Filter
    {
      get
      {
        return _strFilter;
      }
      set
      {
        _strFilter=value;
        RebuildList();
      }
    }
    private void RebuildList()
    {
      if (_xmlList.Count > 0)
      {
        _xmlList = new List<XElement>();
        _iCurrent = null;
        _iPointer = -1;
      }
      if (_strFilter == "")
      {
        var x = from elem in _myDoc.Elements() select elem;
        foreach(XElement xEl in x)
          _xmlList.Add(xEl);
      }
      else
      {
        Regex reFilter = new Regex(@"^(?<attr>[^=]+)=(?<valu>.+)$");
        Match maFilter = reFilter.Match(_strFilter);
        if (maFilter.Success)
        {
          var x = from elem in _myDoc.Elements() select elem;
          foreach ( XElement xEl in
            x.Where( xEl => xEl.HasAttribute( maFilter.Groups["attr"].Value ) ).Where( xEl => xEl.Attribute( maFilter.Groups["attr"].Value ).Value == maFilter.Groups["valu"].Value ) )
          {
            _xmlList.Add(xEl);
          }
        }
      }
    }

    public XMLPlugin(string filename,string myRoot)
    {
      _iCurrent = null;
      _myDoc = XElement.Load(filename);
      _fileName = filename;
      _strRootEntry = myRoot;
      ListFilter = defaultFilter;
    }

    public void Save()
    {
      _myDoc.RemoveNodes();
      foreach ( XElement element in _xmlList )
      {
        _myDoc.Add( element );
      }
      _myDoc.Save( _fileName );
      RebuildList();
    }

    public List<XElement> SelectElementByAttribute(string selAttrib)
    {
      return _xmlList.Where(xml => xml.HasAttribute(selAttrib)).ToList();
    }

    #endregion

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      return _xmlList.GetEnumerator();
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
        XElement x = _nullElement;
        foreach (XElement xel in _xmlList)
        {
          if (xel != null)
            if (xel.Attribute("name").Value == index)
            {
              x = xel;
              break;
            }
        }
        return x;
      }
    }

// ReSharper disable InconsistentNaming
    private static List<XElement> defaultFilter(string defFilter)
// ReSharper restore InconsistentNaming
    {
      List<XElement> newList = new List<XElement>();

      return newList;
    }

    public XElement this[int index]
    {
      get
      {
        return _xmlList[index];
      }
      set
      {
        _xmlList[index] = value;
      }
    }

    public XElement this[string attr, string value]
    {
      get
      {
        XElement x = _nullElement;
        foreach (XElement xel in _xmlList)
        {
          try
          {
            if (xel != null)
              if (xel.Attribute(attr).Value == value)
              {
                x = xel;
                break;
              }
          }
// ReSharper disable EmptyGeneralCatchClause
          catch { }
// ReSharper restore EmptyGeneralCatchClause
        }
        return x;
      }
    }

    #region IEnumerable<XElement> Members

    IEnumerator<XElement> IEnumerable<XElement>.GetEnumerator()
    {
      return _xmlList.GetEnumerator();
    }

    #endregion

    #region IEnumerator<XElement> Members

    public XElement Current
    {
      get { return _iCurrent; }
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
      if (_iPointer < _xmlList.Count)
      {
        _iCurrent = _xmlList[++_iPointer];
        return true;
      }
      return false;
    }

    public void Reset()
    {
      _iPointer = -1;
      _iCurrent = null;
    }

    #endregion

    #region IList<XElement> Members

    public int IndexOf(XElement item)
    {
      return _xmlList.IndexOf( item );
    }

    public void Insert(int index, XElement item)
    {
      _xmlList.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      _xmlList.RemoveAt(index);
    }


    #endregion

    #region ICollection<XElement> Members

    public void Add(XElement item)
    {
      if ( !_xmlList.Contains( item ) )
        _xmlList.Add( item );
    }

    public void Clear()
    {
      _xmlList.Clear();
    }

    public bool Contains(XElement item)
    {
      return _xmlList.Contains( item );
    }

    public void CopyTo(XElement[] array, int arrayIndex)
    {
      _xmlList.CopyTo( array,arrayIndex );
    }

    public int Count
    {
      get { return _xmlList.Count; }
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public bool Remove(XElement item)
    {
      return _xmlList.Remove(item);
    }

    #endregion
  }
}
