using DAL;
using Shared.Models;
using System.Collections.Generic;

namespace MvcFrameworkApp.Models
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public UserModel UserModel { get; set; }
    }
}