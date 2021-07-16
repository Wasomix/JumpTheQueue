using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IFutballPlayersRepository : IRepository<FutballPlayers>
    {
        public Task<IList<FutballPlayers>> GetAllFutballPlayers(Expression<Func<FutballPlayers, bool>> predicate = null);
        public Task<FutballPlayers> AddNewFutballPlayer(FutballPlayerDto futballPlayer);
    }
}
