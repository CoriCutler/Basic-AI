using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Collecting.Internet
{
    class Internet
    {
        public static void search(String URL)
        {
            if (URL.Contains('.'))
            {
                String[] domain = URL.Split('.');

                if (domain.Length > 2)
                {
                    if (domain[1] != null)
                    {
                        //adds http to the start of URL if doesnt contain it
                        if (!URL.ToLower().StartsWith("http://") || !URL.ToLower().StartsWith("https://")) URL = "http://" + URL;

                        switch (domain[1].ToLower().Trim())
                        {
                            case "wikipedia":
                                if(URL.Equals("http://en.wikipedia.org/wiki/Special:Random"))
                                {
                                    Console.Write("Enter number of Time: ");
                                    int times;
                                    if (int.TryParse(Console.ReadLine(), out times))
                                    {
                                        Console.WriteLine(times);
                                        for (int i = 0; i < times; i++)
                                        {
                                            Console.Write(i + ")");
                                            Database.Saving.Saving.SaveFile(Websites.Wikipedia.wiki(URL));
                                        }
                                        Console.WriteLine("Finished");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not an integer!");
                                    }
                                }
                                else
                                {
                                    Database.Saving.Saving.SaveFile(Websites.Wikipedia.wiki(URL));
                                }
                                
                                break;
                            default:
                                Console.WriteLine("Error: Unknown domain");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid URL");
            }
        }
    }
}
