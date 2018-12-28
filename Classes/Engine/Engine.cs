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

        public static void Initilise()
        {
            // Default Size = 120 : 30
            Console.SetWindowSize(150, 40);
        }

        public static void StartScreen()
        {

        }

        //******************************************
        //************* Game Functions *************
        //******************************************

        public static void PlayGame()
        {
            //PrintBuffer.PrintUserInput();
            Console.Write("> ");
            ProcessCommand.GetInput(Console.ReadLine().Trim());
        }
    }
}
