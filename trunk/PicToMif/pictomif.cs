using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MIFWriter;
using System.IO;

namespace PicToMif
{ 
  class pictomif
  {
    private static void start_convert(string[] args)
    {
      string source = args[0];
      string dest = Path.GetFileNameWithoutExtension(source)+".mif";
      string form = Path.GetExtension(source);
      Console.WriteLine("Forrás   : {0}",source);
      Console.WriteLine("Cél      : {0}", dest);
      Console.WriteLine("Formátum : {0}", form);
      Console.WriteLine();
      if (!File.Exists(source))
      {
        Console.WriteLine("HIBA! A megadott forrásfájl nem létezik!!!!");
        return;
      }
      MIFWriterClass myMIF = new MIFWriterClass();
      myMIF.AddFile(source);
      myMIF.WriteMIFtoFile(dest);
      return;
    }

    static void Main(string[] args)
    {
      Assembly myAss = Assembly.Load("pictomif");
      AssemblyName aName = myAss.GetName();
      Console.WriteLine("PicToMIF converter v{0} (c) Jakab András 2010", aName.Version.ToString());
      if (args.Length < 1)
      {
        Console.WriteLine("Használat:");
        Console.WriteLine("   pictomif <forrás> [cél]");
        Console.WriteLine();
        Console.WriteLine("Támogatott formátumok: SVG, JPG, PNG");
      }
      else
        start_convert(args);
    }
  }
}
