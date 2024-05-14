namespace BallsInBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> collorBalls = new Dictionary<string, int>();
   
            string input = Console.ReadLine()!;

            while (true)
            {
                if (input == "End")
                {
                    break;
                }

                var inputArr = input.Split(": ").ToArray();
                string color = inputArr[0];
                int balls = int.Parse(inputArr[1]);

                if (!collorBalls.ContainsKey(color))
                {
                    collorBalls.Add(color, 0);
                    collorBalls[color] = balls;
                }
                else
                {
                    collorBalls[color] += balls;
                }

                input = Console.ReadLine()!;
            }

            
            int interim = 0;

            foreach (var color in collorBalls)
            {               
                interim += color.Value;
            }

            int ballsToTakeOut = interim - 1;

            Console.WriteLine($"We should take {ballsToTakeOut} balls to be sure there is only one ball in the box. One ball garantees one color left");


        }

        

    }
}