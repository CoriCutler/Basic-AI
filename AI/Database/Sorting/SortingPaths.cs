using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Database.Sorting
{
    class SortingPaths : Database
    {

        public static void sort(String path)
        {
            int level = 0;

            if (path.Contains("\\"))
            {
                foreach (char letter in path)
                {
                    if (letter.Equals("\\"[0]))
                    {
                        level += 1;
                    }
                }
            }
            else
            {
                level = 1;
            }

            Dir.Add(new Tuple<string, int>(path, level));
        }

        public static void PrintDir()
        {
			hub.load();
            if (Dir.Capacity > 0)
            {
                foreach (Tuple<string, int> dir in Dir)
                {
                    String[] path = dir.Item1.Split('\\');
                    if (!path[path.Length - 1].Contains('.'))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.WriteLine(path[path.Length - 1].PadLeft((5 * dir.Item2) + path[path.Length - 1].Length, ' '));
                    Console.ResetColor();
                }
            }
        }
    }
}
