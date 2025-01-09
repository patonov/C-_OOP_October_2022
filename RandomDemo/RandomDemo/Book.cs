using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book other)
        {
            var result = this.Year.CompareTo(other.Year);
            if (result == 0)
            { 
                result = this.Title.CompareTo(other.Title);
            }
            return result;
        }

        public override string ToString() 
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
