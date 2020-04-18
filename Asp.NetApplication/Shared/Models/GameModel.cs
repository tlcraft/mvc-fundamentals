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
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required] 
        public GenreType GenreType { get; set; }
    }
}
