namespace DeathDartOfGlorySeasonOne.Models
{
    public class PlayerScore
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int? Score { get; set; }
    }
}
