using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Converters;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Moq;
using Xunit;

namespace Devon4Net.Test.xUnit.Test.UnitTest.FutballPlayersTest.ConverterTest
{
    public class FutballPlayersConverterTest : UnitTest
    {
        public FutballPlayersConverterTest()
        {

        }

        [Fact]
        public void FromModelToDtoWithEqualDtosTest()
        {
            FutballPlayerDto futballplayerOriginal = new FutballPlayerDto
            {
                Id = 2,
                FirstName = "Fernando",
                LastName = "Redondo",
                FutballTeam = "Real Madrid"
            };

            FutballPlayerDto futballplayerCalculated = 
                FutballPlayersConverter.FromModelToDto( new FutballPlayers
                {
                    Id = 2,
                    FirstName = "Fernando",
                    LastName = "Redondo",
                    FutballTeam = "Real Madrid"
                });
            Assert.True(AreBothDtoEqual(futballplayerOriginal, futballplayerCalculated));
        }

        [Fact]
        public void FromModelToDtoWithDifferentDtosTest()
        {
            FutballPlayerDto futballplayerOriginal = new FutballPlayerDto
            {
                Id = 2,
                FirstName = "Rafael",
                LastName = "Alcorta",
                FutballTeam = "Real Madrid"
            };

            FutballPlayerDto futballplayerCalculated =
                FutballPlayersConverter.FromModelToDto(new FutballPlayers
                {
                    Id = 2,
                    FirstName = "Fernando",
                    LastName = "Redondo",
                    FutballTeam = "Real Madrid"
                });
            Assert.False(AreBothDtoEqual(futballplayerOriginal, futballplayerCalculated));
        }


        private bool AreBothDtoEqual(FutballPlayerDto futballplayerOriginal,
                                     FutballPlayerDto futballplayerCalculated)
        {
            return futballplayerOriginal.Id == futballplayerCalculated.Id &&
                  futballplayerOriginal.FirstName == futballplayerCalculated.FirstName &&
                  futballplayerOriginal.LastName == futballplayerCalculated.LastName &&
                  futballplayerOriginal.FutballTeam == futballplayerCalculated.FutballTeam;
        }
    }
}
