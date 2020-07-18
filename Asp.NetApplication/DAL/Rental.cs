using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Rental
    {
        [Column(nameof(Rental) + "Id")]
        public long Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Game Game { get; set; }
        [ForeignKey("Game")]
        public long GameId { get; set; }
    }
}
