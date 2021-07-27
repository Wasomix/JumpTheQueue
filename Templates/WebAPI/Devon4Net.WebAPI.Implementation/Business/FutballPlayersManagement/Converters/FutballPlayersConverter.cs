using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System.Collections.Generic;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Converters
{
    public class FutballPlayersConverter
    {
        public static List<FutballPlayerDto> FromListOfModelToDto(IList<FutballPlayers> listOfFutballPlayers)
        {
            List<FutballPlayerDto> convertedListOfFutballPlayers = new List<FutballPlayerDto>();

            foreach (var futballPlayer in listOfFutballPlayers)
            {
                convertedListOfFutballPlayers.Add(FromModelToDto(futballPlayer));
            }

            return convertedListOfFutballPlayers;
        }

        public static FutballPlayerDto FromModelToDto(FutballPlayers futballplayer)
        {
            return new FutballPlayerDto 
            { 
                Id          = futballplayer.Id,
                FirstName   = futballplayer.FirstName, 
                LastName    = futballplayer.LastName,
                FutballTeam = futballplayer.FutballTeam
            };
        }
    }
}
