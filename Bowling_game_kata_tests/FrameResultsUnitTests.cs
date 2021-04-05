using System;
using Xunit;

namespace Bowling_game_kata_tests
{
    public class FrameResultsUnitTests
    {
        [Fact]
        public void addFrameResultAndGetters()
        {
            Bowling_game_kata.FrameResults frameResult = new Bowling_game_kata.FrameResults();
            Assert.Equal(0, frameResult.getSumOfPinsTakenDown());
            Assert.Equal(0, frameResult.getNrOfThrows());

            frameResult.addThrow(5);
            Assert.Equal(5, frameResult.getSumOfPinsTakenDown());
            Assert.Equal(1, frameResult.getNrOfThrows());
            Assert.Equal(5, frameResult.getPinsTakenDownInRoll(0));
            Assert.Equal(0, frameResult.getPinsTakenDownInRoll(1));

            frameResult.addThrow(2);
            Assert.Equal(7, frameResult.getSumOfPinsTakenDown());
            Assert.Equal(2, frameResult.getNrOfThrows());
            Assert.Equal(5, frameResult.getPinsTakenDownInRoll(0));
            Assert.Equal(2, frameResult.getPinsTakenDownInRoll(1));

        }

        [Fact]
        public void strikesAndSpares()
        {
            Bowling_game_kata.FrameResults frame1 = new Bowling_game_kata.FrameResults();
            Bowling_game_kata.FrameResults frame2 = new Bowling_game_kata.FrameResults();
            Bowling_game_kata.FrameResults frame3 = new Bowling_game_kata.FrameResults();
            Assert.False(frame1.isSpare());
            Assert.False(frame1.isStrike());

            frame1.addThrow(10);
            Assert.True(frame1.isStrike());
            Assert.False(frame1.isSpare());

            frame1.addThrow(0);
            Assert.True(frame1.isStrike());
            Assert.False(frame1.isSpare());

            frame2.addThrow(5);
            Assert.False(frame2.isStrike());
            Assert.False(frame2.isSpare());

            frame2.addThrow(5);
            Assert.False(frame2.isStrike());
            Assert.True(frame2.isSpare());

            frame3.addThrow(7);
            Assert.False(frame3.isStrike());
            Assert.False(frame3.isSpare());

            frame3.addThrow(1);
            Assert.False(frame3.isStrike());
            Assert.False(frame3.isSpare());

        }
    }
}
