using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;



namespace S60.Plugins
{
  internal delegate string tostr(int i);

  enum EBlockType
  {
    Code = 0x54,
    Data = 0x5D
  }

  enum EContentType
  {
    PlainCode = 0x17,
    SignedCode = 0x2E,
    PlainData = 0x27,
    SignedData = 0x28
  }

  public enum EMemoryType
  {
    CMT,
    APE
  }

  static class Generator
  {
    public static void Generate()
    {
    }
  }

  abstract class TBase
  {
    public abstract void Read(BinaryReader br);
    public abstract void Write(BinaryWriter bw);
  }


  class THeader : TBase
  {
    public byte signature;
    public UInt32 headerSize;
    public UInt32 totBlocks;
    public byte[] unkn;

    public override void Read(BinaryReader br)
    {
      signature = br.ReadByte();
      headerSize = Utils.SwapBytes(br.ReadUInt32());
      totBlocks = Utils.SwapBytes(br.ReadUInt32());

      unkn = new byte[headerSize - 4];
      unkn = br.ReadBytes(unkn.Length);
    }
    public override void Write(BinaryWriter bw)
    {
      throw new NotImplementedException();
    }
  }


  class TBlock : TBase
  {
    public EBlockType blockType;
    public byte const01;
    public EContentType contentType;
    public byte blockSize;
    public TBlockHeader blockHeader;
    public byte blockChecksum8;
    public byte[] content;
    internal Func<int, string> Field_00;

    public TBlock()
    {
    }

    public override void Read(BinaryReader br)
    {
      blockType = (EBlockType)br.ReadByte();
      const01 = br.ReadByte();
      Debug.Assert(const01 == 01, "Const != 01");

      contentType = (EContentType)br.ReadByte();
      blockSize = br.ReadByte();

      // Useful to check for errors
      long currPos = br.BaseStream.Position;
      blockHeader = TBlockHeader.Factory(br, blockType, contentType);
      blockHeader.Read(br);
      if (br.BaseStream.Position != currPos + blockSize)
      {
        long missing = (currPos + blockSize - br.BaseStream.Position);
        Debug.Assert(false, "Error Reading Header! ", missing + " bytes left.");
        // Fixes the offset and continue...
        br.BaseStream.Seek(missing, SeekOrigin.Current);
      }

      blockChecksum8 = br.ReadByte();
      content = br.ReadBytes((int)blockHeader.contentSize);
    }
    public override void Write(BinaryWriter bw)
    {
      throw new NotImplementedException();
    }
  }


  abstract class TBlockHeader : TBase
  {
    public UInt32 contentSize = 0;
    public ushort contentChecksum16;
    public EMemoryType flashMemory;
    public uint location;
    public uint contentLength;

    public static TBlockHeader Factory(BinaryReader br, EBlockType blockType, EContentType contentType)
    {
      switch (blockType)
      {
        case EBlockType.Code:
          {
            switch (contentType)
            {
              case EContentType.PlainCode:
                return new TCodeBlock();
              case EContentType.SignedCode:
                return new TSignedCodeBlock();
            }
            throw new Exception("Unknown Code Content");
          }
        case EBlockType.Data:
          {
            switch (contentType)
            {
              case EContentType.PlainData:
                return new TDataBlock();
              case EContentType.SignedData:
                return new TSignedDataBlock();
            }
            throw new Exception("Unknown Data Content");
          }
      }
      throw new Exception("Unknown block");
    }
  }


  class TCodeBlock : TBlockHeader
  {
    public byte processorType;
    public UInt16 unkn;         // N95 = 0x0001   5800 = 0x0003
    public UInt16 maybe_crc;
    public byte const01;
    // size
    public new UInt32 location;

    public override void Read(BinaryReader br)
    {
      processorType = br.ReadByte();
      unkn = br.ReadUInt16();

      maybe_crc = Utils.SwapBytes(br.ReadUInt16());
      const01 = br.ReadByte();
      Debug.Assert(const01 == 01, "Const != 01");

      contentSize = Utils.SwapBytes(br.ReadUInt32());
      location = Utils.SwapBytes(br.ReadUInt32());
    }
    public override void Write(BinaryWriter bw)
    {
      throw new NotImplementedException();
    }
  }


  class TSignedCodeBlock : TBlockHeader
  {
    public byte[] unknSigned;
    // size
    public new UInt32 location;

    public override void Read(BinaryReader br)
    {
      unknSigned = br.ReadBytes(17);
      contentSize = Utils.SwapBytes(br.ReadUInt32());
      location = Utils.SwapBytes(br.ReadUInt32());
    }
    public override void Write(BinaryWriter bw)
    {
      throw new NotImplementedException();
    }
  }


  class TDataBlock : TBlockHeader
  {
    public byte[] hash;             // 16
    public byte[] hashCRC;          // 4 
    public string description;      // 12
    public byte processorType;
    public byte[] unkn;             // 4
    // size
    public new UInt32 location;

