using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AI.Database
{
    class Database
    {
        //protected
        protected static String path = "Database\\";
        protected static ArrayList paths = new ArrayList();
        protected static List<Tuple<string, int>> Dir = new List<Tuple<string, int>>();

        //private
        private static Boolean loaded = false;

        public static void Load()
        {
            if (!loaded)
            {
                Loading.Loading_hub.loading();
                loaded = true;
            }else{
				Reload();
			}
            Dir.Add(new Tuple<string, int>("Database", 0));
            if (paths.Capacity > 0)
            {
                
                foreach (String _path in paths)
                {
                    Sorting.SortingPaths.sort(_path);
                }
            }
        }
		
		public static void Reload(){
			Dir = null;
			loaded = false;
			Load();
		}

        public static int Dir_Length()
        {
            return Dir.Count;
        }
    }
}
