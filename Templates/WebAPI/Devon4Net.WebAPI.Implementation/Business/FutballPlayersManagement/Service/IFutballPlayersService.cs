using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service
{
    public interface IFutballPlayersService
    {
        public Task<List<FutballPlayerDto>> GetAllFutballPlayers();

        public Task<FutballPlayerDto> GetFutballPlayerById(long futballPlayerId);

        public Task<FutballPlayerDto> AddNewFutballPlayer(FutballPlayerDto futballPlayer);
    }
}
