using Devon4Net.Infrastructure.RabbitMQ.Commands;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Commands
{
    public class AddNewFutballPlayerCommandRabbitMq : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FutballTeam { get; set; }

        public AddNewFutballPlayerCommandRabbitMq()
        {

        }

        public AddNewFutballPlayerCommandRabbitMq(FutballPlayerDto futballPlayer)
        {
            FirstName = futballPlayer.FirstName;
            LastName = futballPlayer.LastName;
            FutballTeam = futballPlayer.FutballTeam;
        }
    }
}
