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
      UseExternalTools.ExtractImage(Directory.GetCurrentDirectory(), Directory.GetCurrentDirectory() + @"\ROFS2\6_code.bin", Directory.GetCurrentDirectory() + @"\ROFSROOT");
    }
  }
}
