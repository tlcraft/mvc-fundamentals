using DAL;
using Shared.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    /// <summary>
    /// The shared <c>GameModel</c> class.
    /// <para>This class is the business DTO for game information.</para>
    /// </summary>
    public class GameModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "GameName", ResourceType = typeof(Strings))]
        [StringLength(450, ErrorMessage = "Name cannot be longer than 450 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "GameReleaseDate", ResourceType = typeof(Strings))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "GameGenreType", ResourceType =typeof(Strings))]
        public GenreType GenreType { get; set; }
    }
}
