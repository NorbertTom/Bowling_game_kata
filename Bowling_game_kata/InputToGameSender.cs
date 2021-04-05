using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Bowling_game_kata
{
    static class InputToGameSender
    {

        public static void sendInputResultsToBowlingGame(BowlingGame game, string input)
        {
            int inputIterator = 0;
            int frame = 0;
            while (frame < 12 && inputIterator < input.Length)
            { 
                if (input[inputIterator] == ' ')
                {
                    ++frame;
                }
                else
                {
                    int pinsTakenDownInRoll = translateInputCharToInt(ref input, inputIterator);
                    game.addThrowToFrame(frame, pinsTakenDownInRoll);
                }
                inputIterator++;
            }
        }

        private static int translateInputCharToInt(ref string input, int currentPosition)
        {
            Debug.Assert(currentPosition >= 0, "invalid currentPosition");

            int result = 0;
            char inputChar = input[currentPosition];
            if (isCharacterAsciiNumber(inputChar))
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

        private static bool isCharacterAsciiNumber(char character)
        {
            bool result = false;
            if (character > 48 && character < 58)
            {
                result = true;
            }
            return result;
        }
    }
}
