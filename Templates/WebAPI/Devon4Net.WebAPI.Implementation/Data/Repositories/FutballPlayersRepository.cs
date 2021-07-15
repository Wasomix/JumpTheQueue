using Devon4Net.Infrastructure.Log;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Devon4Net.WebAPI.Implementation.Data.Repositories
{
    public class FutballPlayersRepository : IFutballPlayersRepository
    {
        /// <summary>
        /// GetAllFutballPlayers method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<Todos>> GetAllFutballPlayers(Expression<Func<Todos, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetAllFutballPlayers method from TodoRepository TodoService");
            return Get(predicate);
        }

        /*/// <summary>
        /// Geto the TODO by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Todos> GetTodoById(long id)
        {
            Devon4NetLogger.Debug($"GetTodoById method from repository TodoService with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }*/

        /// <summary>
        /// AddNewFutballPlayer
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public Task<Todos> AddNewFutballPlayer(FutballPlayerDto futballPlayer)
        {
            Devon4NetLogger.Debug("AddNewFutballPlayer method from repository FutballPlayersRepository");

            var todo = new Todos { Description = description };
            var result = TodosValidator.Validate(todo);

            if (!result.IsValid)
            {
                throw new ArgumentException($"The 'Description' field can not be null.{result.Errors}");
            }

            return Create(todo);
        }
    }
}
