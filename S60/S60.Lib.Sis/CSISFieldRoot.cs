using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace S60.Lib.Sis
{
  public abstract class CSISFieldRoot
  {
    public CSISFieldRoot()
    {
    }
    public abstract void Read(TSisStream aFile, Int64 aContainerSize, Enumerators.TFieldType aArrayType);
    public abstract void Skip(TSisStream aFile, Int64 aContainerSize);
    public abstract void Write(TSisStream aFile, bool aIsArrayElement);
    public abstract void Verify(UInt32 aLanguages);
    public abstract void MakeNeat();
    public abstract bool WasteOfSpace();
    public virtual Int64 ByteCount(bool aInsideArray)
    {
      return 0;
    }
    public abstract Int64 ByteCountWithHeader(bool aInsideArray);
    public abstract void Dump(Stream aFile, int aLevel);
    public abstract void AddPackageEntry(Stream aStream, bool aVerbose);
    public abstract string Name();
    public abstract void CalculateCRC(out Int32 aCrc, bool aIsArrayElement);
    public abstract void CreateDefects();
    public abstract void SkipOldWriteNew(TSisStream aFile);
    public abstract int PreHeaderPos();
    public abstract int PostHeaderPos();
    public abstract UInt32 Crc(bool aIsArrayElement);
    public virtual UInt32 Crc()
    {
      return Crc(false);
    }



  }
}
