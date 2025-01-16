using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace core
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; } //epizode tipa insignificant_special nemaju broj i null vrijednost inace baca exception
        public int Runtime { get; set; }
        public string Summary { get; set; }

        private string RemoveTags(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public override string ToString()
        {
            string cleanSummary = RemoveTags(Summary);
            return $"{Number}: {Name}\n" +
                $"Length: {Runtime} minutes\n" +
                $"{cleanSummary}";
        }
    }
}
