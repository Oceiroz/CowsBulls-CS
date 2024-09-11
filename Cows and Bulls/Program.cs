using System;
using System.Collections.Generic;
namespace Cows_and_Bulls
{
    class Program
    {
        public static string answer = GenerateNumber();
        static void Main(string[] args)
        {
            CowsBulls(answer);
        }
        static string GetInput(string inputMessage)
        {
            string rawInput;
            while (true)
            {
                Console.WriteLine($"{inputMessage}\n");
                rawInput = Console.ReadLine();
                var inputLen = rawInput.Length;
                try
                {
                    if (inputLen == 4)
                    {
                        int userInput = int.Parse(rawInput);
                    }
                    else
                    {
                        throw new FormatException("This is not a 4-digit number");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            return rawInput;
        }

        static string GenerateNumber()
        {
            Random rnd = new Random();
            int answer = rnd.Next(0, 9999);
            string formattedAnswer = answer.ToString("D4");
            Console.WriteLine(formattedAnswer);
            return formattedAnswer;
        }


        static void CowsBulls(string answer)
        {
            while (true)
            {
                string guess = GetInput("Please enter a 4 digit number");
                char[] guessArray = guess.ToCharArray();
                char[] answerArray = answer.ToCharArray();
                var x = 0;
                int y = 0;
                int cow = 0;
                int bull = 0;
                List<int> duplicate = new() {1, 1, 1, 1};
                foreach (char value1 in answerArray)
                {
                    foreach (char value2 in guessArray)
                    {
                        if (value1 == value2 && x == y)
                        {
                            cow++;
                            duplicate[y] = 0;
                            break;
                        }
                        else if (value1 == value2 && x != y && duplicate[y] == 1)
                        {
                            bull++;
                            duplicate[y] = 0;
                            break;
                        }
                        y++;
                    }
                    x++;
                    y = 0;
                }
                Console.WriteLine($"cow: {cow}");
                Console.WriteLine($"bull: {bull}");

                if (cow == 4)
                {
                    Console.WriteLine("You win!!");
                    break;
                }
            }
        }
    }
}
