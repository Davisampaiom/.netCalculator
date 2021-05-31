using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
namespace Calculator.NET
{
    class Program
    {
        private static void WelcomeMessage()
        {
            Console.WriteLine(
                "\n\n  --------------------------- Welcome to Calculator.NET! --------------------------\n");
        }
        //Method invoked as long as the user is running the calculator
        private static bool CalculatorOn()
        {
            var userInput = Console.ReadLine();

            if (String.IsNullOrEmpty(userInput))
            {
                const string message = "Type something! :)";
                Console.WriteLine(message);
                return true;
            }

            if (userInput.ToLower() == "exit")
                return false;

            Calculate(userInput);
            return true;
        }

        public static void Calculate(string input)
        {
            //Getting numbers and math math operators using Regex
            var numArray = Regex.Matches(input, "[0-9]+").Cast<Match>().Select(m => m.Value).ToArray();
            var opArray = Regex.Matches(input, @"[+-\/*]").Cast<Match>().Select(m => m.Value).ToArray();

            //Casting Arrays to the correct data type
            int[] numbersToBeCalculated = Array.ConvertAll(numArray, int.Parse);
            char[] operations = Array.ConvertAll(opArray, char.Parse);

            //Checking if math operators are equal or more than the numbers to be calculated
            if (operations.Length >= numbersToBeCalculated.Length)
            {
                Console.WriteLine("Wrong entry. Try again using one or more operations");
                Calculate(Console.ReadLine());
            }

            double result = numbersToBeCalculated[0];

            var j = 0;
            for (var i = 1; i < numbersToBeCalculated.Length; i++)
            {
                switch (operations[j])
                {
                    case '+':
                        {
                            result += numbersToBeCalculated[i];
                            break;
                        }
                    case '-':
                        {
                            result -= numbersToBeCalculated[i];
                            break;
                        }
                    case '*':
                        {
                            result *= numbersToBeCalculated[i];
                            break;
                        }
                    case '/':
                        {
                            result /= numbersToBeCalculated[i];
                            break;
                        }
                    default:
                        break;
                }
                j++;
            }
            Console.WriteLine("\nResult: {0}", result);
            Console.WriteLine("\nType 'Exit' to leave :( Or try another calculation :)\n");
        }

        public static void ExitAndThankYouMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(@"
              ____                                              _           _                   _ 
 / ___|    ___    ___     _   _    ___    _   _    | |   __ _  | |_    ___   _ __  | |
 \___ \   / _ \  / _ \   | | | |  / _ \  | | | |   | |  / _` | | __|  / _ \ | '__| | |
  ___) | |  __/ |  __/   | |_| | | (_) | | |_| |   | | | (_| | | |_  |  __/ | |    |_|
 |____/   \___|  \___|    \__, |  \___/   \__,_|   |_|  \__,_|  \__|  \___| |_|    (_)
                          |___/                                                       ");
            
            //Delay before exiting the app
            Thread.Sleep(2000);
        }

        private static void Main(string[] args)
        {
            WelcomeMessage();

            Console.WriteLine("-> Calculate \n");

            bool calculatorOn = true;
            while (calculatorOn)
            {
                calculatorOn = CalculatorOn();
            }

            ExitAndThankYouMessage();
        }

    }
}