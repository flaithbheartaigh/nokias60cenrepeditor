using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections;

namespace S60.Lib.CenRep
{
  public sealed class XMLPlugin:IS60XMLParser
  {
    private XElement myDoc;
    #region IS60XMLParser Members

    public XElement rootDoc
    {
      get { return myDoc; }
    }

    public XMLPlugin(string filename)
    {
      myDoc = XElement.Load(filename);
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
  }
}