    public override void Read(BinaryReader br)
    {
      hash = br.ReadBytes(16);
      hashCRC = br.ReadBytes(4);
      byte[] descrBytes = br.ReadBytes(12);
      description = ASCIIEncoding.ASCII.GetString(descrBytes);
      processorType = br.ReadByte();
      unkn = br.ReadBytes(4);
      contentSize = Utils.SwapBytes(br.ReadUInt32());
      location = Utils.SwapBytes(br.ReadUInt32());
    }

    public override void Write(BinaryWriter bw)
    {
      throw new NotImplementedException();
    }
  }

  class TSignedDataBlock : TDataBlock
  {
    public byte[] unknSigned;

    public override void Read(BinaryReader br)
    {
      base.Read(br);
      unknSigned = br.ReadBytes(0x16);
    }
  }

  class TBlockType17 : TBlockHeader
  {
    public byte const01;
    public ushort unkn2;
    Func<uint, uint> sw = (num1) => (uint)(((((num1 & -16777216) >> 0x18) | ((num1 & 0xff0000) >> 8)) | ((num1 & 0xff00) << 8)) | ((num1 & 0xff) << 0x18));
    static TBlockType17()
    {
      Generator.Generate();
    }

    public TBlockType17()
    {
    }

    public override void Read(BinaryReader br)
    {
      //throw new NotImplementedException();
      flashMemory = (EMemoryType)br.ReadByte();
      unkn2 = br.ReadUInt16();
      contentChecksum16 = br.ReadUInt16();
      const01 = br.ReadByte();
      if (const01 != 1)
      {
        throw new NotImplementedException();
      }
      contentLength = sw(br.ReadUInt32());
      location = sw(br.ReadUInt32());
    }

    public override void Write(BinaryWriter bw)
    {
      //throw new NotImplementedException();
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      bw.Write(const01);
      bw.Write(sw(contentLength));
      bw.Write(sw(location));
    }
  }

  class TBlockType2E : TBlockHeader
  {
    public string description;
    public ushort unkn2;
    Func<uint, uint> sw = (num1) => (uint)(((((num1 & -16777216) >> 0x18) | ((num1 & 0xff0000) >> 8)) | ((num1 & 0xff00) << 8)) | ((num1 & 0xff) << 0x18));
    Func<string, byte[]> stob = (st) =>
      {
        char[] ch = st.ToCharArray();
        byte[] rt = new byte[ch.Length];
        for (int j = 0; j < ch.Length; j++)
          rt[j] = (byte)ch[j];
        return rt;
      };
    public TBlockType2E()
    {
    }

    public override void Read(BinaryReader br)
    {
      //throw new NotImplementedException();
      byte[] buffer;
      flashMemory = (EMemoryType)br.ReadByte();
      unkn2 = br.ReadUInt16();
      contentChecksum16 = br.ReadUInt16();
      buffer = br.ReadBytes(12);
      description = buffer.ToString();
      contentLength=sw(br.ReadUInt16());
      location = sw(br.ReadUInt16());
    }

    public override void Write(BinaryWriter bw)
    {
      //throw new NotImplementedException();
      byte[] buffer;
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      buffer = stob(description);
      bw.Write(buffer);
      bw.Write(sw(contentLength));
      bw.Write(sw(location));
    }
  }

  class TBlockType27_ROFS_Hash : TBlockHeader
  {
    public string description;
    public byte[] maybe_hash16_md5;
    public ushort unkn2;
    public byte[] unkn4;
    Func<uint, uint> sw = (num1) => (uint)(((((num1 & -16777216) >> 0x18) | ((num1 & 0xff0000) >> 8)) | ((num1 & 0xff00) << 8)) | ((num1 & 0xff) << 0x18));
    Func<string, byte[]> stob = (st) =>
    {
      char[] ch = st.ToCharArray();
      byte[] rt = new byte[ch.Length];
      for (int j = 0; j < ch.Length; j++)
        rt[j] = (byte)ch[j];
      return rt;
    };

    public TBlockType27_ROFS_Hash()
    {
    }

    public override void Read(BinaryReader br)
    {
      //throw new NotImplementedException();
      byte[] buffer;
      maybe_hash16_md5 = br.ReadBytes(0x10);
      unkn4 = br.ReadBytes(4);
      buffer = br.ReadBytes(12);
      description = buffer.ToString();
      flashMemory = (EMemoryType)br.ReadByte();
      unkn2 = br.ReadUInt16();
      contentChecksum16 = br.ReadUInt16();
      contentLength = sw(br.ReadUInt16());
      location = sw(br.ReadUInt16());
    }

