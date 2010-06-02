using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace S60.Lib.Sis
{
  public class TSisStream
  {
    public TSisStream()
    {
    }
    public void Read(byte[] aBuffer, uint aSize)
    {
      throw new NotImplementedException();
    }
    public void Write(byte[] aBuffer, uint aSize)
    {
      throw new NotImplementedException();
    }

    public int tell()
    {
      throw new NotImplementedException();
    }

    public uint length()
    {
      throw new NotImplementedException();
    }

    public bool import(Stream aFile, UInt64 filesize)
    {
      throw new NotImplementedException();
    }

    public void reset()
    {
      throw new NotImplementedException();
    }
    public byte[] data()
    {
      throw new NotImplementedException();
    }

    public static UInt64 MaxBufferSize()
    {
      throw new NotImplementedException();
    }

    private byte[] iBuffer;
    private uint iSize;
    private uint iDataLength;
    private int iOffset;
    private static int iChunk;
  }
}
