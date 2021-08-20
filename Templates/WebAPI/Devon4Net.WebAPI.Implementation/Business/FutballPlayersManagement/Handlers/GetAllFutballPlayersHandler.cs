using Devon4Net.Infrastructure.MediatR.Domain.ServiceInterfaces;
using Devon4Net.Infrastructure.MediatR.Handler;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Exceptions;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Queries;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Handlers
{
    public class GetAllFutballPlayersHandler : MediatrRequestHandler<GetAllFutballPlayersQuery, List<FutballPlayerDto>>
    {
        private IFutballPlayersService FutballPlayersService { get; set; }

        public GetAllFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupService mediatRBackupService, IMediatRBackupLiteDbService mediatRBackupLiteDbService) : base(mediatRBackupService, mediatRBackupLiteDbService)
        {
            Setup(futballPlayersService);
        }

        public GetAllFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupLiteDbService mediatRBackupLiteDbService) : base(mediatRBackupLiteDbService)
        {
            Setup(futballPlayersService);
        }

        public GetAllFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupService mediatRBackupService) : base(mediatRBackupService)
        {
            Setup(futballPlayersService);
        }

        private void Setup(IFutballPlayersService futballPlayersService)
        {
            FutballPlayersService = futballPlayersService;
        }

        public override async Task<List<FutballPlayerDto>> HandleAction(GetAllFutballPlayersQuery request, CancellationToken cancellationToken)
        {
            if (FutballPlayersService == null)
            {
                throw new FutballPlayersNotFoundException("The service 'FutballPlayersService' is not ready. Please check your dependency injection declaration for this service");
            }

            var result = await FutballPlayersService.GetAllFutballPlayers().ConfigureAwait(false);

            if (result == null)
            {
                throw new ArgumentException("The Futball Player list was not found");
            }

            return result;
        }
    }
}
