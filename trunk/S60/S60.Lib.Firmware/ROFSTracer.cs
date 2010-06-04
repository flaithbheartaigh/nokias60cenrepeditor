using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace S60.Lib.Firmware
{

  static public class ROFSTracer
  {
    static string fileName = "";
    [Conditional( "DEBUG" )]
    static public void InitDebug( string filename )
    {
      fileName = filename;
    }

    

    [Conditional( "DEBUG" )]
    static public void WriteTextBlock( TBlock myBlock )
    { /*
      StreamWriter logger = new StreamWriter( fileName, true );
      logger.AutoFlush = true;
      logger.WriteLine( "<<==== NEW BLOCK =====>>" );
      switch ( myBlock.blockType )
      {
        case EBlockType.Data:
          logger.WriteLine( "Block type: (0x5D) DATA" );
          break;
        case EBlockType.Code:
          logger.WriteLine( "Block type: (0x54) CODE" );
          break;
      }
      logger.WriteLine( "const01: {0:X2}", myBlock.const01 );
      logger.WriteLine( "Content type : {0:X2}", ( byte ) myBlock.contentType );
      logger.WriteLine( "Block size : {0} ({0:x2})", myBlock.blockSize );
      logger.WriteLine( "\t===>BlockHeader =====>" );
      switch( myBlock.blockType)
      {
        case EBlockType.Data:
          TDataBlock myData = myBlock.blockHeader as TDataBlock;
          logger.WriteLine( "\t===>DataBlock ====>" );
          logger.WriteLine( "\tHash : " + myData.hash.ToHex()  );
          logger.WriteLine( "\tComputed Hash : " + Utils.ComputeMD5Hash( myBlock.content ).ToHex() );
          logger.WriteLine( "\tHashCRC : " + myData.hashCRC.ToHex() );
          logger.WriteLine( "\tDescription : " + myData.description );
          logger.WriteLine( "\tProcessor type : {0:X2}", myData.processorType );
          logger.WriteLine( "\tUnknown : " + myData.unkn.ToHex() );
          logger.WriteLine( "\tLocation : {0} ({0:X8})", myData.location );
          logger.WriteLine( "\t<===DataBlock <====" );
          break;
        case EBlockType.Code:
          TCodeBlock myCode = myBlock.blockHeader as TCodeBlock;
          logger.WriteLine( "\t===>CodeBlock ====>" );
          logger.WriteLine( "\tProcessor type {0:X2}", myCode.processorType );
          logger.WriteLine( "\tUnknown : {0:X4}", myCode.unkn );
          logger.WriteLine( "\tCRC? : {0:X4}", myCode.maybe_crc );
          logger.WriteLine( "\tconst01 : {0:X2}", myCode.const01 );
          logger.WriteLine( "\tContent size : {0} ({0:X16})", myCode.contentSize );
          logger.WriteLine( "\tLocation : {0} ({0:X16})", myCode.location );
          logger.WriteLine( "\t<===CodeBlock <====" );
          break;
      }
      logger.WriteLine( "Block checksum : {0:X2}", myBlock.blockChecksum8 );
      logger.WriteLine( "Computed checksum : {0:X2}", Utils.ComputeBlockChecksum(myBlock.const01,myBlock.blockType,myBlock.blockHeaderSize,myBlock.content ));
      if ( myBlock.blockType == EBlockType.Data )
      {
        logger.WriteLine( "========= CONTENT ==========" );
        logger.WriteLine( myBlock.content.ToHex() );
        logger.WriteLine( "========= END CONTENT ==========" );
      }

      logger.Close();
       * */
    }
  }
}
