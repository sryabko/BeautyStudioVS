using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeautyWebAPI.Entities
{
    public class Service
    {

        public int Id { get; set; }
        [MaxLength(255)] public required string Description { get; set; }
        [Precision(18, 2)] public decimal Price { get; set; }
        public required IEnumerable<SessionService> Sessions { get; set; }
    }
}

