using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace S60.Lib.Firmware
{
  public class ObeyManager
  {
    private static List<string> fileList=new List<string>();

    private static void ListBuilder( string startDir, ref List<string> obeyList )
    {
      if ( Regex.Match( startDir, @".+\.{1,2}$" ).Success )
        return;
      DirectoryInfo diGetFiles = new DirectoryInfo( startDir );
      foreach(DirectoryInfo diTmp in diGetFiles.GetDirectories())
        ListBuilder(diTmp.FullName,ref obeyList);
      foreach ( FileInfo diTmp in diGetFiles.GetFiles() )
        obeyList.Add( diTmp.FullName );
    }

    public static void readObey(string obeyFile)
    {

    }

    public static void writeObey(string obeyFile, string imgName, string imgSize, string imgMaxSize, string inFolder)
    {
      if ( File.Exists( obeyFile ) )
        File.Delete( obeyFile );
      try
      {
        FileStream fileStream = new FileStream( obeyFile, FileMode.Create );
        StreamWriter writer = new StreamWriter( fileStream );
        writer.WriteLine( "rofsname=" + imgName );
        if ( imgSize != "" )
          writer.WriteLine( "romsize=" + imgSize );
        if ( imgMaxSize != "" )
          writer.WriteLine( "rofssize=" + imgMaxSize );

        //DirectoryInfo dir = new DirectoryInfo(inFolder);
        ListBuilder( inFolder, ref fileList );
        foreach ( string fn in fileList )
        {
          StringBuilder sb = new StringBuilder( "data=" );
          sb.Append( '"' ).Append( fn ).Append( '"' ).Append( " " ).Append( '"' ).Append( Regex.Replace( fn, @"^[a-z]:\\.+\\rofs[123]", "", RegexOptions.IgnoreCase ) ).Append( '"' );
          writer.WriteLine( sb.ToString() );
        }

        writer.WriteLine( "rem This OBEY file was created by S60.Lib.Firmware by fonix232 and jandras" );
        writer.Dispose();
      }
      catch { }

    }

    public static void writeObey(string obeyFile, string imgName, string imgSize, string imgMaxSize, string inFolder, List<string> inFiles)
    {
      FileStream fileStream = new FileStream(obeyFile, FileMode.Create);
      StreamWriter writer = new StreamWriter(fileStream);

      writer.WriteLine("rofsname=" + imgName);
      if ( imgSize != "" )
        writer.WriteLine( "romsize=" + imgSize );
      if ( imgMaxSize != "" )
        writer.WriteLine( "rofssize=" + imgMaxSize );

      DirectoryInfo dir = new DirectoryInfo(inFolder);



      foreach (string file in inFiles)
      {
        writer.WriteLine("data=" + "\"\t" + file + "\"\t\"" + file.Substring(inFolder.Length) + '"');
      }

      writer.WriteLine("rem This OBEY file was created by S60.Lib.Firmware by fonix232 and jandras");

    }
  }
}
