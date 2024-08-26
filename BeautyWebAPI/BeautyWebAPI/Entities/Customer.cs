namespace BeautyWebAPI.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public required string FamilyName { get; set; }
        public string Telephone { get; set; }
        public string Discription { get; set; }
        // Customer kann mehrere Sitzungen beim Freseur haben
        public ICollection<Session> Sessions { get; set; } = new List<Session>();

    }
}
