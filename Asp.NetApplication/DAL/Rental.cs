using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Rental
    {
        [Column(nameof(Rental) + "Id")]
        public byte Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
        public User User { get; set; }
        public byte UserId { get; set; }
        public User Game { get; set; }
        public byte GameId { get; set; }
    }
}
