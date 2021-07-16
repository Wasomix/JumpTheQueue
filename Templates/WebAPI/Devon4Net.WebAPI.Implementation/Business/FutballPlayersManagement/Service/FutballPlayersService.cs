using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Converters;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service
{
    public class FutballPlayersService : IFutballPlayersService
    {
        IFutballPlayersRepository _futballPlayersRepository;

        public FutballPlayersService(IFutballPlayersRepository futballPlayersRepository)
        {
            _futballPlayersRepository = futballPlayersRepository;
        }

        public Task<FutballPlayerDto> GetFutballPlayerById(long futballPlayerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FutballPlayerDto>> GetAllFutballPlayers()
        {
            Devon4NetLogger.Debug($"GetAllFutballPlayers method from service FutballPlayersService");
            var result = await _futballPlayersRepository.GetAllFutballPlayers().ConfigureAwait(false);

            return FutballPlayersConverter.FromListOfModelToDto(result);
        }

        public async Task<FutballPlayerDto> AddNewFutballPlayer(FutballPlayerDto futballPlayer)
        {
            var result = await _futballPlayersRepository.AddNewFutballPlayer(futballPlayer).ConfigureAwait(false);

            return FutballPlayersConverter.FromModelToDto(result);
        }
    }
}
