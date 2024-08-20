using Microsoft.Extensions.Hosting;

namespace BeautyWebAPI.Entities
{
    public class Hairdresser
    {
        public int HairdresserId{ get; set; }

        public required string Name { get; set; }

        public required string FamilyName{ get; set; }
        // Bezieung 1:n Hairdresser hat viele Sitzungen (mit den Kunden)
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
