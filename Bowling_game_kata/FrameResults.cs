using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Bowling_game_kata
{
    class FrameResults
    {
        public FrameResults() {

            m_pinsTakenDownInRoll = new int[2];
            for (int i = 0; i < 2; ++i)
            {
                m_pinsTakenDownInRoll[i] = 0;
            }
        }

        public void addThrow(int pinsScored)
        {
            Debug.Assert(m_nrOfThrows < 2, "m_nrOfThrows should never exceed 1");
         
            int currentThrow = m_nrOfThrows;
            m_pinsTakenDownInRoll[currentThrow] = pinsScored;
            ++m_nrOfThrows;
            
            Debug.Assert(getSumOfPinsTakenDown() < 11, "m_pinsTakenDown should never exceed 10");
        }

        public bool isSpare()
        {
            bool result = false;
            if (getSumOfPinsTakenDown() == 10 && m_pinsTakenDownInRoll[0] != 10)
            {
                result = true;
            }
            return result;
        }

        public bool isStrike()
        {
            bool result = false;
            if (m_pinsTakenDownInRoll[0] == 10)
            {
                result = true;
            }
            return result;
        }

        public int getSumOfPinsTakenDown()
        {
            return m_pinsTakenDownInRoll[0] + m_pinsTakenDownInRoll[1];
        }

        public int getPinsTakenDownInRoll(int rollNr)
        {
            Debug.Assert(rollNr < 2, "Invalid rollNr");
            Debug.Assert(rollNr >= 0, "Invalid rollNr");

            return m_pinsTakenDownInRoll[rollNr];
        }

        private int[] m_pinsTakenDownInRoll;
        private int m_nrOfThrows = 0;
    }
}
