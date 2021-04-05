using System;
using Xunit;
using Bowling_game_kata;

namespace Bowling_game_kata_tests
{
    public class InputTranslatorUnitTests
    {

        [Fact]
        public void inputTranslatorTests()
        {
            {
                BowlingGame game = new BowlingGame();
                string input = "52";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(7, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "4/";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(10, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "4/ 4-";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(18, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "4/ X -2";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(34, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "X X X X X X X X X X X X";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(300, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "-- -- -- -- -- -- -- -- -- -- X X";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(0, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "-- -- -- -- -- -- -- -- -- X X X";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(30, game.countScore());
            }
            {
                BowlingGame game = new BowlingGame();
                string input = "12 34 52 11 62 1/ 6/ 61 X X 32";
                InputTranslator.addInputResultsToBowlingGame(game, input);
                Assert.Equal(104, game.countScore());
            }
        }
    }
}
