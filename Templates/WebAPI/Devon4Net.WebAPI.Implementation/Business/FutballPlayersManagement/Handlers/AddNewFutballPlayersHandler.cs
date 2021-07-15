using Devon4Net.Infrastructure.MediatR.Domain.ServiceInterfaces;
using Devon4Net.Infrastructure.MediatR.Handler;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Commands;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Handlers
{
    public class AddNewFutballPlayersHandler : MediatrRequestHandler<AddNewFutballPlayerCommand, FutballPlayerDto>
    {
        private IFutballPlayersService FutballPlayersService { get; set; }

        public AddNewFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupService mediatRBackupService, IMediatRBackupLiteDbService mediatRBackupLiteDbService) : base(mediatRBackupService, mediatRBackupLiteDbService)
        {
            Setup(futballPlayersService);
        }

        public AddNewFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupLiteDbService mediatRBackupLiteDbService) : base(mediatRBackupLiteDbService)
        {
            Setup(futballPlayersService);
        }

        public AddNewFutballPlayersHandler(IFutballPlayersService futballPlayersService, IMediatRBackupService mediatRBackupService) : base(mediatRBackupService)
        {
            Setup(futballPlayersService);
        }

        private void Setup(IFutballPlayersService futballPlayersService)
        {
            FutballPlayersService = futballPlayersService;
        }


        public override async Task<FutballPlayerDto> HandleAction(AddNewFutballPlayerCommand request, CancellationToken cancellationToken)
        {

            if (FutballPlayersService == null)
            {
                throw new ArgumentException("The service 'FutballPlayersService' is not ready. Please check your dependency injection declaration for this service");
            }

            var futballPlayer = new FutballPlayerDto
            {
                Id = 1,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FutballTeam = request.FutballTeam,
            };


            var result = await FutballPlayersService.AddNewFutballPlayer(futballPlayer).ConfigureAwait(false);

            return result;

        }
    }
}
