using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI.Commands
{
    class Commands
    {
        public static void Hub(String command)
        {
            switch (command.ToLower().Trim())
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "help":
                    Help.Help.hub(command);
                    break;
                case "dir":
                    Database.Sorting.SortingPaths.PrintDir();
                    break;
                case "search":
                    Console.Write("Enter URL: ");
                    Collecting.Internet.Internet.search(Console.ReadLine());
                    break;
                case "read":
                    Console.Write("Enter path: ");
                    Database.Folders.Files.File_Recogniser.text(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine(command + " is an invalid Command");
                    break;
            }
        }

    }
}
