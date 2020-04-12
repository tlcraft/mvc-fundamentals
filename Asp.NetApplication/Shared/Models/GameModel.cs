using DAL;
using System;

namespace Shared.Models
{
    public class GameModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenreType GenreType { get; set; }
    }
}
