using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Rental
    {
        [Column(nameof(Rental) + "Id")]
        public long Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Game Game { get; set; }
    }
}
