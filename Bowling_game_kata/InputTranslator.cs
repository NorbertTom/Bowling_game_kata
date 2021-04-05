using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Bowling_game_kata
{
    class InputTranslator
    {
        public InputTranslator()
        { }

        public static void addInputResultsToBowlingGame(BowlingGame game, string input)
        {
            int inputIterator = 0;
            int round = 0;
            while (round < 12 && inputIterator < input.Length)
            { 
                if (input[inputIterator] == ' ')
                {
                    ++round;
                }
                else
                {
                    int pinsTakenDownInRoll = translateInputCharToInt(ref input, inputIterator);
                    game.addThrowToRound(round, pinsTakenDownInRoll);
                }
                inputIterator++;
            }
        }

        private static int translateInputCharToInt(ref string input, int currentPosition)
        {
            Debug.Assert(currentPosition >= 0, "invalid currentPosition");

            int result = 0;
            char inputChar = input[currentPosition];
            if (inputChar > 48 && inputChar < 58)
            {
                result = (int)inputChar - 48;
            }
            else if (inputChar == '-')
            { }
            else if (inputChar == 'X')
            {
                result = 10;
            }
            else if (inputChar == '/')
            {
                result = 10 - translateInputCharToInt(ref input, currentPosition - 1);
            }
            else 
            {
                Debug.Assert(false, "Invalid char");
            }
            return result;
        }
    }
}
