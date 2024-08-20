namespace BeautyWebAPI.Entities
{
    public class Session
    {
        public int SessionId { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer {get; set;} = null!;
    }
}
        