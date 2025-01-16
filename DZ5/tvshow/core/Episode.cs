using System.Text.RegularExpressions;

namespace core
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; } //epizode tipa insignificant_special nemaju broj i null vrijednost inace baca exception, npr got s8, derry girls s3
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