    public override void Write(BinaryWriter bw)
    {
      byte[] buffer;
      // Folytatni!!!!!
      //throw new NotImplementedException();
      bw.Write(maybe_hash16_md5, 0, 0x10);
      bw.Write(unkn4, 0, 4);
      bw.Write(description);
      //bw.Write(buffer);
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      bw.Write(Utils.SwapBytes(contentLength));
      bw.Write(Utils.SwapBytes(location));
    }

  }

  class TBlockType28_CORE_Cert : TBlockType27_ROFS_Hash
  {
    public byte[] maybe_hash20_sha1;
    public byte[] unkn2b;

    public TBlockType28_CORE_Cert()
    {
    }

    public override void Read(BinaryReader br)
    {
      base.Read(br);
      maybe_hash20_sha1 = br.ReadBytes(20);
      unkn2b = br.ReadBytes(2);
    }
    public override void Write(BinaryWriter bw)
    {
      base.Write(bw);
      bw.Write(maybe_hash20_sha1);
      bw.Write(unkn2b);
    }
  }

  class TBlockType30 : TBlockHeader
  {
    public ushort unkn2;
    public byte[] unkn8;

    public TBlockType30()
    {
    }

    public override void Read(BinaryReader br)
    {
      //throw new NotImplementedException();
      flashMemory = (EMemoryType)br.ReadByte();
      unkn2 = br.ReadUInt16();
      contentChecksum16 = br.ReadUInt16();
      contentLength = Utils.SwapBytes(br.ReadUInt16());
      location = Utils.SwapBytes(br.ReadUInt16());
    }

    public override void Write(BinaryWriter bw)
    {
      //throw new NotImplementedException();
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      bw.Write(unkn8);
      bw.Write(Utils.SwapBytes(contentLength));
      bw.Write(Utils.SwapBytes(location));
    }
  }

  public class FwFile
  {
    THeader header = new THeader();
    List<TBlock> blocks = new List<TBlock>();
    public string outputDir { get; set; }

    public FwFile()
    {
      outputDir = Environment.CurrentDirectory + "\\ROFS2";
    }

    public void Test(string fname)
    {
      if (Directory.Exists(outputDir))
        Directory.Delete(outputDir, true);
      Directory.CreateDirectory(outputDir);
      
      BinaryReader br = new BinaryReader(new FileStream( fname, FileMode.Open));
      header.Read(br);
      Int16 i = 0;

      File.WriteAllBytes(outputDir + "\\header.bin", header.unkn);
      while (br.BaseStream.Position < br.BaseStream.Length)
      {
        UInt32 blockOffset = (UInt32)br.BaseStream.Position;
        TBlock block = new TBlock();
        block.Read(br);
        blocks.Add(block);

        Console.Write(" " + block.contentType + " At:" + Utils.ToHex(blockOffset) + " size:" + Utils.ToHex((UInt32)block.content.Length) + " " + Utils.ToHex(block.blockChecksum8));
        switch (block.blockType)
        {
          case EBlockType.Code:
            {
              TCodeBlock codeBlock = block.blockHeader as TCodeBlock;
              if (codeBlock != null)
                Console.Write(" " + Utils.ToHex(codeBlock.maybe_crc) + " " + Utils.ToHex(codeBlock.location));
              break;
            }
          case EBlockType.Data:
            {
              i++;
              TDataBlock dataBlock = block.blockHeader as TDataBlock;
              if (dataBlock != null)
                Console.Write(" descr:" + dataBlock.description);
              break;
            }
          default:
            {
              throw new Exception("Unknown Block");
            }
        }
        Console.WriteLine("");
      }
      br.Close();


      // Merge the Code Blocks
      // Dump Data and Code to file...
      EBlockType oldType = blocks[0].blockType;
      FileStream fs = null;
      BufferedStream bs = null;
      i = 0;
      foreach (TBlock block in blocks)
      {
        if (block.blockType == EBlockType.Code)
        {
          if (oldType == EBlockType.Data)
          {
            fs = new FileStream(outputDir + "\\" + i + "_code.bin", FileMode.Create, FileAccess.Write);
            bs = new BufferedStream(fs);
            // File.WriteAllBytes(outputDir + i + "_InitBytes.bin", block.content);
          }
          else
          {
            fs = new FileStream(outputDir + "\\" + i + "_code.bin", FileMode.Append, FileAccess.Write);
            bs = new BufferedStream(fs);
          }
          bs.Write(block.content, 0, block.content.Length);
          bs.Close();
          fs.Close();
        }
        if (block.blockType == EBlockType.Data)
        {
          i++;
          //TDataBlock dataBlock = block.blockHeader as TDataBlock;
          //string outfile = outputDir + i + "_" + Utils.CleanFileName(dataBlock.description) + ".bin";
          //File.WriteAllBytes(outfile, block.content);
        }
        oldType = block.blockType;
      }
      bs.Close();
      fs.Close();
    }
  }
}


