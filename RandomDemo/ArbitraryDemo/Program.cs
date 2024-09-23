using RandomDemo;

namespace ArbitraryDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Console.WriteLine(person.Name = "Muncho" + " "
                + person.Age + " " + person.Weight + " "
               // + person.Proportion -----> Can not be accessed due to the access modifier.
                );


            Mammoth stupid = new Mammoth();

            
        }
    }

    file class Mammoth : ArbitraryPerson
    {
        public Mammoth() { }

        public string? Description { get; set; }
    }
}
