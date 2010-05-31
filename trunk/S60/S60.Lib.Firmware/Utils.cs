﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;


namespace S60.Lib.Firmware
{
  public static class Utils
  {

    public static string CleanFileName(string fname)
    {
      string res = "";
      fname = fname.ToUpper();
      for (int i = 0; i < fname.Length; i++)
        if ((fname[i] >= '0' && fname[i] <= '9') ||
            (fname[i] >= 'A' && fname[i] <= 'Z'))
          res += fname[i];
        else
          res += "_";
      return res;
    }

    public static byte[] ComputeMD5Hash(this byte[] buffer)
    {
      MD5 myMD5 = new MD5CryptoServiceProvider();
      return myMD5.ComputeHash(buffer);
    }

    public static byte CRC_byte(byte[] buffer)
    {
      byte bSum = 0;
      int iCounter = 0;
      int tmp1, tmp2;
      do
      {
        tmp1 = (bSum & 1) << 7;
        tmp2 = (bSum & 0xfe) >> 1;
        bSum = (byte)((tmp1 | tmp2) + buffer[iCounter]);
      } while (iCounter < buffer.Length);
      return bSum;
    }

    public static string ToHex(this byte b)
    {
      return String.Format("{0:X2}", b);
    }


    public static string ToHex(this UInt16 b)
    {
      return String.Format("{0:X4}", b);
    }

    public static string ToHex(this UInt32 b)
    {
      return String.Format("{0:X8}", b);
    }

    public static string ToHex(this byte[] bytes)
    {
      string s = "";
      for (int i = 0; i < bytes.Length; i++)
      {
        if (s.Length > 0)
          s += " ";
        s += String.Format("{0:X2}", bytes[i]);
      }
      return s;
    }


    public static void AppendAllBytes(string fname, byte[] data)
    {
      byte[] orig = new byte[0];
      if (File.Exists(fname))
        orig = File.ReadAllBytes(fname);
      int currBytes = orig.Length;
      Array.Resize(ref orig, orig.Length + data.Length);
      Array.Copy(data, 0, orig, currBytes, data.Length);
      File.WriteAllBytes(fname, orig);
    }

    public static UInt16 SwapBytes(UInt16 bigEnd)
    {
      UInt32 myBigEndian = bigEnd;
      UInt32 mLittleEndian =
          ((myBigEndian & 0xFF00) >> 8) |
          ((myBigEndian & 0x00FF) << 8);
      return (UInt16)mLittleEndian;
    }

    public static UInt32 SwapBytes(UInt32 myBigEndian)
    {
      UInt32 mLittleEndian =
          ((myBigEndian & 0xFF000000) >> 24) |
          ((myBigEndian & 0x00FF0000) >> 8) |
          ((myBigEndian & 0x0000FF00) << 8) |
          ((myBigEndian & 0x000000FF) << 24);
      return mLittleEndian;
    }
  }
}
