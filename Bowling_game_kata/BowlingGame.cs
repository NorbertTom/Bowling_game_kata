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
                m_frameResults[i] = new FrameResults();
        }

        public FrameResults addThrowToFrame(int frameNr, int pinsTakenDown)
        {
            Debug.Assert(frameNr < 12, "roundNr cannot be higher than 11");

            FrameResults frame = m_frameResults[frameNr];
            frame.addThrow(pinsTakenDown);
            return frame;
        }

        public int countScore()
        {
            int totalScore = 0;
            for (int frameNr = 0; frameNr<10; frameNr++)
            {
                totalScore += countFramesScore(frameNr);
            }
            return totalScore;
        }

        private int countFramesScore(int frameNr)
        {
            FrameResults frame = m_frameResults[frameNr];
            int framesScore = frame.getSumOfPinsTakenDown();
            if (frame.isSpare())
            {
                framesScore += m_frameResults[frameNr + 1].getPinsTakenDownInRoll(0);
            }
            else if (frame.isStrike())
            {
                framesScore += countStrikeExtraScore(frameNr);
            } 
            return framesScore;
        }

        private int countStrikeExtraScore(int frameNr)
        {
            int extraScore = 0;
            extraScore += m_frameResults[frameNr + 1].getPinsTakenDownInRoll(0);
            if (extraScore == 10)
            {
                extraScore += m_frameResults[frameNr + 2].getPinsTakenDownInRoll(0);
            }
            else
            {
                extraScore += m_frameResults[frameNr + 1].getPinsTakenDownInRoll(1);
            }
            return extraScore;
        }

        private FrameResults[] m_frameResults = new FrameResults[12];
    }
}
