using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IFutballPlayersRepository : IRepository<Todos>
    {
        public Task<IList<Todos>> GetAllFutballPlayers(Expression<Func<Todos, bool>> predicate = null)
        public Task<Todos> AddNewFutballPlayer(FutballPlayerDto futballPlayer);
    }
}
