using System;

namespace Shared.Models
{
    public class RentalModel
    {
        public long Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public UserModel Customer { get; set; }
        public GameModel Game { get; set; }
    }
}
