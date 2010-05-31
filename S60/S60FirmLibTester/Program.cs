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
    static void Main(string[] args)
    {
      FwFile myfirm = new FwFile();
      myfirm.Test(args.Length >0 ? args[1] : Directory.GetCurrentDirectory() + @"\rofs3.fpsx");
      string binfile = Directory.GetFiles( Directory.GetCurrentDirectory() + @"\ROFS2", "?_code.bin" )[0];
      UseExternalTools.ExtractImage(Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory() + @"\ROFS2"+binfile, Directory.GetCurrentDirectory() + @"\ROFSROOT");
      if ( File.Exists( "test.hex" ) )
        File.Delete( "test.hex" );
      BinaryWriter bw = new BinaryWriter( new FileStream( "test.hex", FileMode.CreateNew, FileAccess.Write ) );
      bw.Write( ( int ) 0x01020304 );
      bw.Dispose();
    }
  }
}
