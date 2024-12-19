using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Season : IEnumerable<Episode>
    {
        private List<Episode> episodes;
        private int seasonNumber;

        public Season(int seasonNumber, List<Episode> episodes)
        {
            this.seasonNumber = seasonNumber;
            this.episodes = episodes;
        }

        public Season(Season other)
        {
            this.seasonNumber = other.seasonNumber;
            this.episodes = new List<Episode>();
            foreach (var episode in other.episodes)
            {
                this.episodes.Add(new Episode(episode));
            }
        }

        public Episode this[int index]
        {
            get => episodes[index];
            set => episodes[index] = value;
        }

        public int GetTotalViewers()
        {
            int totalViewers = 0;
            foreach (var episode in episodes)
            {
                totalViewers += episode.GetViewerCount();
            }

            return totalViewers;
        }

        public TimeSpan GetTotalTime()
        {
            TimeSpan totalTime = TimeSpan.FromSeconds(0);
            foreach (var episode in episodes)
            {
                totalTime += episode.GetEpisodeLength();
            }

            return totalTime;
        }

        public DateTime GetBingeEnd()
        {
            return DateTime.Now + GetTotalTime();
        }

        public override string ToString()
        {
            string returnString = "";

            returnString += $"Season {seasonNumber}:";
            returnString += "\n=================================================\n";
            foreach (var episode in episodes)
            {
                returnString += episode.ToString();
                returnString += "\n";
            }
            returnString += "Report:";
            returnString += "\n=================================================\n";
            returnString += $"Total viewers: {GetTotalViewers()}\n";
            returnString += $"Total duration: {GetTotalTime()}";
            returnString += "\n=================================================\n";

            return returnString;
        }

        public IEnumerator<Episode> GetEnumerator()
        {
            foreach (var episode in episodes)
            {
                yield return episode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(string episodeName)
        {
            var episode = episodes.FirstOrDefault(e => e.ToString().Contains(episodeName));
            if (episode == null)
            {
                throw new TvException($"No such episode found.", episodeName);
            }
            episodes.Remove(episode);
        }
    }
}