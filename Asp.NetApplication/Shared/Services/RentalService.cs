using DAL;
using Shared.Models;
using System;
using System.Linq;

namespace Shared.Services
{
    public class RentalService : IRentalService
    {
        private EfContext efContext;

        public RentalService(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public int AddRental(RentalModel newRental)
        {
            throw new NotImplementedException();
        }

        public int DeleteRental(long rentalId)
        {
            var dbRental = this.efContext.Rentals.SingleOrDefault(rental => rental.Id == rentalId);

            if (dbRental == null)
            {
                return 0;
            }

            efContext.Rentals.Remove(dbRental);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }

        public RentalModel GetRentalByRentalId(long rentalId)
        {
            var dbRental = this.efContext.Rentals.SingleOrDefault(rental => rental.Id == rentalId);

            return new RentalModel()
            {
                CustomerId = dbRental.UserId,
                GameIds = new System.Collections.Generic.List<long> { dbRental.GameId }
            };
        }

        public RentalModel GetAllRentalsByGameId(long gameId)
        {
            throw new NotImplementedException();
        }

        public RentalModel GetAllRentalsByUserId(long userId)
        {
            var rentals = this.efContext.Rentals.Where(rental => rental.UserId == userId);

            return new RentalModel()
            {
                CustomerId = userId,
                GameIds = rentals.Select(rental => rental.Id).ToList()
            };
        }

        public int UpdateRental(RentalModel rentalModel)
        {
            throw new NotImplementedException();
        }
    }
}
