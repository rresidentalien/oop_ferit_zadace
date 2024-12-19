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
        private Description description;

        public Episode() : this(0, 0.0, 0.0, new Description())
        {
        }

        public Episode(Episode other)
        {
            this.viewerCount = other.viewerCount;
            this.sumOfScores = other.sumOfScores;
            this.highestScore = other.highestScore;
            this.description = new Description(other.description);
        }

        public Episode(int viewerCount, double sumOfScores, double highestScore, Description description)
        {
            this.viewerCount = viewerCount;
            this.sumOfScores = sumOfScores;
            this.highestScore = highestScore;
            this.description = description;
        }

        public double GetMaxScore()
        {
            return highestScore;
        }

        public int GetViewerCount()
        {
            return viewerCount;
        }

        public TimeSpan GetEpisodeLength()
        {
            return description.EpisodeLength;
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

        public static bool operator> (Episode episode1, Episode episode2)
        {
            return episode1.GetAverageScore() > episode2.GetAverageScore();
        }

        public static bool operator< (Episode episode1, Episode episode2)
        {
            return episode1.GetAverageScore() < episode2.GetAverageScore();
        }

        public override string ToString()
        {
            return $"{viewerCount},{Math.Round(sumOfScores, 4)},{Math.Round(highestScore, 2)}," + description.ToString();
        }
    }
}
