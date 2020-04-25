using DAL;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IReferenceService
    {
        IEnumerable<GenreType> GetGenreTypes();
        IEnumerable<MembershipType> GetMembershipTypes();
    }
}
