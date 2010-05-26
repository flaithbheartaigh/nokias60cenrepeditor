using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S60.Lib.Firmware;
using System.IO;

namespace S60.FirmHeaderUnpackTool
{
  class Program
  {
    static public THeader header = new THeader();
    static public List<TBlock> blocks = new List<TBlock>();
    static public string outputDir;
    static void Main(string[] args)
    {
      if (args.Length > 0)
        Test(args[0]);
      else
        Console.WriteLine("Nincs paraméter");
    }

    static public void Test(string fname)
    {
      outputDir = Directory.GetCurrentDirectory() + @"\headers";
      if (Directory.Exists(outputDir))
        Directory.Delete(outputDir, true);
      Directory.CreateDirectory(outputDir);

      BinaryReader br = new BinaryReader(new FileStream(fname, FileMode.Open));
      header.Read(br);
      Int16 i = 0;

      File.WriteAllBytes(outputDir + "\\header.bin", header.unkn);
      int cnt = 1;
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
              BinaryWriter bwHeader = new BinaryWriter(new FileStream(outputDir + @"\" + cnt.ToString()+ ".header.bin",FileMode.Create));
              block.blockHeader.Write(bwHeader);
              bwHeader.Close();
              cnt++;
              TCodeBlock codeBlock = block.blockHeader as TCodeBlock;
              if (codeBlock != null)
                Console.Write(" " + Utils.ToHex(codeBlock.maybe_crc) + " " + Utils.ToHex(codeBlock.location));
              break;
            }
          case EBlockType.Data:
            {
              i++;
              BinaryWriter bwHeader = new BinaryWriter(new FileStream(outputDir + @"\" + cnt.ToString() + ".header.bin", FileMode.Create));
              block.blockHeader.Write(bwHeader);
              bwHeader.Close();
              cnt++;
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

