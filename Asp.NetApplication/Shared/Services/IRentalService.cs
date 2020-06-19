using Shared.Models;

namespace Shared.Services
{
    public interface IRentalService
    {
        RentalModel GetRentalByRentalId(long rentalId);
        RentalModel GetAllRentalsByUserId(long userId);
        RentalModel GetAllRentalsByGameId(long gameId);
        int AddRental(RentalModel newRental);
        int UpdateRental(RentalModel rentalModel);
        int DeleteRental(long rentalId);
    }
}
