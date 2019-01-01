using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class DataReader
    {
        public static string dataPath_rooms { get; } = @"Data\rooms\";
        public static string dataPath_commands { get; } = @"Data\commands\";
        public static List<string> lines { get; set; }

        private static string[] catagoriesList = new string[10] { "//--ROOM_NAME:", "//--ROOM_DESCRIPTION:", "--NAME:", "--IS_OPEN:", "--LOOK_ROOM_CLOSED:", "--LOOK_ROOM_OPEN:", "--LOOK_AT_CLOSED:", "--LOOK_AT_OPEN:", "--USE_UNBLOCKED:", "--USE_UNBLOCKED:" }; //"--Exit"

        /// <summary>
        /// ReadDataFile : Read File Method
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadDataFile(string path, string filename)
        {
            lines = new List<string>();
            filename = filename + ".txt";
            string fullPath = Path.Combine(path, filename);

            foreach (string line in File.ReadLines(fullPath))
            {
                if (line != "")
                {
                    lines.Add(line);
                }
            }
            return lines;
        }


        public static string Process_RoomData(string type)
        {
            string lineReturn = null;

            switch (type)
            {
                case "name":
                    //Console.WriteLine("inside name");
                    lineReturn = cleanCatagorieOffDataString(ReadLine());
                    Console.WriteLine("\n\n\n********\n"+lineReturn);
                    break;
                case "baseDescription":
                    //Console.WriteLine("description");
                    lineReturn = cleanCatagorieOffDataString(ReadLine());
                    break;
                default:
                    //optional 
                    //statements
                    break;
            }
            return lineReturn;
        }


        public static Rooms ImportRoomData(string name)
        {
            lines = DataReader.ReadDataFile(DataReader.dataPath_rooms, name);
            Rooms room = new Rooms();
            room.SetRoom_NameVariable(lines);
            //room.SetRoom_BaseDescription(lines);
            return room;
        }

        //bool b = str.Equals("true");
        private static string ReadLine()
        {
            string singleDataLine = "";

            for (int i = 0; i<lines.Count;i++)
            {
                if (lines[i].StartsWith("//--ROOM_NAME:"))
                {
                    singleDataLine = lines[i];
                    //Console.WriteLine("inside name : "+ singleDataLine);
                    lines.RemoveAt(i);
                }

                if (lines[i].StartsWith("//--ROOM_DESCRIPTION:"))
                {
                    //Console.WriteLine("description");
                    singleDataLine = lines[i];
                    lines.RemoveAt(i);
                }
            }
            //Console.WriteLine(singleDataLine.Trim());
            return singleDataLine.Trim();
        }

        private static string cleanCatagorieOffDataString(string line)
        {
            // Loop through and test each string.
            foreach (string catagorie in catagoriesList)
            {
                if (line.StartsWith(catagorie))
                {
                    int s = catagorie.Length;
                    int l = line.Length - catagorie.Length;
                    //Console.WriteLine(word.Substring(s, l));
                    //return;
                    line = line.Substring(s, l);
                }
            }
            Console.WriteLine("inside clean : " + line);
            return line.Trim();
        }

        public static void Process_CommandData(List<string> lines)
        {

        }
    }
}
