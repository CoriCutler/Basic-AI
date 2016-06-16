using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace AI.Collecting.Internet.Websites
{
    class Wikipedia : Internet
    {

        public static string[] wiki(string URL)
        {
            string HTML = null;

            try {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                HTML = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            
            if (HTML != null)
            {
                HTML = EditHTML(HTML, "<div id=\"content\" class=\"mw-body\" role=\"main\">", "div", true);
                string[] website = new string[2];
                website[0] = EditHTML(HTML, "<h1 id=\"firstHeading\" class=\"firstHeading\" lang=\"en\">", "h1", false);
                HTML = EditHTML(HTML, "<div id=\"mw-content-text\" lang=\"en\" dir=\"ltr\" class=\"mw-content-ltr\">", "div", true);
                website[1] = GetParagraphs(HTML);
                return website;
            }
            else
            {
                return new[] { "Error: invalid URL " + URL };
            }
        }

        //Edits the HTML code so its smaller and faster to process
        private static string EditHTML(string HTML, string Element, string type, bool trim)
        {
            if(HTML.Contains(Element))
            {
                int pFrom = HTML.IndexOf(Element) + Element.Length;
                int pTo = HTML.LastIndexOf("</" + type + ">");
                string text = HTML.Substring(pFrom, pTo - pFrom);
                if (text.ToLower().Contains("<") && !trim)
                {
                    text = Regex.Replace(text, @" ?\<.*?\>", "");
                }
                return text;
            }else
            {
                Console.WriteLine("Error: website doesnt contain " + Element);
                return null;
            }
        }

        //gets text from paragraphs
        private static string GetParagraphs(string HTML)
        {
            string text = null;
            text = EditHTML(HTML, "<p>", "p", true);
            if (text != null)
            {
                text = Regex.Replace(text, @" ?\<.*?\>", " ");
                text = Regex.Replace(text, @" ?\[.*?\]", " ");
            }
            return text;
        }
    }
}
