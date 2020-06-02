using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcFrameworkApp.Models
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public long? Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "First Name cannot be longer than 255 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Last Name cannot be longer than 255 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}