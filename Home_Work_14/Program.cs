using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Home_Work_14
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument XmlDocument = new XmlDocument();
            const string URL_ADDRESS = "https://habr.com/ru/rss/interesting/";

            XmlDocument.Load(URL_ADDRESS);
            List<Item> items = new List<Item>();

            foreach (XmlNode titleNode in XmlDocument.SelectNodes(@"/rss/channel/item"))
            {
                string title = titleNode.SelectSingleNode("title").InnerText;

                string link = titleNode.SelectSingleNode("link").InnerText;

                string description = titleNode.SelectSingleNode("description").InnerText;

                string publicDate = titleNode.SelectSingleNode("pubDate").InnerText;

                items.Add(new Item(title, link, description, publicDate));
            }

            foreach (Item item in items)
            {
                Console.WriteLine($"Title - {item.Title}\n");
                Console.WriteLine($"Link - {item.Link}\n");
                Console.WriteLine($"Description - {item.Description}\n");
                Console.WriteLine($"PubDate - {item.PublicDate}\n\n\n");
            }

            XmlDocument secondXmlDocument = new XmlDocument();

            XmlElement students = secondXmlDocument.CreateElement("Students");
            secondXmlDocument.AppendChild(students);

            XmlElement student = secondXmlDocument.CreateElement("Student");
            student.SetAttribute("FullName", "Yerik Dilnaz");
            student.SetAttribute("Hometown", "Nur-Sultan(Astana)");
            student.SetAttribute("University", "Moscow State University");


            Console.WriteLine("---------------------------------------------------");
            students.AppendChild(student);
            Console.WriteLine($"Ф.И.О - {secondXmlDocument.DocumentElement.FirstChild.Attributes["FullName"].Value}\n");
            Console.WriteLine($"Родной город - {secondXmlDocument.DocumentElement.FirstChild.Attributes["Hometown"].Value}\n");
            Console.WriteLine($"Университет - {secondXmlDocument.DocumentElement.FirstChild.Attributes["University"].Value}");
            Console.ReadKey();
        }
    }
}
