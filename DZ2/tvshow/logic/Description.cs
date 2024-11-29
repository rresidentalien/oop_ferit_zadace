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


        public Description()
        {
            episodeNumber = 1;
            episodeLength = TimeSpan.FromMinutes(60);
            episodeTitle = "Title";
        }

        public Description(int episodeNumber, TimeSpan episodeLength, string episodeTitle)
        {
            this.episodeNumber = episodeNumber;
            this.episodeLength = episodeLength;
            this.episodeTitle = episodeTitle;
        }

        public override string ToString()
        {
            return $"{episodeNumber},{episodeLength},{episodeTitle}";
        }
    }
}
