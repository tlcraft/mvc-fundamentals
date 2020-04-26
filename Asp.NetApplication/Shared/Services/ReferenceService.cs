using DAL;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Services
{
    public class ReferenceService : IReferenceService
    {
        private EfContext efContext;

        public ReferenceService(EfContext efContext)
        {
            this.efContext = efContext;
        }
        public IEnumerable<GenreType> GetGenreTypes()
        {
            var genres = efContext.GenreType.ToList();
            return genres;
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            var memberships = efContext.MembershipType.ToList();
            return memberships;
        }
    }
}
