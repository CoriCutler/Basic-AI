using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AI.Database.Saving
{
    class Saving : Database
    {

        private static char[] invalidsymbol = "/'!@#$%^&*()://?\"<>".ToCharArray();

        public static void SaveFile(string[] information)
        {
            if(information.Length == 2)
            {
                if (!checkFile(information[0]))
                {
                    if(information[1] != null && information[0].IndexOfAny(invalidsymbol) == -1)
                    {
                        File.WriteAllText(path + "Unsorted\\" + information[0].Trim() + ".txt", information[1]);
                        Console.WriteLine("Saved " + information[0]);
                    }
                }
                else
                {
                    Console.WriteLine("Already exists");
                }
            }
        }

        //checks if file exists
        private static Boolean checkFile(string title)
        {
            foreach(string path in paths)
            {
                if(path.Contains(title.Trim() + ".txt"))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
