using Fractions;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace RandomDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            //string[] input = Console.ReadLine().Split().ToArray();
            //int counter = 0;

            //while (true)
            //{
            //    for (int i = 0; i < input.Length; i++)
            //    {
            //        sb.Append(input[random.Next(0, input.Length)] + " ");
            //    }
            //    counter++;

            //    if (sb.ToString().TrimEnd() == string.Join(" ", input))
            //    {
            //        Console.WriteLine(counter);
            //        break;
            //    }
            //    sb.Clear();
            //}

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next());

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(10, 101));

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(100, 101));

            //for (int i = 0; i <= 10; i++)
            //    Console.WriteLine(random.Next(-100, 100));

            //Random randomWithSeed = new Random(5);

            //for (int i = 0; i < 10; i++)
            //Console.WriteLine(randomWithSeed.Next(20));


            //string inputDate = Console.ReadLine()!;

            //DateTime dateTime;

            //dateTime = DateTime.ParseExact(inputDate!, "d-M-yyyy", CultureInfo.InvariantCulture);

            //dateTime = new DateTime(int.Parse(inputDate.Split("-")[2]), 
            //    int.Parse(inputDate.Split("-")[1]), 
            //    int.Parse(inputDate.Split("-")[0]));

            //bool isOk = DateTime.TryParseExact(inputDate, 
            //    "d-M-yyyy", 
            //    CultureInfo.InvariantCulture, 
            //    DateTimeStyles.None, 
            //    out dateTime);

            //Console.WriteLine(dateTime.DayOfWeek);


            //var input1 = Console.ReadLine();
            //var input2 = Console.ReadLine();

            DateCounter counter = new DateCounter();
            counter.Name = "Pesho countera";

            //counter.CalculateDifference(input1, input2);

            DateCounter counterNew = counter;
            counterNew.Name = "Bai Mitko countera";

            Console.WriteLine(counter.Name);
            Console.WriteLine(counterNew.Name);

            //string[] inputArr = Console.ReadLine().Split(" ").ToArray();
            //string sign = inputArr[1];
            //int[] intsFirst = inputArr[0].Split("/").Select(int.Parse).ToArray();
            //int[] intsSecond = inputArr[2].Split("/").Select(int.Parse).ToArray();

            //Fraction fractionOne = new Fraction(intsFirst[0], intsFirst[1]);
            //Fraction fractionTwo = new Fraction(intsSecond[0], intsSecond[1]);

            //if (sign == "+")
            //{
            //    Console.WriteLine($"{fractionOne} {sign} {fractionTwo} = {fractionOne + fractionTwo}");
            //}
            //else 
            //{
            //    Console.WriteLine($"{fractionOne} {sign} {fractionTwo} = {fractionOne - fractionTwo}");
            //}


            //PersonWithCopyConstructor personWithCopyCtor = new PersonWithCopyConstructor("Pesho", 22, 80.01);
            //PersonWithCopyConstructor secondPersonWithCopyCtor = new PersonWithCopyConstructor(personWithCopyCtor);

            //secondPersonWithCopyCtor.Name = "Muncho";
            //secondPersonWithCopyCtor.Age = 34;
            //secondPersonWithCopyCtor.Weight = 70.50;


            //Console.WriteLine(personWithCopyCtor.Name + " " + personWithCopyCtor.Age + " " + personWithCopyCtor.Weight);
            //Console.WriteLine(secondPersonWithCopyCtor.Name + " " + secondPersonWithCopyCtor.Age + " " + secondPersonWithCopyCtor.Weight);

            //int width = int.Parse(Console.ReadLine());
            //int height = int.Parse(Console.ReadLine());
            //string color = Console.ReadLine();

            //Rectangle rectangle = new Rectangle();
            //rectangle.Width = width; 
            //rectangle.Height = height;
            //rectangle.Color = color;

            //Console.WriteLine($"Rect({rectangle.Width}, {rectangle.Height}, {rectangle.Color}) has area {(rectangle.Width * rectangle.Height)}.");



        }
    }
}
