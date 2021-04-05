using System;

namespace Bowling_game_kata
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the results. Please use numbers as a quantity of pins taken down in a roll\n" +
                "Please use - in case no pin was taken down\n" +
                "Please use / in case of a spare\n" +
                "Please use X in case of a strike\n" +
                "Please separate frames with a space\n" +
                "Example of valid input:\n" +
                "X 23 4/ 11 -5 43 X -- 32 1/ 5\n");            
            Console.Write("Your input: ");

            string userInput = Console.ReadLine();
            
            BowlingGame game = new BowlingGame();
            InputTranslator.addInputResultsToBowlingGame(game, userInput);
            int score = game.countScore();
            Console.WriteLine("Score of the game is: " + score);
        }
    }
}
