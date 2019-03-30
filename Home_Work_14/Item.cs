using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Work_14
{
    public class Item
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string PublicDate { get; set; }

        public Item(string title, string link, string description, string publicDate)
        {
            Title = title;
            Link = link;
            Description = description;
            PublicDate = publicDate;
        }

        public Item()
        {

        }
    }
}
