using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service
{
    public class FutballPlayersService : IFutballPlayersService
    {
        List<FutballPlayerDto> _listOfPlayers;
        IFutballPlayersRepository _futballPlayersRepository;

        public FutballPlayersService(IFutballPlayersRepository futballPlayersRepository)
        {
            _futballPlayersRepository = futballPlayersRepository;

            _listOfPlayers = new List<FutballPlayerDto>()
            {
                new FutballPlayerDto { Id=1, FirstName = "Raul", LastName = "Gonzalez", FutballTeam = "Real Madrid"  },
                new FutballPlayerDto { Id=2, FirstName = "Xavi", LastName = "Hernandez", FutballTeam = "Barcelona"  }
            };
        }

        public Task<FutballPlayerDto> GetFutballPlayerById(long futballPlayerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FutballPlayerDto>> GetAllFutballPlayers()
        {
            return await Task.Run(() => GetListOfPlayers()).ConfigureAwait(false);
        }

        private List<FutballPlayerDto> GetListOfPlayers()
        {
            return _listOfPlayers;
        }

        public Task<FutballPlayerDto> AddNewFutballPlayer(FutballPlayerDto futballPlayer)
        {
            var newFutballPlayer = new FutballPlayerDto
            {
                Id = futballPlayer.Id,
                FirstName = futballPlayer.FirstName,
                LastName = futballPlayer.LastName,
                FutballTeam = futballPlayer.FutballTeam,
            };

            _listOfPlayers.Add(newFutballPlayer);

            return Task.Run(() =>
            {
                return newFutballPlayer; 
            }) ;
        }
    }
}
