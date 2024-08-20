namespace BeautyWebAPI.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        // Customer kann mehrere Sitzungen beim Freseur haben
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
