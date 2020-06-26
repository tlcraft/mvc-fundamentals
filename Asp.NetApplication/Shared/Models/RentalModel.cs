using DAL;
using System;

namespace Shared.Models
{
    public class RentalModel
    {
        public long Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public User Customer { get; set; }
        public Game Game { get; set; }
    }
}
