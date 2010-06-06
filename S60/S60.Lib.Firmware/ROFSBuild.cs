using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace S60.Lib.Firmware
{
  #region JAHeader
  /***************************************************************************************************************/
  /* Library by JAndras
  /***************************************************************************************************************/
  #endregion
  public enum TFileSource
  {
    EE32Image = 0,
    EPeFile = 1,
    EElfFile = 2,
  }
  struct TPairCountIndex
  {
    public ushort Count;
    public ushort Index;
  }

  struct TPair
  {
    public ushort Pair;
    public ushort Next;
    public ushort Prev;
    public ushort Pos;
  }

  struct TPos
  {
    public ushort Pos;
    public ushort Next;
  }


  public class CBytePair
  {
    public const int MAXBLOCKSIZE = 0x1000;
    public const short POSEND = (short)0xffff;
    public const short POSHEAD = (short)0xfffe;
    public const byte BYTEREMOVED = (byte)'R';
    public const byte BYTEMARKED = (byte)'M';
    public const byte BYTEHEAD = (byte)'H';
    public const byte BYTETAIL = (byte)'T';
    public const byte BYTENEW = (byte)'N';

    private bool iFastCompress;
    private int marker;
    private byte[] Mask = new byte[MAXBLOCKSIZE];
    private ushort[] ByteCount = new ushort[0x100];
    private ushort[] ByteIndex = new ushort[0x100];
    private ushort[] BytePos = new ushort[MAXBLOCKSIZE];
    private TPairCountIndex[] PairCount = new TPairCountIndex[0x10000];
    private TPair[] PairBuffer = new TPair[MAXBLOCKSIZE * 2];
    private int PairBufferNext;
    private TPos[] PairPos = new TPos[MAXBLOCKSIZE * 3];
    private ushort PairPosNext;
    private ushort[] PairLists = new ushort[MAXBLOCKSIZE / 2 + 2];
    private int PairListHigh;

    private void CountBytes(byte data, int size)
    {
      for (int i = 0; i < ByteCount.Length; i++)
        ByteCount[i] = 0;
      for (int i = 0; i < ByteIndex.Length; i++)
         ByteIndex[i] = 0xffff;
      for (int i = 0; i < BytePos.Length; i++)
        BytePos[i] = 0xffff;

      int pos = 0;
      byte dataend = (byte)(data + (byte)size);
      while (data<dataend)
      {
        BytePos[pos] = ByteIndex[data];
        ByteIndex[data] = (ushort)pos;
        pos++;
        ++ByteCount[data++];
      }
    }
    private void ByteUsed(int b)
    {
      ByteCount[b] = 0xffff;
    }
    private int TieBreak(int b1, int b2)
    {
      return -ByteCount[b1] - ByteCount[b2];
    }
    private void Initialize(byte data, int size)
    {
    }

    private int MostCommonPair(ref int pair)
    {
      return 0;
    }

    private int LeastCommonByte(ref int iByte)
    {
      return 0;
    }

    private void InsertPair(ushort pair, ushort pos)
    {
      ushort count = PairCount[pair].Count;
      if (0 == count)
      {
        PairCount[pair].Index = (ushort)PairBufferNext;
        if (PairLists[1] != POSEND)
          PairBuffer[1].Prev = (ushort)PairBufferNext;
        PairBuffer[PairBufferNext].Next = PairLists[1];
        PairBuffer[PairBufferNext].Prev = (ushort)POSHEAD;
        PairLists[1] = (ushort)PairBufferNext;
        PairBuffer[PairBufferNext].Pair = pair;
        PairBuffer[PairBufferNext].Pos = PairPosNext;
        PairBufferNext++;
        Debug.Assert(PairBufferNext < MAXBLOCKSIZE * 2);
        PairPos[PairPosNext].Pos = pos;
        PairPos[PairPosNext].Next = (ushort)POSEND;
      }
      else
      {
        ushort index = PairCount[pair].Index;
        if (PairBuffer[index].Next == POSEND)
          if (PairBuffer[index].Prev == POSHEAD)
            PairLists[count] = (ushort)POSEND;
          else
            PairBuffer[PairBuffer[index].Prev].Next = (ushort)POSEND;
        else
          if (PairBuffer[index].Prev == POSHEAD)
          {
            PairLists[count] = PairBuffer[index].Next;
            PairBuffer[PairBuffer[index].Next].Prev = (ushort)POSHEAD;
          }
          else
          {
            PairBuffer[PairBuffer[index].Prev].Next = PairBuffer[index].Next;
            PairBuffer[PairBuffer[index].Next].Prev = PairBuffer[index].Prev;
          }
        if (PairLists[count + 1] != POSEND)
        {
          PairBuffer[PairLists[count + 1]].Prev = index;
          PairBuffer[index].Next = PairLists[count + 1];
          PairBuffer[index].Prev = (ushort)POSHEAD;
          PairLists[count + 1] = index;
        }
        else
        {
          PairLists[count + 1] = index;
          PairBuffer[index].Next = (ushort)POSEND;
          PairBuffer[index].Prev = (ushort)POSHEAD;
        }
        PairPos[PairPosNext].Pos = pos;
        PairPos[PairPosNext].Next = PairBuffer[index].Pos;
        PairBuffer[index].Pos = PairPosNext;
      }
      PairPosNext++;
      Debug.Assert(PairPosNext < MAXBLOCKSIZE * 3);
      PairCount[pair].Count++;
      if (PairCount[pair].Count > PairListHigh)
        PairListHigh = PairCount[pair].Count; 

    }

    private void RemovePair(ushort pair, ushort pos)
    {
      ushort count = PairCount[pair].Count;
      ushort index = PairCount[pair].Index;
      if (count == 1)
      {
        PairCount[pair].Count = 0;
        PairCount[pair].Index = (ushort)POSEND;
        return;
      }

      Debug.Assert(index != POSEND);
      ushort posnextp = PairBuffer[index].Pos;
      while (posnextp != POSEND)
      {
        if (PairPos[posnextp].Pos == pos)
          break;
        posnextp = PairPos[posnextp].Next;
      }
      Debug.Assert(posnextp != POSEND);
      posnextp = PairPos[posnextp].Next;

      if (PairBuffer[index].Next == POSEND)
      {
        if (PairBuffer[index].Prev == POSHEAD)
        {
          PairLists[count] = (ushort)POSEND;
        }
        else
        {
          PairBuffer[PairBuffer[index].Prev].Next = (ushort)POSEND;
        }
      }
      else
      {
        if (PairBuffer[index].Prev == POSHEAD)
        {
          PairLists[count] = PairBuffer[index].Next;
          PairBuffer[PairBuffer[index].Next].Prev = (ushort)POSHEAD;
        }
        else
        {
          PairBuffer[PairBuffer[index].Prev].Next = PairBuffer[index].Next;
          PairBuffer[PairBuffer[index].Next].Prev = PairBuffer[index].Prev;
        }
      }
      Debug.Assert(PairCount[pair].Count > 0);
      PairCount[pair].Count--;
      if (PairCount[pair].Count == 0)
        PairCount[pair].Index = (ushort)POSEND;

      count = PairCount[pair].Count;
      if (count > 0)
      {
        if (PairLists[count] != POSEND)
        {
          PairBuffer[PairLists[count]].Prev = index;
          PairBuffer[index].Next = PairLists[count];
          PairBuffer[index].Prev = (ushort)POSHEAD;
          PairLists[count] = index;
        }
        else
        {
          PairLists[count] = index;
          PairBuffer[index].Next = (ushort)POSEND;
          PairBuffer[index].Prev = (ushort)POSHEAD;
        }
      }
      while (PairLists[PairListHigh] == POSEND)
      {
        PairListHigh--;
      }
    }


  }

  public class E32ImageFile
  {

  }
  public class ROFSBuild
  {
  }
}
