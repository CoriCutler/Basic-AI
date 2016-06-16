using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Commands.Help
{
    class Help
    {

        private static String[] help = { "Exit", "Clear", "Help" , "Dir", "Search" };


        public static void hub(String command)
        {
            switch (command.ToLower().Trim())
            {
                default:
                    Print();
                    break;
            }
        }

        private static void Print()
        {
            Console.WriteLine();
            foreach (String _help in help)
            {
                Console.WriteLine(_help.PadLeft(1 + _help.Length, '-'));
            }
            Console.WriteLine();
        }
    }
}
