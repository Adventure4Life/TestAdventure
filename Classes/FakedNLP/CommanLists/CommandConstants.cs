using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdventure
{
    static class CommandConstants
    {
        public static Dictionary<string, string> ConstantCommands { get; set; } = new Dictionary<string, string>();

        public static void InitiliseCommandConstants()
        {
            DataReader.ImportCommandData("look");
        }

        public static void AddCommand(string synonym, string command)
        {
            ConstantCommands.Add(synonym, command);
        }

    }
}
