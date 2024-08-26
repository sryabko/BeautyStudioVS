namespace BeautyWebAPI.Entities
{
    public class SessionService
    {

        public int SessionId { get; set; } //PK Zusammengestellt (see class: session)

        public required Session SessionEntity { get; set; }

        public int ServiceId { get; set; } //PK

        public required Service ServiceEntity { get; set; }
    }
}

