using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public struct DateCounter
    {
        public DateCounter() 
        { 
        
        }

        public string Name { get; set; } = null!;

        public void CalculateDifference(string date1, string date2)
        {

            var one = date1.Split("/").Select(int.Parse).ToArray();
            var two = date2.Split("/").Select(int.Parse).ToArray();

            DateTime firstDateTime = new DateTime(one[0], one[1], one[2]); //DateTime.ParseExact(date1, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime secondDateTime = new DateTime(two[0], two[1], two[2]); //DateTime.ParseExact(date2, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            Console.WriteLine(Math.Abs((firstDateTime-secondDateTime).Days));
        }
    }
}
