using System;
using System.Collections.Generic;

namespace DAL
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenreType GenreType { get; set; }
        public byte? GenreTypeId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
