using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AI.Database.Loading
{
    class Loading_hub : Database
    {

        private static ArrayList DirTree = new ArrayList();

        public static void loading()
        {
            checkFolders(path);
            foreach (String dir in DirSearch(path))
            {
                paths.Add(dir);
            }
        }

        //checks that all the folders exist
        private static void checkFolders(String path)
        {
            //database
            if (!Directory.Exists(path)) MakeFolders(path);
            //unsorted
            if (!Directory.Exists(path + "Unsorted")) MakeFolders(path + "Unsorted");
        }

        //creates any folders that dont exist
        private static void MakeFolders(String path)
        {
            Console.WriteLine("Making Directory: " + path);
            Directory.CreateDirectory(path);
        }

        //gets all files in a certain folder
        protected static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.Add(d);
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }
    }
}
