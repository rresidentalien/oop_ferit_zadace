namespace core
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int EpisodeOrder { get; set; }
        public string PremiereDate { get; set; }
        public string EndDate { get; set; }

        public override string ToString()
        {
            return $"Season {Number}\n" +
                $"Number of episodes: {EpisodeOrder}\n" +
                $"Aired between {PremiereDate} and {EndDate}";
        }
    }
}