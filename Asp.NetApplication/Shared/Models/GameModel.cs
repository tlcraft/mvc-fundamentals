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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public GenreType GenreType { get; set; }
    }
}
