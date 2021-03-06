﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace S60.Lib.Firmware
{
  internal delegate string tostr(int i);


  static public class UseExternalTools
  {
    static public void ExtractImage(string toolsPath, string image,string outpath)
    {
      Process p = Process.Start(toolsPath + @"\readimage.exe", "-z " + outpath + " " + image);
      p.WaitForExit();
    }
    static public void BuildRofsImage(string toolsPath, string obeyfile)
    {
      Process p = Process.Start( toolsPath + @"\rofsbuild.exe", "-compress " + Directory.GetCurrentDirectory()+@"\"+obeyfile );
      p.WaitForExit();
    }

    public static void BuildRofsImage(string p, string p_2, string p_3)
    {
      throw new NotImplementedException();
    }
  }

  static public class ConstructBlocks
  {
    static List<TBlock> generatedBlock = new List<TBlock>();
    private static int CurrPos = 0;
    static TDataBlock ConstructDataBlock(BinaryReader br)
    {
      TDataBlock TD = new TDataBlock();

      return TD;
    }
    static TCodeBlock ConstructCodeBlock(BinaryReader br)
    {
      TCodeBlock CB = new TCodeBlock();

      return CB;
    }

    public static void GenerateOBYFile(string sourcePath, string destFileName)
    {
    }

  }

  public enum EContentType
  {
    Code = 0x54,
    Data = 0x5D
  }

  public enum EBlockType
  {
    BlockType17 = 0x17,
    BlockType27_ROFS_Hash = 0x27,
    BlockType28_CORE_Cert = 40,
    BlockType2E = 0x2e,
    BlockType30 = 0x30
  }

  public enum Valami
  {
    ertek0,
    ertek1,
    ertek2,
    ertek3,
    ertek4
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

  public abstract class TBase
  {
    public abstract void Read(BinaryReader br);
    public abstract void Write(BinaryWriter bw);
  }


  public class THeader : TBase,ICloneable
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
      //throw new NotImplementedException();
      bw.Write(signature);
      bw.Write(Utils.SwapBytes(headerSize));
      bw.Write(Utils.SwapBytes(totBlocks));
      bw.Write(unkn, 0, unkn.Length);
    }

    #region ICloneable Members

    public object Clone()
    {
      //throw new NotImplementedException();
      MemoryStream ms;
      BinaryFormatter bf;
      object myClone;
      try
      {
        ms = new MemoryStream();
        bf = new BinaryFormatter();
        bf.Serialize(ms, this);
        myClone = bf.Deserialize(ms);
        return myClone;
      }
      catch
      {
        throw new Exception("Hiba a klónozás során!");
      }
    }

    #endregion
  }


  public class TBlock : TBase
  {
    public EBlockType blockType;
    public byte const01;
    public EContentType contentType;
    public byte blockSize;
    public TBlockHeader blockHeader;
    public byte blockHeaderSize;
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
      blockHeader = TBlockHeader.GenBlkHeader(br,contentType,blockType);
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
      ROFSTracer.WriteTextBlock( this );
    }
    public void NewRead(BinaryReader br)
    {
      contentType = (EContentType)br.ReadByte();
      const01 = br.ReadByte();
      if (const01 != 1)
      {
        throw new Exception("Hibás konstans érték!");
      }
      blockType = (EBlockType)br.ReadByte();
      blockHeaderSize = br.ReadByte();
      byte[] buffer = br.ReadBytes(blockHeaderSize);
      br.BaseStream.Seek((long)-blockHeaderSize, SeekOrigin.Current);
      blockChecksum8 = Utils.ComputeBlockChecksum(const01, blockType, blockHeaderSize, buffer);
      long num = br.ReadInt64();

      blockHeader = TBlockHeader.GenBlkHeader(br,contentType,blockType);
      blockHeader.Read(br);
      blockChecksum8 = br.ReadByte();
      content = br.ReadBytes((int)blockHeader.contentSize);
      //blockHeader.contentLength 
    }

    public override void Write(BinaryWriter bw)
    {
      //throw new NotImplementedException();
      bw.Write( ( byte ) blockType );
      bw.Write( const01 );
      bw.Write( (byte)contentType );
      blockHeader.Write( bw );
      bw.Write( blockChecksum8 );
      bw.Write( content, 0, content.Length );
    }
  }


  public abstract class TBlockHeader : TBase
  {
    public UInt32 contentSize = 0;
    public ushort contentChecksum16;
    public EMemoryType flashMemory;
    public uint location;
    public uint contentLength;

    public static TBlockHeader GenBlkHeader(BinaryReader br, EContentType type1, EBlockType type4)
    {
      EContentType type;
      EBlockType type2;
      EBlockType type3;

      type = type1;
      if ((type == EContentType.Code) || (type == EContentType.Data))
      {
        type2 = type4;
        switch (type2)
        {
          case EBlockType.BlockType2E:
            return new TBlockType2E();
          case (EBlockType)0x2f:
            throw new NotImplementedException();
          case EBlockType.BlockType30:
            return new TBlockType30();
        }
        return new TBlockType17();
      }
      type3 = type4;
      switch (type3)
      {
        case EBlockType.BlockType28_CORE_Cert:
          return new TBlockType28_CORE_Cert();
      }
      return new TBlockType27_ROFS_Hash();
    }
  }


  public class TCodeBlock : TBlockHeader
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
      //throw new NotImplementedException();
      bw.Write(processorType);
      bw.Write(unkn);
      bw.Write(Utils.SwapBytes(maybe_crc));
      bw.Write(const01);
      bw.Write(Utils.SwapBytes(contentSize));
      bw.Write(Utils.SwapBytes(location));
    }
  }


  public class TSignedCodeBlock : TBlockHeader
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


  public class TDataBlock : TBlockHeader
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
       bw.Write(hash, 0, hash.Length);
      bw.Write(hashCRC, 0, hashCRC.Length);
      bw.Write(description);
      bw.Write(processorType);
      bw.Write(unkn, 0, 4);
      bw.Write(Utils.SwapBytes(contentSize));
      bw.Write(Utils.SwapBytes(location));
    }
  }

  public class TSignedDataBlock : TDataBlock
  {
    public byte[] unknSigned;

    public override void Read(BinaryReader br)
    {
      base.Read(br);
      unknSigned = br.ReadBytes(0x16);
    }
  }

  public class TBlockType17 : TBlockHeader
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
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      bw.Write(const01);
      bw.Write(sw(contentLength));
      bw.Write(sw(location));
    }
  }

  public class TBlockType2E : TBlockHeader
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
      contentLength = sw(br.ReadUInt16());
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

  public class TBlockType27_ROFS_Hash : TBlockHeader
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
      bw.Write(maybe_hash16_md5, 0, 0x10);
      bw.Write(unkn4, 0, 4);
      bw.Write(description);
      bw.Write((byte)flashMemory);
      bw.Write(unkn2);
      bw.Write(contentChecksum16);
      bw.Write(Utils.SwapBytes(contentLength));
      bw.Write(Utils.SwapBytes(location));
    }

  }

  public class TBlockType28_CORE_Cert : TBlockType27_ROFS_Hash
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

  public class TBlockType30 : TBlockHeader
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
      ROFSTracer.InitDebug( Directory.GetCurrentDirectory() + @"\ReadTrace.log" );
    }

    public Valami MegNemTudomMitCsinal()
    {
      List<byte> list;
      int num;
      List<TBlock>.Enumerator enumerator;
      foreach(TBlock block in blocks)
      {
        if (block.blockType == EBlockType.BlockType28_CORE_Cert)
          return Valami.ertek3;
      }
      list = new List<byte>();
      num = 0;
      do
      {
        if (blocks[num].contentType == EContentType.Code)
        {
          list.AddRange(blocks[num].content);
        }
        num++;
      } while ((num < blocks.Count) && (list.Count < 0x1000));
      num = 0;
      do
      {
        num++;
      } while ((num < list.Count) && (list[num] == 0));
      if ((list.Count - num) >= 30)
      {
        if (((list[num] == 0x52) && (list[num + 1] == 0x4f)) && (list[num + 2] == 70))
        {
          if (list[num + 3] == 0x53)
          {
            return Valami.ertek1;
          }
        }
        if (((list.Count-num) >=500) && ((((list[num+11]==0) && (list[num+12]==2)) && ((list[num+10]<=2) && (list[num+11]==0))) && list[num+12]<=2))
        {
          return Valami.ertek0;
        }
      }
      return Valami.ertek4;
    }
    
    public void Test(string fname)
    {
      if (Directory.Exists(outputDir))
        Directory.Delete(outputDir, true);
      Directory.CreateDirectory(outputDir);

      BinaryReader br = new BinaryReader(new FileStream(fname, FileMode.Open));
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
        switch (block.contentType)
        {
          case EContentType.Code:
            {
              TCodeBlock codeBlock = block.blockHeader as TCodeBlock;
              if (codeBlock != null)
                Console.Write(" " + Utils.ToHex(codeBlock.maybe_crc) + " " + Utils.ToHex(codeBlock.location));
              break;
            }
          case EContentType.Data:
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

      EContentType oldType = blocks[0].contentType;
      FileStream fs = null;
      BufferedStream bs = null;
      i = 0;
      bool firstCode = false;
      foreach (TBlock block in blocks)
      {
        if (block.contentType == EContentType.Data)
        {
          if (oldType == EContentType.Data)
          {
            fs = new FileStream(outputDir + "\\" + "rofsImage.img", FileMode.Create, FileAccess.Write);
            bs = new BufferedStream(fs);
            firstCode = true;
            // File.WriteAllBytes(outputDir + i + "_InitBytes.bin", block.content);
          }
          else
          {
            fs = new FileStream(outputDir + "\\" + "rofsImage.img", FileMode.Append, FileAccess.Write);
            bs = new BufferedStream(fs);
          }
          //bs.Write(block.content, 0, block.content.Length);
          bs.Write(block.content, firstCode ? 0xc00 : 0, firstCode ? block.content.Length - 0xc00 : block.content.Length);
          firstCode = false;
          bs.Close();
          fs.Close();
        }
        if (block.contentType == EContentType.Data)
        {
          i++;
          //TDataBlock dataBlock = block.blockHeader as TDataBlock;
          //string outfile = outputDir + i + "_" + Utils.CleanFileName(dataBlock.description) + ".bin";
          //File.WriteAllBytes(outfile, block.content);
        }
        oldType = block.contentType;
      }
      bs.Close();
      fs.Close();
    }
  }
}
