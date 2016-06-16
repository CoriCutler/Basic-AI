using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AI
{
    class Hub
    {
        private static String Command = null;

        static void Main(string[] args)
        {
            Console.Title = "AI";
            Console.WriteLine("Welcome to AI");
            //load data from database
            load();
            while (true)
            {
                Command = Console.ReadLine();
                if (Command != null)
                {
                    Commands.Commands.Hub(Command);
                }
                Command = null;
            }
        }

        private static void load()
        {
            Console.WriteLine("Loading data...");
            Database.Database.Load();
            Console.WriteLine("Loaded " + Database.Database.Dir_Length() + " files");
        }
    }
}
