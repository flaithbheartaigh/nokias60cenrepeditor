using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S60.PluginInterface
{
  [AttributeUsage(AttributeTargets.Class)]
  public class PluginAttributes: System.Attribute
  {
    private string m_description;
    public PluginAttributes(string description)
    {
      m_description = description;
    }
    public string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }
  }
}
