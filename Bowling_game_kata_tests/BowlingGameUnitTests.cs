using System;
using Xunit;

namespace Bowling_game_kata_tests
{
    public class BowlingGameUnitTests
    {
        [Fact]
        public void addingThrowResults()
        {
            Bowling_game_kata.BowlingGame game = new Bowling_game_kata.BowlingGame();
            int roundNr = 0;
            int pinsTakenDown = 5;
            Bowling_game_kata.FrameResults round0 = new Bowling_game_kata.FrameResults();
            round0 = game.addThrowToFrame(roundNr, pinsTakenDown);
            Assert.Equal(pinsTakenDown, round0.getSumOfPinsTakenDown());

            roundNr = 5;
            pinsTakenDown = 9;
            Bowling_game_kata.FrameResults round5 = new Bowling_game_kata.FrameResults();
            round5 = game.addThrowToFrame(roundNr, pinsTakenDown);
            Assert.Equal(pinsTakenDown, round5.getSumOfPinsTakenDown());
            Assert.Equal(5, round0.getSumOfPinsTakenDown());
        }

        [Fact]
        public void countScore()
        {
            Bowling_game_kata.BowlingGame game = new Bowling_game_kata.BowlingGame();
            Assert.Equal(0, game.countScore());

            game.addThrowToFrame(0, 7);
            Assert.Equal(7, game.countScore());

            game.addThrowToFrame(0, 3);
            Assert.Equal(10, game.countScore());

            game.addThrowToFrame(1, 2);
            Assert.Equal(14, game.countScore());
            
            game.addThrowToFrame(1, 8);
            Assert.Equal(22, game.countScore());

            game.addThrowToFrame(2, 10);
            Assert.Equal(42, game.countScore());

            game.addThrowToFrame(3, 5);
            Assert.Equal(52, game.countScore());

            game.addThrowToFrame(3, 3);
            Assert.Equal(58, game.countScore());

            game.addThrowToFrame(4, 10);
            Assert.Equal(68, game.countScore());

            game.addThrowToFrame(5, 10);
            Assert.Equal(88, game.countScore());

            game.addThrowToFrame(6, 10);
            Assert.Equal(118, game.countScore());

            game.addThrowToFrame(7, 3);
            Assert.Equal(127, game.countScore());

            game.addThrowToFrame(7, 5);
            Assert.Equal(137, game.countScore());
            
            game.addThrowToFrame(8, 4);
            Assert.Equal(141, game.countScore());

            game.addThrowToFrame(10, 6); // bonus 'frames', should not count at that point
            Assert.Equal(141, game.countScore());

            game.addThrowToFrame(11, 5); // bonus 'frames', should not count at that point
            Assert.Equal(141, game.countScore());

            game.addThrowToFrame(9, 10); // now bonus frames should start counting
            Assert.Equal(157, game.countScore());

            game.addThrowToFrame(10, 4);
            Assert.Equal(161, game.countScore());
        }

        [Fact]
        public void countScoreKataExamples()
        {
            Bowling_game_kata.BowlingGame gameFullOfStrikes = new Bowling_game_kata.BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOfStrikes.addThrowToFrame(i, 10);
            }
            Assert.Equal(300, gameFullOfStrikes.countScore());

            Bowling_game_kata.BowlingGame gameFullOfSpares = new Bowling_game_kata.BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOfSpares.addThrowToFrame(i, 5);
                gameFullOfSpares.addThrowToFrame(i, 5);
            }
            Assert.Equal(150, gameFullOfSpares.countScore());

            Bowling_game_kata.BowlingGame gameFullOf9pts = new Bowling_game_kata.BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOf9pts.addThrowToFrame(i, 9);
                gameFullOf9pts.addThrowToFrame(i, 0);
            }
            Assert.Equal(90, gameFullOf9pts.countScore());
        }
    }
}
