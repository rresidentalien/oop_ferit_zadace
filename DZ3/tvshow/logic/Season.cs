using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Season
    {
        private Episode[] episodes;
        private int seasonNumber;
        public int Length { get => episodes.Length; }

        public Season(int seasonNumber, Episode[] episodes)
        {
            this.seasonNumber = seasonNumber;
            this.episodes = episodes;
        }

        public Episode this[int i]
        {
            get => episodes[i];
            set => episodes[i] = value;
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
            foreach(var episode in episodes)
            {
                totalTime += episode.GetEpisodeLength();
            }

            return totalTime;
        }

        public DateTime GetBingeEnd()
        {
            DateTime endTime = DateTime.Now;

            foreach(var episode in episodes)
            {
                endTime += episode.GetEpisodeLength();
            }

            return endTime;
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
            returnString += $"";
            returnString += $"Total viewers: {GetTotalViewers()}\n";
            returnString += $"Total duration: {GetTotalTime()}";
            returnString += "\n=================================================\n";

            return returnString;
        }
    }
}
