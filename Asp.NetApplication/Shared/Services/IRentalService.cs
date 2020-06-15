using Shared.Models;
using System.Collections.Generic;

namespace Shared.Services
{
    public interface IRentalService
    {
        List<RentalModel> GetAllRentals();
        RentalModel GeRentalById(long rentalId);
        int AddRental(RentalModel newRental);
        int UpdateRental(RentalModel rentalModel);
        int DeleteRental(long rentalId);
    }
}
