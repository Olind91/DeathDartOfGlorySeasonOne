namespace DeathDartOfGlorySeasonOne.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int NumberOfGames { get; set; }
        public List<PlayerScore> PlayerScores { get; set; }
    }
}
