using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIFWriter;
using System.IO;

namespace MIFTEST
{
  public class Program
  {
    static void Main(string[] args)
    {
      Int32 x = 0x01000200;
      byte[] tmp = x.ToByte();
      foreach (byte i in tmp)
        Console.WriteLine("{0}", i);
      MIFWriterClass xm = new MIFWriterClass();
      xm.AddFileContent("Valami", false);
      xm.AddFileContent("Másvalami");
      xm.WriteMIFtoFile("teszt.mif");
    }
  }
}
