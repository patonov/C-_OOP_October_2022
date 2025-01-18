using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;


namespace ShuntingYardAlgorithm
{
    public class Program
    {
        public static void Main()
        {
            string input = "3+4*2/(1-5)^2^3";
            
            var parser = new SYParser();
            var tokens = parser.Tokenizer(input);
            
            var output = parser.MarshallingYardMethod(tokens);
            Console.WriteLine(string.Join(" ", output.Select(t => t.Type)));




        }
    }
}
