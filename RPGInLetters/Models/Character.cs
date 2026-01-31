namespace RPGInLetters.Models
{
    internal class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public double HealthPoints { get; set; } = 100;
        public double ManaPoints { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
