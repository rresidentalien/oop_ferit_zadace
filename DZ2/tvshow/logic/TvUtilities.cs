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


        public static float GenerateRandomScore()
        {
            return (float)(random.NextDouble() * 10.0);
        }

        public static void Sort(Episode[] episodes)
        {

        }
    }
}
