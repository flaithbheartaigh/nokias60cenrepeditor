using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace MIFWriter
{
  public static class MyConverter
  {
    public static byte[] ToByte(this string str)
    {
      byte[] tmp = {};
      char[] chrtmp = str.ToCharArray();
      int i = 0;
      Array.Resize<byte>(ref tmp, str.Length);
      foreach (char ch in chrtmp)
      {
        tmp[i] = (byte)ch;
        i++;
      }
      return tmp;
    }
    public static byte[] ToByte( this Int32 szam)
    {
      byte[] tmp = {0,0,0,0};
      tmp[0] = (byte)(szam & 0xff);
      tmp[1] = (byte)((szam >> 8) & 0xff);
      tmp[2] = (byte)((szam >> 16) & (Int32)0xff);
      tmp[3] = (byte)(szam >> 24);
      return tmp;
    }
    public static byte[] Append(this byte[] x, byte[] y)
    {
      int oldLength = x.Length;
      Array.Resize<byte>(ref x, oldLength + y.Length);
      for (int i = 0; i < y.Length; i++)
        x[oldLength + i] = y[i];
      return x;
    }
  }
  public class MIFWriterClass : Object
  {
    private List<Int32> fileinfo = new List<Int32>();
    private List<string> filedata = new List<string>();

    private class MifHeader
    {
      public enum MIFHeaderType
      {
        none  = 0,
        FileHeader = 1,
        ItemHeader = 2
      }
      byte[] HeaderId = new byte[4];

      public MifHeader()
      {
        HeaderId = "B##4".ToByte();
      }

      public MifHeader(MIFHeaderType type)
      {
        switch (type)
        {
          case MIFHeaderType.none:
          case MIFHeaderType.FileHeader:
            HeaderId = "B##4".ToByte();
            break;
          case MIFHeaderType.ItemHeader:
            HeaderId = "C##4".ToByte();
            break;
        }

      }
    }
    public MIFWriterClass()
    {
    }

    public void AddFileContent(string contents, bool Animated)
    {
      addfile(contents, Animated);
    }

    public void AddFileContent(string contents)
    {
      addfile(contents, false);
    }

    public void AddFileContent(StreamReader fstream, bool Animated)
    {
      string contents = fstream.ReadToEnd();
      addfile(contents, Animated);
    }

    public void AddFileContent(StreamReader fstream)
    {
      string contents = fstream.ReadToEnd();
      addfile(contents, false);
    }

    private void addfile(string contents, bool Animated)
    {
      filedata.Add(contents);
      fileinfo.Add((byte)(Animated ? 1 : 0));
    }
    public void AddFile(string filename,bool deleteconverted)
    {
      if (!File.Exists(filename))
      {
        return;
      }
      string type = Path.GetExtension(filename);
      string newname = filename;
      if (type.ToLower() != "svg")
      {
        Image bmp = Image.FromFile(filename);
        int w = bmp.Width;
        int h = bmp.Height;
        bmp.Dispose();
        newname = Jpeg2SVG(filename, w, h);
      }
      StreamReader reader = new StreamReader(newname);
      string filecontents = reader.ReadToEnd();
      reader.Close();
      AddFileContent(filecontents);
      if (type.ToLower() != "svg")
        if (deleteconverted)
          File.Delete(newname);
    }
    public void AddFile(string filename)
    {
      AddFile(filename, true);
    }
    public byte[] GenMifContents()
    {
      byte[] tmpbytes= {};
      Int32 clen = 0;
      Int32 xc;
      tmpbytes = tmpbytes.Append("B##4".ToByte());
      xc = 2;
      tmpbytes = tmpbytes.Append(xc.ToByte());
      xc = 16;
      tmpbytes = tmpbytes.Append(xc.ToByte());
      xc = filedata.Count * 2;
      tmpbytes = tmpbytes.Append(xc.ToByte());
      Int32 offset = (16 + (16 * filedata.Count));
      foreach (string s in filedata)
      {
        clen = s.Length+32;
        tmpbytes = tmpbytes.Append(offset.ToByte());
        tmpbytes = tmpbytes.Append(clen.ToByte());
        tmpbytes = tmpbytes.Append(offset.ToByte());
        tmpbytes = tmpbytes.Append(clen.ToByte());
        offset += clen;
      }
      Int32 idx = 0;
      foreach (string s in filedata)
      {
        clen = s.Length;
        tmpbytes = tmpbytes.Append("C##4".ToByte());
        Int32[] x = { 1, 32, clen, 1, 0, fileinfo[idx++], 0 };
        foreach (Int32 val in x)
          tmpbytes = tmpbytes.Append(val.ToByte());
        tmpbytes = tmpbytes.Append(s.ToByte());
      }

      return tmpbytes;
    }

    public void WriteMIFtoFile(string fn)
    {
      byte[] contents = GenMifContents();
      BinaryWriter wr = new BinaryWriter(File.Open(fn,FileMode.Create));
      wr.Write(contents);
      wr.Flush();
      wr.Close();
    }

    public void AddDir(string path)
    {
      /* Könyvtár becsomagolása MIF-be (csak SVG!!!) */

    }

    public string File2Base64(string fn)
    {
      const int CHUNK_SIZE = 1024;
      string tmp = "";
      byte[] buffer;
      byte[] filestream = new byte[0];
      BinaryReader xReader = new BinaryReader(System.IO.File.Open(fn, FileMode.Open, FileAccess.Read));
      xReader.BaseStream.Position = 0;
      do
      {
        buffer = xReader.ReadBytes(CHUNK_SIZE);
        if ( buffer.Length > 0 )
        {
          filestream = filestream.Append(buffer);
        }
      } while ( buffer.Length > 0 );
      xReader.Close();
      tmp = Convert.ToBase64String(filestream);
      return tmp;
    }
    private void WrHead(StreamWriter wr, string type, int width, int height)
    {
      string[] head = {
      "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><!-- Created with MIFWriter (c) JAndras --><svg xmlns:svg=\"http://www.w3.org/2000/svg\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" version=\"1.1\" width=\"",
      "\" height=\"",
      "\" id=\"svg2\"><defs id=\"defs4\" /><image xlink:href=\"data:image/" };
      wr.Write(head[0]);
      wr.Write(width.ToString());
      wr.Write(head[1]);
      wr.Write(height.ToString());
      wr.Write(head[2]);
      switch (type)
      {
        case "jpg":
        case "jpeg":
          wr.Write("jpeg;base64,");
          break;
        case "png":
          wr.Write("png;base64,");
          break;
      }
    }
    public string Jpeg2SVG(string filename,int width, int height)
    {
      string tmpfn = "";
      string[] footer = {
                          "\" x=\"0\" y=\"0\" width=\"",
                          "\" height=\"",
                          "\" id=\"image2836\" /></svg>"
                        };
      tmpfn = Path.GetDirectoryName(filename) + @"\" + Path.GetFileNameWithoutExtension(filename) + ".svg";
      StreamWriter wrSVG = new StreamWriter(tmpfn);
      WrHead(wrSVG, Path.GetExtension(filename), width, height);
      wrSVG.Write(File2Base64(filename));
      wrSVG.Write(footer[0]);
      wrSVG.Write(width.ToString());
      wrSVG.Write(footer[1]);
      wrSVG.Write(height.ToString());
      wrSVG.Write(footer[2]);
      wrSVG.Flush();
      wrSVG.Close();
      return tmpfn;
    }
  }
}
