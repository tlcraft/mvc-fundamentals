using DAL;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class GameModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "GameName", ResourceType = typeof(StringResource))]
        [StringLength(450, ErrorMessage = "Name cannot be longer than 450 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "GameReleaseDate", ResourceType = typeof(StringResource))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "GameGenreType", ResourceType =typeof(StringResource))]
        public GenreType GenreType { get; set; }
    }
}
