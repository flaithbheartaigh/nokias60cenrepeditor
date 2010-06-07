using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace S60.CenRepEditor
{
  public interface IS60XMLParser:IEnumerable
  {
    XElement rootDoc { get; }
    List<XElement> SelectElementByAttribute(string selAttrib);
  }
}
