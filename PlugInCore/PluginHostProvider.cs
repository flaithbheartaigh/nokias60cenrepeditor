using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using S60.Plugins;
using System.Reflection;
using S60.Plugins.InterFaces;
using S60.Plugins.Attributes;

namespace PlugInCore
{
  public class PluginHostProvider
  {
    private static List<PluginHost> m_plugins;

    public static List<PluginHost> Plugins
    {
      get
      {
        if (null == m_plugins)
          Reload();
        return m_plugins;
      }
    }

    public static void Reload()
    {
      if (null == m_plugins)
        m_plugins = new List<PluginHost>();
      else
        m_plugins.Clear();

      m_plugins.Add(new PluginHost());

      List<Assembly> PluginAssemblies = LoadPluginAssemblies();
      List<ICenRepPlugins> loadedPlugins = GetPlugins(PluginAssemblies);

      foreach (ICenRepPlugins plugged in loadedPlugins)
        m_plugins.Add(new PluginHost(plugged));

    }

    private static List<Assembly> LoadPluginAssemblies()
    {
      DirectoryInfo dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
      FileInfo[] files = dInfo.GetFiles("*.dll");

      List<Assembly> pluginAssemblyList = new List<Assembly>();

      if (null != files)
      {
        foreach (FileInfo file in files)
        {
          pluginAssemblyList.Add(Assembly.LoadFile(file.FullName));
        }
      }
      return pluginAssemblyList;
    }

    static List<ICenRepPlugins> GetPlugins(List<Assembly> assemblies)
    {
      List<Type> availType = new List<Type> ();
      foreach (Assembly currAssembly in assemblies)
      {
        availType.AddRange(currAssembly.GetTypes());
      }
      List<Type> pluginList = availType.FindAll(delegate(Type t)
      {
        List<Type> interfaceTypes = new List<Type> (t.GetInterfaces());
        object[] arr = t.GetCustomAttributes(typeof(CenRepPluginAttributes),true);
        return !(arr == null || arr.Length == 0) && interfaceTypes.Contains(typeof(ICenRepPlugins));
      });

      return pluginList.ConvertAll<ICenRepPlugins>(delegate(Type t) { return Activator.CreateInstance(t) as ICenRepPlugins; });
    }
  }
}
