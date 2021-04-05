using System;
using Xunit;
using Bowling_game_kata;

namespace Bowling_game_kata_tests
{
    public class BowlingGameUnitTests
    {
        [Fact]
        public void addingThrowResults()
        {
            BowlingGame game = new BowlingGame();
            int frameNr = 0;
            int pinsTakenDown = 5;
            FrameResults frame0 = new FrameResults();
            frame0 = game.addThrowToFrame(frameNr, pinsTakenDown);
            Assert.Equal(pinsTakenDown, frame0.getSumOfPinsTakenDown());

            frameNr = 5;
            pinsTakenDown = 9;
            FrameResults frame5 = new FrameResults();
            frame5 = game.addThrowToFrame(frameNr, pinsTakenDown);
            Assert.Equal(pinsTakenDown, frame5.getSumOfPinsTakenDown());
            Assert.Equal(5, frame0.getSumOfPinsTakenDown());
        }

        [Fact]
        public void countScore()
        {
            BowlingGame game = new BowlingGame();
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
            BowlingGame gameFullOfStrikes = new BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOfStrikes.addThrowToFrame(i, 10);
            }
            Assert.Equal(300, gameFullOfStrikes.countScore());

            BowlingGame gameFullOfSpares = new BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOfSpares.addThrowToFrame(i, 5);
                gameFullOfSpares.addThrowToFrame(i, 5);
            }
            Assert.Equal(150, gameFullOfSpares.countScore());

            BowlingGame gameFullOf9pts = new BowlingGame();
            for (int i = 0; i < 12; i++)
            {
                gameFullOf9pts.addThrowToFrame(i, 9);
                gameFullOf9pts.addThrowToFrame(i, 0);
            }
            Assert.Equal(90, gameFullOf9pts.countScore());
        }
    }
}
