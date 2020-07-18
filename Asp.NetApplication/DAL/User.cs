using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte? MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
