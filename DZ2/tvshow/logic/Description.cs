using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class Description
    {
        private int episodeNumber = 1;
        private TimeSpan episodeLength = TimeSpan.FromMinutes(60);
        private string episodeTitle = "";


        public Description() { }

        public Description(int episodeNumber, TimeSpan episodeLength, string episodeTitle)
        {
            this.episodeNumber = episodeNumber;
            this.episodeLength = episodeLength;
            this.episodeTitle = episodeTitle;
        }


    }
}
