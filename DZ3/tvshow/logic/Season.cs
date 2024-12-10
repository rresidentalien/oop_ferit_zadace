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
            return base.ToString();
        }
    }
}
