using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using S60.Lib.Extenders;

namespace S60.Lib.Sis
{
  public class TSisStream:IDisposable
  {
    public TSisStream()
    {
      iBuffer = null;
      iSize = 0;
      iOffset = 0;
      iDataLength = 0;
    }
    public void Read(byte[] aBuffer, uint aSize)
    {
      MemoryStream ms = new MemoryStream(aBuffer,true);
      ms.Write(iBuffer,(int)iOffset,(int)aSize);
      iOffset+=aSize;
      ms.Close();
    }
    public void Write(byte[] aBuffer, uint aSize)
    {
      reserve(aSize);
      uint i = 0;
      foreach (byte b in aBuffer)
      {
        iBuffer[iOffset + i] = b;
        i++;
      }
      iOffset += (uint)aBuffer.Length;
      if (iOffset > iDataLength)
        iDataLength = (uint)iOffset;
    }

    public void Write(byte bf)
    {
      byte[] buff = new byte[1];
      buff[0] = bf;
      Write(buff, 1);
    }

    public void Write(Int16 aValue)
    {
      byte[] buff;
      buff = aValue.ToByte();
      Write(buff, 2);
    }

    public void Write(Int32 aValue)
    {
      byte[] buff;
      buff = aValue.ToByte();
      Write(buff, 4);
    }

    public uint tell()
    {
      return iOffset;
    }

    public uint length()
    {
      return iDataLength;
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
      return iBuffer;
    }

    public static UInt64 MaxBufferSize()
    {
      throw new NotImplementedException();
    }

    private void reserve(uint aSize)
    {
      if (iOffset+aSize>iSize)
      {
        uint bloat = (uint)(((aSize/iChunk)+1)*iChunk);
        byte[] nBuffer = new byte[iSize+bloat];
        int i = 0;
        foreach(byte bt in iBuffer)
          nBuffer[i++]=bt;
      }
    }

    public void Seek(uint aPos, SeekOrigin aRel)
    {
      uint to;
      switch ( aRel )
      {
        case SeekOrigin.Begin:
          to = aPos;
          break;
        case SeekOrigin.Current:
          to = (uint)iOffset + aPos;
          break;
        case SeekOrigin.End:
          to = iDataLength + aPos;
          break;
        default:
          throw new NotImplementedException();
      }
      if ( to > iSize )
        reserve( to - iSize );
      iOffset = to;
    }

    public bool Import( BinaryReader aFile, ref uint filesize )
    {
      try
      {
        int pointer = 0;
        int readed = 0;
        reserve( ( uint ) aFile.BaseStream.Length );
        filesize = ( uint ) aFile.BaseStream.Length;
        while ( ( readed = aFile.Read( iBuffer, pointer, iChunk ) ) == iChunk )
          pointer += iChunk;
        return true;
      }
      catch 
        {
          return false;
        }
    }

    public bool Export( BinaryWriter aFile )
    {
      try
      {
        aFile.Write( iBuffer );
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void Reset()
    {
      iBuffer = null;
      iSize = 0;
      iDataLength = 0;
      iOffset = 0;
    }

    private byte[] iBuffer;
    private uint iSize;
    private uint iDataLength;
    private uint iOffset;
    private static int iChunk = 2048;

  
#region IDisposable Members

    public void  Dispose()
    {
 	    iBuffer = null;
      GC.SuppressFinalize(this);
    }

#endregion
  }


}
