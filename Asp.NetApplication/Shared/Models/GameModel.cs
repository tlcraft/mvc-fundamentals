using DAL;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class GameModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GenreType GenreType { get; set; }
    }
}
