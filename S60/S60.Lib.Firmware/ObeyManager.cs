using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace S60.Lib.Firmware
{
    class ObeyManager
    {
        public static void readObey(string obeyFile)
        {

        }

        public static void writeObey(string obeyFile, string imgName, string imgSize, string imgMaxSize, string inFolder)
        {
            FileStream fileStream = new FileStream(obeyFile, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);

            writer.WriteLine("rofsname=" + imgName);
            writer.WriteLine("romsize=" + imgSize);
            writer.WriteLine("rofssize=" + imgMaxSize);

            DirectoryInfo dir = new DirectoryInfo(inFolder);


            /*
            foreach (string file in files)
            {
                writer.WriteLine("data=" + '"' + file + '"\t"' + file.Substring(inFolder.Length) + '"' );
            }
            */
            writer.WriteLine("rem This OBEY file was created by S60.Lib.Firmware by fonix232 and jandras");
             
        }

        public static void writeObey(string obeyFile, string imgName, string imgSize, string imgMaxSize, string inFolder, List<string> inFiles)
        {
            FileStream fileStream = new FileStream(obeyFile, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);

            writer.WriteLine("rofsname=" + imgName);
            writer.WriteLine("romsize=" + imgSize);
            writer.WriteLine("rofssize=" + imgMaxSize);

            DirectoryInfo dir = new DirectoryInfo(inFolder);


            
            foreach (string file in inFiles)
            {
                writer.WriteLine("data=" + "\"\t" + file + "\"\t\""  + file.Substring(inFolder.Length) + '"' );
            }

            writer.WriteLine("rem This OBEY file was created by S60.Lib.Firmware by fonix232 and jandras");
             
        }
    }
}
