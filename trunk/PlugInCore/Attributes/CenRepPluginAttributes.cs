using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlugInCore.Attributes
{
  [AttributeUsage(AttributeTargets.Class)]
  public class CenRepPluginAttributes : Attribute
  {
    public CenRepPluginAttributes(string description)
    {
      m_description = description;
    }
    
    private string m_description;

    public string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }
  }
}
