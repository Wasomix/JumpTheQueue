using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Devon4Net.Test.xUnit.Test.UnitTest.FutballPlayersTest.ServiceTest
{
    public class FutballPlayersServiceTest : UnitTest
    {
        Mock<IFutballPlayersRepository> _futballPlayersRepositoryMock;
        FutballPlayers _futballPlayer;
        IList<FutballPlayers> _listOfFutballPlayers;

        public FutballPlayersServiceTest()
        {
            _futballPlayersRepositoryMock = new Mock<IFutballPlayersRepository>();
            InitializeMockIFutballPlayersRepository();
            InitializeFutballPlayer();
            InitializeListOfFutballPlayers();
        }

        private void InitializeMockIFutballPlayersRepository()
        {
            _futballPlayersRepositoryMock
                .Setup(x => x.AddNewFutballPlayer(
                    new FutballPlayerDto
                    {
                        Id = 1,
                        FirstName = "Roman",
                        LastName = "Kosecki",
                        FutballTeam = "Atletico de Madrid"
                    }))
                    .ReturnsAsync(new FutballPlayers()
                    {
                        Id = 1,
                        FirstName = "Roman",
                        LastName = "Kosecki",
                        FutballTeam = "Atletico de Madrid"
                    });

            _futballPlayersRepositoryMock
                .Setup(x => x.GetAllFutballPlayers(null)).ReturnsAsync(new List<FutballPlayers>() 
                {
                    new FutballPlayers{ Id = 1, FirstName = "Roman", LastName = "Kosecki", FutballTeam = "Atletico de Madrid" },
                    new FutballPlayers{ Id = 2, FirstName = "Raul", LastName = "Albiol", FutballTeam = "Villarreal" }
                });
        }

        private void InitializeFutballPlayer()
        {
            _futballPlayer = new FutballPlayers()
            {
                Id = 2,
                FirstName = "Roman",
                LastName = "Kosecki",
                FutballTeam = "Atletico de Madrid"
            };
        }

        private void InitializeListOfFutballPlayers()
        {
            _listOfFutballPlayers = new List<FutballPlayers>()
            {
                new FutballPlayers{ Id = 1, FirstName = "Roman", LastName = "Kosecki", FutballTeam = "Atletico de Madrid" },
                new FutballPlayers{ Id = 2, FirstName = "Raul", LastName = "Albiol", FutballTeam = "Villarreal" }
            };
        }

        [Fact]
        public void GetAllFutballPlayersTest()
        {
            List<FutballPlayers> futballPlayersOriginal = new List<FutballPlayers>()
            {
                new FutballPlayers{ Id = 1, FirstName = "Fernando", LastName = "Redondo", FutballTeam = "Real Madrid"},
                new FutballPlayers{ Id = 2, FirstName = "Carles", LastName = "Puyol", FutballTeam = "Barcelona"}
            };

            //Assert.Collection<List<FutballPlayers>>(futballPlayersOriginal, _futballPlayersRepositoryMock.Object.GetAllFutballPlayers());
        }

        [Fact]
        public void AddNewFutballPlayersTest()
        {
            FutballPlayers futballplayerOriginal = new FutballPlayers
            {
                Id = 2,
                FirstName = "Fernando",
                LastName = "Redondo",
                FutballTeam = "Real Madrid"
            };
        }

    }
}
