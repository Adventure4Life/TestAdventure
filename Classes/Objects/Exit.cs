using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    class Exit
    {
        public string name { get; set; } = "";
        public string look_room_closed { get; set; } = "";
        public string look_room_open { get; set; } = "";
        public string look_at_closed { get; set; } = "";
        public string look_at_open { get; set; } = "";
        public string use_blocked { get; set; } = "";
        public string use_unblocked { get; set; } = "";
        public bool open { get; set; } = true;

        public void SetOpenBool(string value)
        {
            open = false;
        }

    }
}


/*public void BuildExit(List<string> imPortedData)
{
    //-Exit_START:--NAME:
    for (int i=0;i< imPortedData.Count;i++)
    {
        if (imPortedData[i].StartsWith("--NAME:"))
        {
            //foundLine = DataReader.cleanCatagorieTxT(imPortedData[i]);
        }   
    }
    //-Exit_START:--IS_OPEN:
    //-Exit_START:--IS_OPEN:
    //-Exit_START:--LOOK_ROOM_CLOSED:
    //-Exit_START:--LOOK_ROOM_OPEN:
    //-Exit_START:--LOOK_AT_CLOSED:
    //-Exit_START:--LOOK_AT_OPEN:
    //-Exit_START:--USE_BLOCKED:
    //-Exit_START:--USE_UNBLOCKED:

}*/
