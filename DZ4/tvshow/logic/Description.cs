using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Description
    {
        private int episodeNumber;
        private TimeSpan episodeLength;
        private string episodeTitle;


        public Description() : this(1, TimeSpan.FromMinutes(0), "Default Title")
        {
        }

        public Description(int episodeNumber, TimeSpan episodeLength, string episodeTitle)
        {
            this.episodeNumber = episodeNumber;
            this.episodeLength = episodeLength;
            this.episodeTitle = episodeTitle;
        }

        public Description(Description other)
        {
            this.episodeNumber = other.episodeNumber;
            this.episodeLength = other.episodeLength;
            this.episodeTitle = other.episodeTitle;
        }

        public TimeSpan EpisodeLength { get => episodeLength; }

        public override string ToString()
        {
            return $"{episodeNumber},{episodeLength},{episodeTitle}";
        }
    }
}
