using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Database;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class FutballPlayersRepository : Repository<FutballPlayers>, IFutballPlayersRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public FutballPlayersRepository(FutballPlayersContext context/*, TodosFluentValidator futballPlayersValidator*/) : base(context)
        {
            //FutballPlayersValidator = futballPlayersValidator;
        }

        /// <summary>
        /// GetAllFutballPlayers method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<FutballPlayers>> GetAllFutballPlayers(Expression<Func<FutballPlayers, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetAllFutballPlayers method from FutballPlayersRepository");
            return Get(predicate);
        }

        /// <summary>
        /// AddNewFutballPlayer
        /// </summary>
        /// <param name="futballPlayer"></param>
        /// <returns></returns>
        public Task<FutballPlayers> AddNewFutballPlayer(FutballPlayerDto futballPlayer)
        {
            Devon4NetLogger.Debug("AddNewFutballPlayer method from repository FutballPlayersRepository");

            var newFutballPlayer = new FutballPlayers 
            { 
                FirstName = futballPlayer.FirstName,
                LastName = futballPlayer.LastName,
                FutballTeam = futballPlayer.FutballTeam
            };

            return Create(newFutballPlayer);
        }
    }
}
