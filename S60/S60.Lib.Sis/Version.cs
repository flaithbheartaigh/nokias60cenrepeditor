using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S60.Lib.Sis
{
  public class TVersion
  {
    public const int KIrrelevant = -1;
    
    private Int32 iMajor;
    private Int32 iMinor;
    private Int32 iBuild;

    public TVersion()
    {
      iMajor = KIrrelevant;
      iMinor = KIrrelevant;
      iBuild = KIrrelevant;
    }

    public TVersion(Int32 aMajor, Int32 aMinor, Int32 aBuild)
    {
      iMajor = aMajor;
      iMinor = aMinor;
      iBuild = aBuild;
    }

    public TVersion(TVersion aVersion)
    {
      iMajor = aVersion.Major;
      iMinor = aVersion.Minor;
      iBuild = aVersion.Build;
    }

    public Int32 Major
    {
      get
      {
        return iMajor;
      }
    }

    public Int32 Minor
    {
      get
      {
        return iMinor;
      }
    }

    public Int32 Build
    {
      get
      {
        return iBuild;
      }
    }
  }
}
