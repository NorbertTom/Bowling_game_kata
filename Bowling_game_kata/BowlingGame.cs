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
            for (int frame = 0; frame<10; frame++)
            {
                totalScore += countFramesScore(frame);
            }
            return totalScore;
        }

        private int countFramesScore(int frame)
        {
            int framesScore = m_frameResults[frame].getSumOfPinsTakenDown();
            if (m_frameResults[frame].isSpare())
            {
                framesScore += m_frameResults[frame + 1].getPinsTakenDownInRoll(0);
            }
            else if (m_frameResults[frame].isStrike())
            {
                framesScore += countStrikeExtraScore(frame);
            } 
            return framesScore;
        }

        private int countStrikeExtraScore(int frame)
        {
            int extraScore = 0;
            extraScore += m_frameResults[frame + 1].getPinsTakenDownInRoll(0);
            if (extraScore == 10)
            {
                extraScore += m_frameResults[frame + 2].getPinsTakenDownInRoll(0);
            }
            else
            {
                extraScore += m_frameResults[frame + 1].getPinsTakenDownInRoll(1);
            }
            return extraScore;
        }

        private FrameResults[] m_frameResults = new FrameResults[12];
    }
}
