using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebForm2
{
    public class Movie
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public int year { get; set; }

        override
        public String ToString()
        {
            return $"ID: {ID.ToString().PadRight(5,' ')} Title: {title.PadRight(35, ' ')}  Rating: {rating.PadRight(5,' ')}  Year: {year}";
        }
    }
}