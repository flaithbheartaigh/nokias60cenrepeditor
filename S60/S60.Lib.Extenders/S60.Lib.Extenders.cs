using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Resources;

namespace S60.Lib.Extenders
{
  static public class Extenders
  {
    static public string[] ReadAllLines(this StreamReader reader)
    {
      List<string> lines = new List<string>();
      while (reader.Peek() > 0)
      {
        string ln = reader.ReadLine();
        lines.Add(ln);
      }
      return lines.ToArray();
    }
    static public string[] ReadAllLines(this StreamReader reader, Func<string, bool> delFilter)
    {
      List<string> lines = new List<string>();
      while (reader.Peek() > 0)
      {
        string ln = reader.ReadLine();
        if (delFilter(ln))
          lines.Add(ln);
      }
      return lines.ToArray();
    }
    public static byte[] ToByte(this string str)
    {
      byte[] tmp = { };
      char[] chrtmp = str.ToCharArray();
      int i = 0;
      Array.Resize<byte>(ref tmp, str.Length);
      foreach (char ch in chrtmp)
      {
        tmp[i] = (byte)ch;
        i++;
      }
      return tmp;
    }
    public static byte[] ToByte(this Int32 szam)
    {
      byte[] tmp = { 0, 0, 0, 0 };
      tmp[0] = (byte)(szam & 0xff);
      tmp[1] = (byte)((szam >> 8) & 0xff);
      tmp[2] = (byte)((szam >> 16) & (Int32)0xff);
      tmp[3] = (byte)(szam >> 24);
      return tmp;
    }
    public static byte[] Append(this byte[] x, byte[] y)
    {
      int oldLength = x.Length;
      Array.Resize<byte>(ref x, oldLength + y.Length);
      for (int i = 0; i < y.Length; i++)
        x[oldLength + i] = y[i];
      return x;
    }

  }
}
