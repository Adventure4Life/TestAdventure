using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class Engine
    {
        //Public Variables
        public static string raw_input { get; set; }

        //Permanently Active NOUN Triggers
        private static List<string> triggers;


        /// <summary>
        /// Initilise Game Engine to startup prams
        /// </summary>
        public static void Initilise()
        {
            Level.InitiliseLevel();
            CommandConstants.InitiliseCommandConstants();
            Console.SetWindowSize(150, 40); // Default Size = 120 : 30
        }

        public static void StartScreen()
        {
            //TODO : Set a start Screen for the game initialization before main loop 
        }

        //******************************************
        //************* Game Functions *************
        //******************************************
        /// <summary>
        /// Prints a Input Prompt and gets line input to send to ProcessCommand
        /// </summary>
        public static void PlayGame()
        {
            Console.Write("\n> ");
            ProcessCommand.GetInput(Console.ReadLine().Trim());
        }
    }
}
