using DAL;
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
        [StringLength(450, ErrorMessage = "Name cannot be longer than 450 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreTypeId { get; set; }
    }
}