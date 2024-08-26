namespace BeautyWebAPI.Entities
{
    public class Session
    {
        public int SessionId { get; set; } //Compare with SessionId in class SessionService
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer {get; set;} = null!;
        public DateTime SessionBegin { get; set; }
        public DateTime SessionEnd { get; set; }


    }
}
        