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
        private static string dataPath_rooms = @"Data\rooms\";
        private static string dataPath_items = @"Data\items\";
        private static string dataPath_commands = @"Data\commands\";
        private static List<string> ReadData_asLines;
        private static string[] catagoriesList = new string[10] { "//--ROOM_NAME:", "//--ROOM_DESCRIPTION:", "--NAME:", "--IS_OPEN:", "--LOOK_ROOM_CLOSED:", "--LOOK_ROOM_OPEN:", "--LOOK_AT_CLOSED:", "--LOOK_AT_OPEN:", "--USE_UNBLOCKED:", "--USE_BLOCKED:" }; //"--Exit"

        /// <summary>
        /// ReadDataFile : Read File Method
        /// </summary>
        /// <returns></returns>
        public static void ReadDataFile(string path, string filename)
        {
            ReadData_asLines = new List<string>();
            filename = filename + ".txt";
            string fullPath = Path.Combine(path, filename);

            foreach (string line in File.ReadLines(fullPath))
            {
                if (line != "")
                {
                    ReadData_asLines.Add(line);
                }
            }
        }

        public static Rooms ImportRoomData(string name)
        {
            Rooms room = new Rooms();
            ReadDataFile(dataPath_rooms, name); //read text file into : ReadData_asLines
            //--******************************************************************************************************************
            //--ROOM_NAME:
            for (int i = 0; i < ReadData_asLines.Count; i++)
            {
                if (ReadData_asLines[i].StartsWith("//--ROOM_NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    room.SetRoom_NameVariable(foundLine);
                }
            }

            //--ROOM_DESCRIPTION:
            for (int i = 0; i < ReadData_asLines.Count; i++)
            {
                if (ReadData_asLines[i].StartsWith("//--ROOM_DESCRIPTION:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    room.SetRoom_BaseDescription(foundLine);
                }
            }
            //--******************************************************************************************************************
            //--Read Exit Data
            //-Exit_START --- Find the total amount of exits in the data file
            //-Find and Store the Index # for the Start and End brackets of the exits.
            int exitAmount = 0;
            List<int> exitIndexStart = new List<int>();
            List<int> exitIndexEnd = new List<int>();
            for (int i = 0; i < ReadData_asLines.Count; i++)
            {
                if (ReadData_asLines[i].StartsWith("//-Exit_START"))
                {
                    exitIndexStart.Add(i);
                    exitAmount++;
                }
                if (ReadData_asLines[i].StartsWith("//-EXIT_END"))
                {
                    exitIndexEnd.Add(i);
                }
            }
            //--Process EXIT Data
            // run the Process Exit Code by the amount of exits found "exitAmount"
            // Use the I value with exitIndexStart, exitIndexEnd which contain the index values of the brackets in read datafile.
            for (int i = 0; i < exitAmount; i++)
            {
                room.SetRoom_AddExit(ProcessExitsToRoom(exitIndexStart[i], exitIndexEnd[i]));
            }

            //--******************************************************************************************************************
            //--READ ITEM Data
            //--Find and store index positions for ItemList brackets
            int itemStartIndex = 0;
            int itemEndIndex = 0;
            for (int i = 0; i < ReadData_asLines.Count; i++)
            {
                if (ReadData_asLines[i].StartsWith("//LIST_OF_ITEMS_IN_ROOM--START"))
                {
                    itemStartIndex = i + 1;
                }
                if (ReadData_asLines[i].StartsWith("//LIST_OF_ITEMS_IN_ROOM--END"))
                {
                    itemEndIndex = i;
                }
            }

            for (int i = itemStartIndex; i < itemEndIndex; i++)
            {
                Console.WriteLine(ReadData_asLines[i]);
            }

            

            return room; // FINAL RETURN
        }

        /*private static Items ProcessItemsToRooms(int start, int end)
        {
            Items item = new Items();
            ReadDataFile(dataPath_rooms, name);
            //--NAME:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.name = foundLine;
                }
            }


            return item;
        }*/

        private static Exit ProcessExitsToRoom(int start, int end)
        {
            Exit exit = new Exit();

            //--NAME:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.name = foundLine;
                }
            }
            //--IS_OPEN (Booleen)
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--IS_OPEN"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.open = foundLine.Equals("true");
                }
            }
            //--LOOK_ROOM_CLOSED:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--LOOK_ROOM_CLOSED:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.look_room_closed = foundLine;
                }
            }
            //--LOOK_ROOM_OPEN:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--LOOK_ROOM_OPEN:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.look_room_open = foundLine;
                }
            }
            //--LOOK_AT_CLOSED:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--LOOK_AT_CLOSED:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.look_at_closed = foundLine;
                }
            }
            //--LOOK_AT_OPEN:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--LOOK_AT_OPEN:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.look_at_open = foundLine;
                }
            }
            //--USE_BLOCKED:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--USE_BLOCKED:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.use_blocked = foundLine;
                }
            }
            //--USE_UNBLOCKED:
            for (int i = start; i < end; i++)
            {
                if (ReadData_asLines[i].StartsWith("--USE_UNBLOCKED:"))
                {
                    string foundLine = cleanCatagorieTxT(ReadData_asLines[i]);
                    exit.use_unblocked = foundLine;
                }
            }
            return exit;
        }

        private static string cleanCatagorieTxT(string line)
        {
            // Loop through and test each string.
            foreach (string catagorie in catagoriesList)
            {
                if (line.StartsWith(catagorie))
                {
                    int s = catagorie.Length;
                    int l = line.Length - catagorie.Length;
                    line = line.Substring(s, l);
                }
            }
            return line.Trim();
        }

    }
}