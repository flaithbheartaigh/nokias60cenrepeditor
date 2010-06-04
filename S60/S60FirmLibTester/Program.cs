using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using S60.Lib.Firmware;
using System.IO;

namespace S60FirmLibTester
{
  class Program
  {
    static void FirmTest(string[] args)
    { 
      FwFile myfirm = new FwFile();
      myfirm.Test(args.Length >1 ? args[2] : Directory.GetCurrentDirectory() + @"\rofs3.fpsx");
      string binfile = Directory.GetFiles( Directory.GetCurrentDirectory() + @"\ROFS2", "?_code.bin" )[0];
      UseExternalTools.ExtractImage(Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory() + @"\ROFS2"+binfile, Directory.GetCurrentDirectory() + @"\ROFSROOT");
      if ( File.Exists( "test.hex" ) )
        File.Delete( "test.hex" );
      BinaryWriter bw = new BinaryWriter( new FileStream( "test.hex", FileMode.CreateNew, FileAccess.Write ) );
      bw.Write( ( int ) 0x01020304 );
      bw.Dispose();
    }

    static void ObeyTest( string[] args )
    {
      ObeyManager.writeObey( "test.oby", "fucking.img","", "0x10000000",  @"D:\FirmWare SDK\NokiaEditor Beta6\rofs2" );
      UseExternalTools.BuildRofsImage( Directory.GetCurrentDirectory(), "test.oby" );
    }

    static void Main(string[] args)
    {
      if (args.Length>0)
      {
        switch (args[0])
        {
          case "firmtest":
            FirmTest(args);
            break;
          case "obeytest":
            ObeyTest(args);
            break;
        }
      }
      else 
        ObeyTest(args);
    }
  }
}
