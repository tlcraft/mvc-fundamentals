using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Services
{
    public class RentalService : IRentalService
    {
        private EfContext efContext;
        private IMapper mapper;

        public RentalService(EfContext efContext, IMapper mapper)
        {
            this.efContext = efContext;
            this.mapper = mapper;
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
            var dbRental = this.efContext.Rentals
                .Include(rental => rental.User)
                .Include(rental => rental.Game)
                .SingleOrDefault(rental => rental.Id == rentalId);

            return this.mapper.Map<Rental, RentalModel>(dbRental);
        }

        public List<RentalModel> GetAllRentalsByGameId(long gameId)
        {
            var rentals = this.efContext.Rentals
               .Where(rental => rental.GameId == gameId)
               .Include(rental => rental.User)
               .Include(rental => rental.Game)
               .ToList();

            var rentalModels = this.mapper.Map<List<Rental>, List<RentalModel>>(rentals);

            return rentalModels;
        }

        public List<RentalModel> GetAllRentalsByUserId(long userId)
        {
            var rentals = this.efContext.Rentals
                .Where(rental => rental.UserId == userId)
                .Include(rental => rental.User)
                .Include(rental => rental.Game)
                .ToList();

            var rentalModels = this.mapper.Map<List<Rental>, List<RentalModel>>(rentals);

            return rentalModels;
        }

        public int UpdateRental(RentalModel rentalModel)
        {
            var dbRental = this.efContext.Rentals.Single(rental => rental.Id == rentalModel.Id);

            dbRental = this.mapper.Map<RentalModel, Rental>(rentalModel, dbRental);

            var totalStateEntriesWritten = this.efContext.SaveChanges();
            return totalStateEntriesWritten;
        }
    }
}
