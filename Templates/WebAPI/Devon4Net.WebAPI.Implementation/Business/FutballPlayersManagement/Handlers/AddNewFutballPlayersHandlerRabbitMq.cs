using Devon4Net.Infrastructure.RabbitMQ.Domain.ServiceInterfaces;
using Devon4Net.Infrastructure.RabbitMQ.Handlers;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Commands;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Service;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Handlers
{
    public class AddNewFutballPlayersHandlerRabbitMq : RabbitMqHandler<AddNewFutballPlayerCommandRabbitMq>
    {
        private IFutballPlayersService FutballPlayerService { get; set; }

        public AddNewFutballPlayersHandlerRabbitMq(IServiceCollection services, IBus serviceBus, bool subscribeToChannel = false) : base(services, serviceBus, subscribeToChannel)
        {
        }

        public AddNewFutballPlayersHandlerRabbitMq(IServiceCollection services, IBus serviceBus, IRabbitMqBackupService rabbitMqBackupService, bool subscribeToChannel = false) : base(services, serviceBus, rabbitMqBackupService, subscribeToChannel)
        {
        }

        public AddNewFutballPlayersHandlerRabbitMq(IServiceCollection services, IBus serviceBus, IRabbitMqBackupLiteDbService rabbitMqBackupLiteDbService, bool subscribeToChannel = false) : base(services, serviceBus, rabbitMqBackupLiteDbService, subscribeToChannel)
        {
        }

        public AddNewFutballPlayersHandlerRabbitMq(IServiceCollection services, IBus serviceBus, IRabbitMqBackupService rabbitMqBackupService, IRabbitMqBackupLiteDbService rabbitMqBackupLiteDbService, bool subscribeToChannel = false) : base(services, serviceBus, rabbitMqBackupService, rabbitMqBackupLiteDbService, subscribeToChannel)
        {
        }

        public override async Task<bool> HandleCommand(AddNewFutballPlayerCommandRabbitMq command)
        {
            FutballPlayerService = GetInstance<IFutballPlayersService>();

            if (FutballPlayerService == null)
            {
                throw new ArgumentException("The service 'TodoService' is not ready. Please check your dependency injection declaration for this service");
            }

            var futballPlayer = new FutballPlayerDto
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                FutballTeam = command.FutballTeam,
            };

            var result = await FutballPlayerService.AddNewFutballPlayer(futballPlayer).ConfigureAwait(false);
            return result != null;
        }
    }
}
