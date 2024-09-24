using System;

namespace hadej
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 101); // Generates a number between 1 and 100 inclusive
            int guess = 0;
            bool validInput;

            Console.WriteLine("Pick a number between 1-100");

            while (guess != number)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (validInput = int.TryParse(input, out guess))
                {
                    if (guess < 1 || guess > 100)
                    {
                        Console.WriteLine("The number is out of range. Please enter a number between 1 and 100.");
                        validInput = false; 
                    }
                    else if (guess > number)
                    {
                        Console.WriteLine("The number is lower");
                    }
                    else if (guess < number)
                    {
                        Console.WriteLine("The number is higher");
                    }
                    else
                    {
                        Console.WriteLine("You Won! The number was: " + guess);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 100.");
                }
            }
        }
    }
}
