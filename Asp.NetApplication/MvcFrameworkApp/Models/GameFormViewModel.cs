using DAL;
using Shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcFrameworkApp.Models
{
    public class GameFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public long? Id { get; set; }
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
        [Display(Name = "GameGenreType", ResourceType = typeof(Strings))]
        public byte GenreTypeId { get; set; }
    }
}