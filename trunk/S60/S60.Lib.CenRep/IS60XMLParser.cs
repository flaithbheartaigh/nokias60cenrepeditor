using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace S60.Lib.CenRep
{
  
  public interface IS60XMLParser:IEnumerable<XElement>,IEnumerator<XElement>,IList<XElement>
  {
    XElement rootDoc { get; }
    string Filter { get; set; }
    string ElementChain { get; set; }
    List<XElement> SelectElementByAttribute(string selAttrib);
  }
}
