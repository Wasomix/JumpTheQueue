using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Moq;
using Xunit;

namespace Devon4Net.Test.xUnit.Test.UnitTest.FutballPlayersTest.ServiceTest
{
    public class FutballPlayersServiceTest : UnitTest
    {
        Mock<IFutballPlayersRepository> _futballPlayersRepository;

        public FutballPlayersServiceTest()
        {
            _futballPlayersRepository = new Mock<IFutballPlayersRepository>();
            InitializeMockIFutballPlayersRepository();
        }

        private void InitializeMockIFutballPlayersRepository()
        {
            //_futballPlayersRepository
            //    .Setup(x => x.AddNewFutballPlayer(
            //        new FutballPlayerDto
            //        {
            //            Id = 1,
            //            FirstName = "Roman",
            //            LastName = "Kosecki",
            //            FutballTeam = "Atletico de Madrid"
            //        }))
            //    .Returns(new FutballPlayers 
            //    {
            //        Id = 1,
            //        FirstName = "Roman",
            //        LastName = "Kosecki",
            //        FutballTeam = "Atletico de Madrid"
            //    });
        }
        
    }
}
