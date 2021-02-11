using System;
using System.Linq;
using Venminder.Classes;

namespace Venminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Bowling bowl = new Bowling();
            Console.WriteLine("Let's start Bowling!!");
            try
            {
                foreach (var frame in bowl.Frames)
                {
                    for (int i = 0; i < frame.ThrowList.Count; i++)
                    {
                        Console.WriteLine("Enter number of pins knocked down this turn and press Enter");
                        var inputThrow = Console.ReadLine();
                        if (int.TryParse(inputThrow, out int userInput))
                        {
                            if (ValidateInput(userInput))
                            {
                                bowl.Roll(userInput, frame);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Score(bowl);
        }

        static void Score(Bowling bowl)
        {
            var finalScore = bowl.Frames.Sum(frame => frame.Score);
            Console.WriteLine($"Your Final Score is {finalScore}");
        }

        static bool ValidateInput(int userInput)
        {
            if (userInput < 0 || userInput > 10)
            {
                Console.WriteLine("Please enter a valid number of pins knocked over.");
                return false;
            }
            return true;
        }
    }
}
