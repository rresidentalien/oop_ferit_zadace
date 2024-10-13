namespace logic
{
    public class Episode
    {
        private int viewerCount = 0;
        private double sumOfScores = 0.0;
        private double highestScore = 0.0;

        public Episode() { }

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
            return sumOfScores / viewerCount;
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
