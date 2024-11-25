using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Episode
    {
        private int viewerCount;
        private double sumOfScores;
        private double highestScore;

        public Episode() 
        {
            viewerCount = 0;
            sumOfScores = 0.0;
            highestScore = 0.0;
        }

        public Episode(int viewerCount, double sumOfScores, double highestScore)
        {
            this.viewerCount = viewerCount;
            this.sumOfScores = sumOfScores;
            this.highestScore = highestScore;
        }

        public double GetMaxScore()
        {
            return highestScore;
        }

        public int GetViewerCount()
        {
            return viewerCount;
        }

        public double GetAverageScore()
        {
            if (viewerCount > 0)
            {
                return sumOfScores / viewerCount;
            }
            return 0;
        }

        public void AddView(double score)
        {
            ++viewerCount;
            sumOfScores += score;
            if (score > highestScore)
            {
                highestScore = score;
            }
        }
    }
}
