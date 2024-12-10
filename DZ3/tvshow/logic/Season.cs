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
            
            returnString.Concat($"Season {seasonNumber}");
            returnString.Concat("\n=================================================\n");
            foreach(var episode in episodes)
            {
                returnString.Concat(episode.ToString());
                returnString.Concat("\n");
            }
            returnString.Concat("Report:\n");
            returnString.Concat("\n=================================================\n");
            returnString.Concat($"");
            returnString.Concat($"Total viewers: {GetTotalViewers()}\n");
            returnString.Concat($"Total duration: {GetTotalTime()}");
            returnString.Concat("\n=================================================\n");

            return returnString;
        }
    }
}
