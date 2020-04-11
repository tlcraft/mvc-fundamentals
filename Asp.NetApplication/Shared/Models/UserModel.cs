using DAL;
using System;

namespace Shared.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
