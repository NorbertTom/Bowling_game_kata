using System;

namespace Bowling_game_kata
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the results. Please use numbers as a quantity of pins taken down in a roll");
            Console.WriteLine("Please use - in case no pin was taken down");
            Console.WriteLine("Please use / in case of a spare");
            Console.WriteLine("Please use X in case of a strike");
            Console.WriteLine("Please separate frames with a space");
            Console.WriteLine("Example of valid input:");
            Console.WriteLine("X 23 4/ 11 -5 43 X -- 32 1/ 5");

            Console.Write("Your input: ");
            string userInput = Console.ReadLine();
            
            BowlingGame game = new BowlingGame();
            InputTranslator.addInputResultsToBowlingGame(game, userInput);
            int score = game.countScore();
            Console.WriteLine("Score of the game is: " + score);
        }
    }
}
