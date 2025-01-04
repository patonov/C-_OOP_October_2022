using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Book
    {
        public Book(string title, int year, params string[] authors) 
        { 
            this.Year = year;
            this.Title = title;
            this.Authors = authors.ToList();
        }

        public int Year { get; set; }

        public string Title { get; set; } = null!;

        public List<string> Authors { get; set; } = new List<string>();
    }
}
