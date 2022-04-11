using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfZad5
{
    public class Movie
    {
        public string title;
        public DateTime premiereDate;
        public string description;

        public Movie(string title, DateTime premiereDate, string description)
        {
            this.title = title;
            this.premiereDate = premiereDate;
            this.description = description;
        }
    }
}
