namespace RPGInLetters.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Character? UserCharacter { get; set; }
    }
}
