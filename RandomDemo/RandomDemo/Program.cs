﻿using Fractions;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Linq;
using RandomDemo.RawData;
using System.Collections;

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

            //DateCounter counter = new DateCounter();
            //counter.Name = "Pesho countera";

            ////counter.CalculateDifference(input1, input2);

            //DateCounter counterNew = counter;
            //counterNew.Name = "Bai Mitko countera";

            //Console.WriteLine(counter.Name);
            //Console.WriteLine(counterNew.Name);

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


            //Person person = new Person(88.01);
            //person.Name = "Muncho";
            //person.Age = 44;
            //Console.WriteLine($"{person.Name} {person.Age} {person.Weight} {(person.Proportion):f2}");

            //PersonWithStaticCtor personWithStatic = new PersonWithStaticCtor();
            //personWithStatic.Name = "Tralalayko";
            //personWithStatic.Age = 101;
            //personWithStatic.Weight = 88.20;
            //Console.WriteLine(string.Join(" ", personWithStatic.Name, personWithStatic.Age, personWithStatic.Weight));


            //List<Card> cards = new List<Card>();

            //Card firstCard = new Card() { Face = "A", Suit = "Spades" };
            //Card secondCard = new Card() { Face = "J", Suit = "Diamonds" };
            //Card thirdCard = new Card() { Face = "Q", Suit = "Clubs" };
            //Card fourthCard = new Card() { Face = "10", Suit = "Hearts" };

            //cards.Add(firstCard);
            //cards.Add(secondCard);
            //cards.Add(thirdCard);
            //cards.Add(fourthCard);

            //foreach (Card card in cards) 
            //{ 
            //    card.Print();
            //}

            //string[] faces = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };
            //string[] suits = new string[4] { "Spades", "Diamonds", "Clubs", "Hearts" };

            //for (int i = 0; i < faces.Length; i++)
            //{
            //    foreach (string suit in suits)
            //    {
            //        cards.Add(new Card() { Face = faces[i], Suit = suit });                
            //    }
            //}

            //Random rnd = new Random();

            //for (int i = 0; i < cards.Count; i++) 
            //{ 
            //    int rIndex = rnd.Next(0, cards.Count);
            //    Card oldCard = cards[i];
            //    cards[i] = cards[rIndex];
            //    cards[rIndex] = oldCard;
            //}

            //foreach (Card card in cards)
            //{ 
            //    card.Print();
            //}

            //CardsDeck deck = new CardsDeck();

            //var input = Console.ReadLine();

            //while (input != "End")
            //{ 
            //    var cmd = input.Split(" ").ToArray();

            //    if (cmd[0] == "Add")
            //    {
            //        deck.Add(new Card() { Face = cmd[1], Suit = cmd[2] });
            //    }
            //    else if (cmd[0] == "Print")
            //    {
            //        deck.Print();
            //    }
            //    else if (cmd[0] == "Get")
            //    {
            //        deck.GetAllCards();
            //    }
            //    else if (cmd[0] == "Randomize")
            //    {
            //        deck.Randomize();
            //    }
            //    else if (cmd[0] == "Clear")
            //    {
            //        deck.Clear();
            //    }

            //    input = Console.ReadLine();
            //}

            //BigInteger big = new BigInteger();
            //big = 1;
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 1; i <= n; i++)
            //{
            //    big *= i;
            //}
            //Console.WriteLine(big);

            //StateOfMind state = StateOfMind.Depressed;

            //var excited = Enum.Parse(typeof(StateOfMind), "Excited");

            //Console.WriteLine((int)excited);

            //Car car = new Car();

            //car.Make = "Volga";
            //car.Model = "4200";
            //car.Year = 1972;

            //Console.WriteLine($"Make {car.Make}\nModel {car.Model} \nYear {car.Year}");

            //int n = int.Parse(Console.ReadLine());
            //List<Employee> employees = new List<Employee>();

            //for (int i = 0; i < n; i++)
            //{
            //    var inputArr = Console.ReadLine().Split(" ").ToArray();

            //    if (inputArr.Length == 4)
            //    {
            //        employees.Add(new Employee(inputArr[0], decimal.Parse(inputArr[1]), inputArr[2], inputArr[3]));
            //    }
            //    else if (inputArr.Length == 5)
            //    {
            //        if (inputArr[4].Contains("@"))
            //        {
            //            employees.Add(new Employee(inputArr[0], decimal.Parse(inputArr[1]), inputArr[2], inputArr[3], inputArr[4]));
            //        }
            //        else
            //        {
            //            employees.Add(new Employee(inputArr[0], decimal.Parse(inputArr[1]), inputArr[2], inputArr[3], int.Parse(inputArr[4])));
            //        }
            //    }
            //    else if (inputArr.Length == 6)
            //    {
            //        employees.Add(new Employee(inputArr[0], decimal.Parse(inputArr[1]), inputArr[2], inputArr[3], inputArr[4], int.Parse(inputArr[5])));
            //    }
            //}

            //string department = employees.GroupBy(e => e.Department)
            //    .Select(g => new { DepartmentName = g.Key, AgerageSalary = g.Average(e => e.Salary) })
            //    .OrderByDescending(g => g.AgerageSalary)
            //    .First()
            //    .DepartmentName;

            //Console.WriteLine($"Highest Average Salary: {department}");

            //employees.
            //Where(e => e.Department == department)
            //.OrderByDescending(e => e.Salary)
            //.ToList()
            //.ForEach(Console.WriteLine);


            //Person pp = new Person(10);

            //Console.WriteLine(pp.Weight);

            //int n = int.Parse(Console.ReadLine());
            //List<CarInRacing> cars = new List<CarInRacing>(); 

            //for (int i = 0; i < n; i++) 
            //{ 
            //    var input = Console.ReadLine().Split(" ").ToArray();
            //    cars.Add(new CarInRacing(input[0], double.Parse(input[1]), double.Parse(input[2])));
            //}

            //string command = Console.ReadLine();

            //while (command != "End") 
            //{
            //    var commandArr = command.Split(" ");

            //    CarInRacing carInRacing = cars.First(c => c.Model == commandArr[1]);

            //    if (carInRacing.Drive(int.Parse(commandArr[2])) == false)
            //    {
            //        Console.WriteLine("Insufficient fuel for the drive");
            //    }
            //    command = Console.ReadLine();
            //}

            //cars.ForEach(Console.WriteLine);

            //int n = int.Parse(Console.ReadLine());
            //List<CargoCar> cargoCars = new List<CargoCar>();

            //for (int i = 0; i < n; i++) 
            //{
            //    var tokens = Console.ReadLine().Split(" ");

            //    Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));

            //    Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);

            //    List<Tyre> tyres = new List<Tyre>();
            //    tyres.Add(new Tyre(double.Parse(tokens[5]), int.Parse(tokens[6])));
            //    tyres.Add(new Tyre(double.Parse(tokens[7]), int.Parse(tokens[8])));
            //    tyres.Add(new Tyre(double.Parse(tokens[9]), int.Parse(tokens[10])));
            //    tyres.Add(new Tyre(double.Parse(tokens[11]), int.Parse(tokens[12])));

            //    cargoCars.Add(new CargoCar(tokens[0], engine, cargo, tyres));
            //}

            //string newCommand = Console.ReadLine();

            //if (newCommand == "fragile")
            //{
            //    cargoCars.Where(c => c.Cargo.CargoType == "fragile"
            //    && c.Tyres.Any(t => t.Pressure < 1)).Select(c => c.Model).ToList().ForEach(Console.WriteLine);
            //}
            //else if (newCommand == "flamable")
            //{
            //    cargoCars.Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
            //        .Select(c => c.Model).ToList().ForEach(Console.WriteLine);
            //}

            CustomArrayList shopingList = new CustomArrayList();


            //shopingList.Add("Tomato");
            //shopingList.Add("Bread");
            //shopingList.Add("Cheese");
            //shopingList.Add("Cucumbers");
            //shopingList.Add("Chocolate");
            //shopingList.Add(7);
            //shopingList.Add("Coke");

            //for (int i = 0; i < shopingList.Count; i++)
            //{
            //    Console.WriteLine(shopingList[i]);
            //}

            //shopingList.Insert(1, "Lemon");
            //Console.WriteLine(shopingList.IndexOf("Chocolate"));
            //Console.WriteLine(shopingList.Contains("Coke"));
            //Console.WriteLine(shopingList[1]);
            //Console.WriteLine(shopingList.Count);
            //shopingList.Remove(3);
            //shopingList.Remove("Tomato");
            //Console.WriteLine(shopingList.Count);

            //LinkedList shoppingList = new LinkedList();

            //shoppingList.Add("Biscuits");
            //shoppingList.Add("Chips");
            //shoppingList.Add("Cheese");
            //shoppingList.Add("Pickles");
            //shoppingList.Add("Ice cream");
            //shoppingList.Add(7);
            //shoppingList.Add("Honey");

            //for (int i = 0; i < shoppingList.Count; i++)
            //{
            //    Console.WriteLine(shoppingList[i]);
            //}


            //Console.WriteLine(shoppingList.IndexOf("Ice cream"));
            //Console.WriteLine(shoppingList.Contains("Honey"));
            //Console.WriteLine(shoppingList[1]);
            //Console.WriteLine(shoppingList.Count);
            //shoppingList.Remove(3);
            //shoppingList.Remove("Chips");
            //Console.WriteLine(shoppingList.Count);

            var stack = new CustomStack();
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            //Console.WriteLine(stack.Count);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Peek());
            //stack.ForEach(x => Console.WriteLine(x));

            //var queue = new CustomQueue();

            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //queue.Enqueue(1);

            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //queue.Enqueue(4);
            //queue.Enqueue(5);
            //queue.Enqueue(6);

            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //var first = queue.Dequeue();
            //Console.WriteLine("First = {0}", first);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //queue.Enqueue(-7);
            //queue.Enqueue(-8);
            //queue.Enqueue(-9);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //first = queue.Dequeue();
            //Console.WriteLine("First = {0}", first);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //queue.Enqueue(-10);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //first = queue.Dequeue();
            //Console.WriteLine("First = {0}", first);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //LinkedList linkedList = new LinkedList();
            //linkedList.Add("Bear");
            //linkedList.Add("Tiger");
            //linkedList.Add("Wolf");
            //linkedList.Add("Spider");

            //Console.WriteLine(linkedList.Count);
            //Console.WriteLine(linkedList[2]);
            //Console.WriteLine(linkedList.IndexOf("Wolf"));
            //Console.WriteLine(linkedList.Contains("Wolf"));
            //Console.WriteLine(linkedList.IndexOf("Wolf"));
            //Console.WriteLine(linkedList.Remove(2));

            //for (int i = 0; i < linkedList.Count; i++) 
            //{
            //    Console.WriteLine(linkedList[i]);
            //}


            //CustomGenericCollection<string> stringCollection = new CustomGenericCollection<string>();

            //stringCollection.Add("One");
            //stringCollection.Add("Two");
            //stringCollection.Add("Three");

            //stringCollection.Remove();

            //Console.WriteLine(string.Join(" ", stringCollection.Print()));
            //Console.WriteLine(stringCollection.Count);

            //stringCollection.Add("Three");
            //Console.WriteLine(string.Join(" ", stringCollection.Print()));
            //Console.WriteLine(stringCollection.Count);

            //CustomGenericCollection<int> intCollection = new CustomGenericCollection<int>();
            //intCollection.Add(1);
            //intCollection.Add(2);
            //intCollection.Add(3);

            //intCollection.Remove();

            //Console.WriteLine(string.Join(" ", intCollection.Print()));
            //Console.WriteLine(intCollection.Count);

            //intCollection.Add(3);
            //Console.WriteLine(string.Join(" ", intCollection.Print()));
            //Console.WriteLine(intCollection.Count);

            //Box<int> box = new Box<int>();
            //box.Add(1);
            //box.Add(2);
            //box.Add(3);
            //Console.WriteLine(box.Remove());
            //box.Add(4);
            //box.Add(5);
            //Console.WriteLine(box.Remove());

            //string[] strings = ArrayCreator.Create(5, "Pesho");
            //int[] integers = ArrayCreator.Create(10, 33);

            //EqualityScale<string> equalityScale = new EqualityScale<string>("Box", "Box");

            //Console.WriteLine(equalityScale.AreEqual());

            //int[] numbers = Console.ReadLine()!.Split(", ").Select(int.Parse).ToArray();

            //BubbleSort.BubbleSorter(numbers);

            //Console.WriteLine(string.Join(" ", numbers));

            StoreWithGenericConstraint<Person> personeStore = new StoreWithGenericConstraint<Person>();
            Person persone = new Person() { Name = "Pesho", Age = 18, Weight = 71.5 };

            personeStore.StoredValue = persone;

            Console.WriteLine($"{personeStore.StoredValue.Name} {personeStore.StoredValue.Age}");

            StoreWithGenericConstraint<string> storeOfMessages = new StoreWithGenericConstraint<string>();
            storeOfMessages.StoredValue = "Greetings from Blagoevgrad";

            Console.WriteLine(storeOfMessages.StoredValue);

            StoreWithGenericConstraint<Box<int>> boxStoreOfInts = new StoreWithGenericConstraint<Box<int>>();

            Box<int> box = new Box<int>();
            boxStoreOfInts.StoredValue = box;

            boxStoreOfInts.StoredValue.Add(101);
            boxStoreOfInts.StoredValue.Add(202);
            boxStoreOfInts.StoredValue.Add(303);

            Console.WriteLine(boxStoreOfInts.StoredValue.Count);

            StoreWithTwoGenericConstraints<int, string> complesStore = new StoreWithTwoGenericConstraints<int, string>();

            complesStore.KeyParameter = 1;
            complesStore.ValueParameter = "Greetings";

            Console.WriteLine($"{complesStore.KeyParameter} => {complesStore.ValueParameter}");

        }
    }
}
