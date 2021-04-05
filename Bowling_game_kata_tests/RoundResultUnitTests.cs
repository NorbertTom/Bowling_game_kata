using System;
using Xunit;

namespace Bowling_game_kata_tests
{
    public class RoundResultUnitTests
    {
        [Fact]
        public void addRoundResultAndGetters()
        {
            Bowling_game_kata.RoundResult roundResult = new Bowling_game_kata.RoundResult();
            Assert.Equal(0, roundResult.getSumOfPinsTakenDown());
            Assert.Equal(0, roundResult.getNrOfThrows());

            roundResult.addThrow(5);
            Assert.Equal(5, roundResult.getSumOfPinsTakenDown());
            Assert.Equal(1, roundResult.getNrOfThrows());
            Assert.Equal(5, roundResult.getPinsTakenDownInRoll(0));
            Assert.Equal(0, roundResult.getPinsTakenDownInRoll(1));

            roundResult.addThrow(2);
            Assert.Equal(7, roundResult.getSumOfPinsTakenDown());
            Assert.Equal(2, roundResult.getNrOfThrows());
            Assert.Equal(5, roundResult.getPinsTakenDownInRoll(0));
            Assert.Equal(2, roundResult.getPinsTakenDownInRoll(1));

        }

        [Fact]
        public void strikesAndSpares()
        {
            Bowling_game_kata.RoundResult round1 = new Bowling_game_kata.RoundResult();
            Bowling_game_kata.RoundResult round2 = new Bowling_game_kata.RoundResult();
            Bowling_game_kata.RoundResult round3 = new Bowling_game_kata.RoundResult();
            Assert.False(round1.isSpare());
            Assert.False(round1.isStrike());

            round1.addThrow(10);
            Assert.True(round1.isStrike());
            Assert.False(round1.isSpare());

            round1.addThrow(0);
            Assert.True(round1.isStrike());
            Assert.False(round1.isSpare());

            round2.addThrow(5);
            Assert.False(round2.isStrike());
            Assert.False(round2.isSpare());

            round2.addThrow(5);
            Assert.False(round2.isStrike());
            Assert.True(round2.isSpare());

            round3.addThrow(7);
            Assert.False(round3.isStrike());
            Assert.False(round3.isSpare());

            round3.addThrow(1);
            Assert.False(round3.isStrike());
            Assert.False(round3.isSpare());

        }
    }
}
