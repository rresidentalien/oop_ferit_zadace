using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class TvUtilities
    {
        private static Random random = new Random();

        public static double GenerateRandomScore()
        {
            return (double)(random.NextDouble() * 10.0);
        }

        public static void Sort(Episode[] episodes)
        {
            Array.Sort(episodes, (e1, e2) => e1 > e2 ? -1 : e1 < e2 ? 1 : 0);
        }

        public static Episode Parse(string input)
        {
            var parts = input.Split(',');
            int viewerCount = int.Parse(parts[0]);
            double sumOfScores = double.Parse(parts[1]);
            double highestScore = double.Parse(parts[2]);
            int episodeNumber = int.Parse(parts[3]);
            TimeSpan episodeLength = TimeSpan.Parse(parts[4]);
            string episodeTitle = parts[5];

            Description description = new Description(episodeNumber, episodeLength, episodeTitle);
            return new Episode(viewerCount, sumOfScores, highestScore, description);
        }

        public static List<Episode> LoadEpisodesFromFile(string fileName)
        {
            string[] episodesInputs = File.ReadAllLines(fileName);
            List<Episode> episodes = new List<Episode>();
            for (int i = 0; i < episodes.Count; i++)
            {
                episodes[i] = Parse(episodesInputs[i]);
            }

            return episodes;
        }
    }
}
