using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IRentalService
    {
        RentalModel GetRentalByRentalId(long rentalId);
        List<RentalModel> GetAllRentalsByUserId(long userId);
        RentalModel GetAllRentalsByGameId(long gameId);
        int AddRental(RentalModel newRental);
        int UpdateRental(RentalModel rentalModel);
        int DeleteRental(long rentalId);
    }
}
