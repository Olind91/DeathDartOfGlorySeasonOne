namespace DeathDartOfGlorySeasonOne.Models
{
    public class KlockanGamePlayer
    {
        public int Id { get; set; }

        // Relation till Player-modellen
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int CurrentNumber { get; set; } = 1; // Börjar på 1
        public int Attempts { get; set; } = 0;     // Antal försök

        public string Hit { get; set; } = string.Empty; // Hit typ (Single, Double, Triple)

        //Ligger i razorpage ist.
        public void HitOrMiss()
        {
            switch (Hit)
            {
                case "Single":
                    CurrentNumber += 1;
                    break;
                case "Double":
                    CurrentNumber += 2;
                    break;
                case "Triple":
                    CurrentNumber += 3;
                    break;
            }
            Hit = string.Empty;

            if (CurrentNumber >= 21)
            {
                Console.WriteLine($"{Player.Name} har vunnit spelet!");
            }
        }
    }
}
