using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class ProcessCommand
    {
        //Public Variables
        public static List<string> tokenizedInput { get; set; }

        public static void GetInput(string input)
        {
            Engine.raw_input = input;
            if (input == "exitgame")
            { GameState.gameIsRunning = false; }
            else
            {
                tokenizedInput = TextUtils.TokenizeString(input);









            } // end of test loop.. all code while working has to be in here!

        }
    }
}
