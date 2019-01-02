﻿using System;
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
        //private static string dataPath_commands = @"Data\commands\";
        private static List<string> readData_RoomFile = new List<string>();
        private static List<string> readData_ItemFile = new List<string>();

        /// <summary>
        /// ReadDataFile : Read File Method
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadDataFile(string path, string filename)
        {
            List<string> ReadData_asLines = new List<string>();
            filename = filename + ".txt";
            string fullPath = Path.Combine(path, filename);

            foreach (string line in File.ReadLines(fullPath))
            {
                if (line != "")
                {
                    ReadData_asLines.Add(line);
                }
            }
            return ReadData_asLines;
        }

        public static Rooms ImportRoomData(string name)
        {
            Rooms room = new Rooms();
            readData_RoomFile = ReadDataFile(dataPath_rooms, name); //read text file into : readData_RoomFile
            //--******************************************************************************************************************
            //--ROOM_NAME:
            for (int i = 0; i < readData_RoomFile.Count; i++)
            {
                if (readData_RoomFile[i].StartsWith("//--ROOM_NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    room.SetRoom_NameVariable(foundLine);
                }
            }

            //--ROOM_DESCRIPTION:
            for (int i = 0; i < readData_RoomFile.Count; i++)
            {
                if (readData_RoomFile[i].StartsWith("//--ROOM_DESCRIPTION:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
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
            for (int i = 0; i < readData_RoomFile.Count; i++)
            {
                if (readData_RoomFile[i].StartsWith("//-Exit_START"))
                {
                    exitIndexStart.Add(i);
                    exitAmount++;
                }
                if (readData_RoomFile[i].StartsWith("//-EXIT_END"))
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
            for (int i = 0; i < readData_RoomFile.Count; i++)
            {
                if (readData_RoomFile[i].StartsWith("//LIST_OF_ITEMS_IN_ROOM--START"))
                {
                    itemStartIndex = i + 1;
                }
                if (readData_RoomFile[i].StartsWith("//LIST_OF_ITEMS_IN_ROOM--END"))
                {
                    itemEndIndex = i;
                }
            }

            //TEST PRINT
            for (int i = itemStartIndex; i < itemEndIndex; i++)
            {
                //Console.WriteLine(readData_RoomFile[i]);
                room.AddItemToRoom(ProcessItemsToRooms(readData_RoomFile[i]));
            }
            

        return room; // FINAL RETURN
        }

        private static Items ProcessItemsToRooms(string itemName)
        {
            Items item = new Items();
            readData_ItemFile = ReadDataFile(dataPath_items, itemName);
            //--NAME:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--ITEM_NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.itemName = foundLine;
                }
            }
            //--ITEM_CAN_BE_PICKED_UP:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--ITEM_CAN_BE_PICKED_UP:"))
                {
                   string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                   item.canBeGot = foundLine.Equals("true");
                }
            }
            //--ROOM_DESCRIPTION_DEFAULT:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--ROOM_DESCRIPTION_DEFAULT:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.itemDescription_Default = foundLine;
                }
            }
            //--ROOM_DESCRIPTION_DROPPED:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--ROOM_DESCRIPTION_DROPPED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.itemDescription_Dropped = foundLine;
                }
            }
            //--ROOM_DESCRIPTION_GONE:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--ROOM_DESCRIPTION_GONE:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.itemDescription_Gone = foundLine;
                }
            }
            //--GET_ITEM_SUCCESS:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--GET_ITEM_SUCCESS:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.getItem_Success = foundLine;
                }
            }
            //--GET_ITEM_NOT ALLOWED:
            for (int i = 0; i < readData_ItemFile.Count; i++)
            {
                if (readData_ItemFile[i].StartsWith("//--GET_ITEM_NOT ALLOWED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_ItemFile[i]);
                    item.getItem_NotAllowed = foundLine;
                }
            }
            return item;
        }

        private static Exit ProcessExitsToRoom(int start, int end)
        {
            Exit exit = new Exit();

            //--NAME:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--NAME:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.name = foundLine;
                }
            }
            //--IS_OPEN (Booleen)
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--IS_OPEN"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.open = foundLine.Equals("true");
                }
            }
            //--LOOK_ROOM_CLOSED:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--LOOK_ROOM_CLOSED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.look_room_closed = foundLine;
                }
            }
            //--LOOK_ROOM_OPEN:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--LOOK_ROOM_OPEN:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.look_room_open = foundLine;
                }
            }
            //--LOOK_AT_CLOSED:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--LOOK_AT_CLOSED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.look_at_closed = foundLine;
                }
            }
            //--LOOK_AT_OPEN:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--LOOK_AT_OPEN:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.look_at_open = foundLine;
                }
            }
            //--USE_BLOCKED:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--USE_BLOCKED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.use_blocked = foundLine;
                }
            }
            //--USE_UNBLOCKED:
            for (int i = start; i < end; i++)
            {
                if (readData_RoomFile[i].StartsWith("--USE_UNBLOCKED:"))
                {
                    string foundLine = cleanCatagorieTxT(readData_RoomFile[i]);
                    exit.use_unblocked = foundLine;
                }
            }
            return exit;
        }

        private static string cleanCatagorieTxT(string line)
        {
            string[] catagoriesList = new string[17] 
                { "//--ROOM_NAME:", "//--ROOM_DESCRIPTION:" //-ROOM
                , "--NAME:", "--IS_OPEN:", "--LOOK_ROOM_CLOSED:", "--LOOK_ROOM_OPEN:", "--LOOK_AT_CLOSED:", "--LOOK_AT_OPEN:", "--USE_UNBLOCKED:", "--USE_BLOCKED:" //-EXITS
                ,"//--ITEM_NAME:", "//--ITEM_CAN_BE_PICKED_UP:", "//--ROOM_DESCRIPTION_DEFAULT:", "//--ROOM_DESCRIPTION_DROPPED:", "//--ROOM_DESCRIPTION_GONE:", "//--GET_ITEM_SUCCESS:", "//--GET_ITEM_NOT ALLOWED:" //-ITEMS
                }; //"--Exit"
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