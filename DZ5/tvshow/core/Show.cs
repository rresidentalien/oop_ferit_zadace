using System.Text.RegularExpressions;

namespace core
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public string Language { get; set; }
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
            string genre = Genres != null && Genres.Count > 0 ? Genres[0] : "- genre unknown";
            string cleanSummary = RemoveTags(Summary);
            return $"{Name}\n{Language} {genre}\n{cleanSummary}";
        }
    }
}
