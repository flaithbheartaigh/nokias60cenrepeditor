using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace S60.Lib.Sis
{
  public class CSISFieldRoot
  {
    public CSISFieldRoot()
    {
    }
    virtual void Read(TSisStream aFile, Int64 aContainerSize, Enumerators.TFieldType aArrayType);
    virtual void Skip(TSisStream aFile, Int64 aContainerSize);
    virtual void Write(TSisStream aFile, bool aIsArrayElement);
    virtual void Verify(UInt32 aLanguages);
    virtual void MakeNeat();
    virtual bool WasteOfSpace();
    virtual Int64 ByteCount(bool aInsideArray)
    {
      return 0;
    }
    virtual Int64 ByteCountWithHeader(bool aInsideArray);
    virtual void Dump(Stream aFile, int aLevel);
    virtual void AddPackageEntry(Stream aStream, bool aVerbose);
    virtual string Name();
    virtual void CalculateCRC(out Int32 aCrc, bool aIsArrayElement);
    virtual void CreateDefects();
    virtual void SkipOldWriteNew(TSisStream aFile);
    virtual int PreHeaderPos();
    virtual int PostHeaderPos();
    virtual UInt32 Crc(bool aIsArrayElement);
    virtual UInt32 Crc()
    {
      return Crc(false);
    }



  }
}
