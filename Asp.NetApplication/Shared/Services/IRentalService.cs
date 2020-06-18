using Shared.Models;

namespace Shared.Services
{
    public interface IRentalService
    {
        RentalModel GetAllRentalsByUserId(long userId);
        RentalModel GetAllRentalsByRentalId(long rentalId);
        int AddRental(RentalModel newRental);
        int UpdateRental(RentalModel rentalModel);
        int DeleteRental(long rentalId);
    }
}
