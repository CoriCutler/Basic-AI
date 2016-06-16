using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI.Database.Folders.Files
{
    class File_Recogniser : Database
    {

        public static void text(string file)
        {
            string path = getpath(file);
            if (path != null)
            {
                foreach (string sentence in readfile(path))
                {
                    Console.WriteLine(sentence);
                }
            }else
            {
                Console.WriteLine("ERROR: Couldn't find file");
            }
        }

        private static string getpath(string file)
        {
            foreach(string path in paths)
            {
                if (path.Contains(file))
                {
                    return path;
                }
            }
            return null;
        }

        private static string[] readfile(string path)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                 text = sr.ReadToEnd();
            }

            if(text != null)
            {
                return text.Split('.');
            }
                return null;
        }
    }
}
