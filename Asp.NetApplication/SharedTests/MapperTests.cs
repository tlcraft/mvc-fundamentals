using AutoMapper;
using DAL;
using Shared.Models;
using Shared.Services;
using Xunit;

namespace SharedTests
{
    public class MapperTests
    {
        [Fact]
        public void ShouldMapRentalModelToDbRental()
        {
            var rentalModel = new RentalModel()
            { 
                Customer = new UserModel()
                {
                    Id = 1,
                    FirstName = "FirstName"
                },
                Game = new GameModel()
                {
                    Id = 2,
                    Name = "Game"
                }
            };

            var config = new MapperConfiguration(c => c.AddProfile(new MapperProfile()));
            var mapper = config.CreateMapper();

            var rental = mapper.Map<RentalModel, Rental>(rentalModel);

            Assert.Equal(rentalModel.Customer.Id, rental.UserId);
            Assert.Equal(rentalModel.Game.Id, rental.GameId);
            Assert.Null(rental.User);
            Assert.Null(rental.Game);
        }

        [Fact]
        public void ShouldMapDbRentalToRentalModel()
        {
            var rental = new Rental()
            {
                UserId = 1,
                User = new User()
                {
                    Id = 1,
                    FirstName = "FirstName"
                },
                GameId = 2,
                Game = new Game()
                {
                    Id = 2,
                    Name = "Game"
                }
            };

            var config = new MapperConfiguration(c => c.AddProfile(new MapperProfile()));
            var mapper = config.CreateMapper();

            var rentalModel = mapper.Map<Rental, RentalModel>(rental);

            Assert.Equal(rentalModel.Customer.Id, rental.UserId);
            Assert.Equal(rentalModel.Customer.Id, rental.User.Id);
            Assert.Equal(rentalModel.Customer.FirstName, rental.User.FirstName);
            Assert.Equal(rentalModel.Game.Id, rental.GameId);
            Assert.Equal(rentalModel.Game.Id, rental.Game.Id);
            Assert.Equal(rentalModel.Game.Name, rental.Game.Name);
        }
    }
}
