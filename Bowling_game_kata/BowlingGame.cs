using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Bowling_game_kata
{
    class BowlingGame
    {
        public BowlingGame() {
            for (int i = 0; i < 12; i++)
                m_roundResults[i] = new RoundResult();
        }

        public RoundResult addThrowToRound(int roundNr, int pinsTakenDown)
        {
            Debug.Assert(roundNr < 12, "roundNr cannot be higher than 11");

            RoundResult round = m_roundResults[roundNr];
            round.addThrow(pinsTakenDown);
            return round;
        }

        public int countScore()
        {
            int totalScore = 0;
            for (int round = 0; round<10; round++)
            {
                totalScore += countRoundsScore(round);
            }
            return totalScore;
        }

        private int countRoundsScore(int round)
        {
            int roundsScore = m_roundResults[round].getSumOfPinsTakenDown();
            if (m_roundResults[round].isSpare())
            {
                roundsScore += m_roundResults[round + 1].getPinsTakenDownInRoll(0);
            }
            else if (m_roundResults[round].isStrike())
            {
                roundsScore += countStrikeExtraScore(round);
            } 
            return roundsScore;
        }

        private int countStrikeExtraScore(int round)
        {
            int extraScore = 0;
            extraScore += m_roundResults[round + 1].getPinsTakenDownInRoll(0);
            if (extraScore == 10)
            {
                extraScore += m_roundResults[round + 2].getPinsTakenDownInRoll(0);
            }
            else
            {
                extraScore += m_roundResults[round + 1].getPinsTakenDownInRoll(1);
            }
            return extraScore;
        }

        private RoundResult[] m_roundResults = new RoundResult[12];
    }
}
