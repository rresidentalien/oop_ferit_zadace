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
            //overload metode Sort koji prima dva parametra: niz koji sortiramo i metodu ili bilo sto drugo sto ce vratiti broj veci od 0 ako je e1 veci od e2, 0 ako su jednaki i broj manji od 0 ako je e1 manji od e2
            //ako je e1 > e2 vrati 1, ako nije: provjeri je li e1 < e2, ako je vrati -1, ako nije vrati 0
            //osim sto je naopako da sortira silazno
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
    }
}
