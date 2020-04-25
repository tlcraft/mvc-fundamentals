using DAL;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public MembershipType MembershipType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}
