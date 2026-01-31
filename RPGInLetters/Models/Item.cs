namespace RPGInLetters.Models
{
    internal class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public enum ItemType
        {
            Weapon,
            Armor,
            Consumable,
            Quest,
            Miscellaneous
        }
        public ItemType Type { get; set; }
    }
}
