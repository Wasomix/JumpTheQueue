using Devon4Net.Infrastructure.MediatR.Query;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using System.Collections.Generic;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Queries
{
    public class GetAllFutballPlayersQuery : QueryBase<List<FutballPlayerDto>>
    {
        public GetAllFutballPlayersQuery()
        {

        }
    }
}
