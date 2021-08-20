using Devon4Net.Infrastructure.MediatR.Command;
using Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Dto;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Commands
{
    public class AddNewFutballPlayerCommand : CommandBase<FutballPlayerDto>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FutballTeam { get; }

        public AddNewFutballPlayerCommand()
        {

        }

        public AddNewFutballPlayerCommand(FutballPlayerDto futballPlayer)
        {
            FirstName = futballPlayer.FirstName;
            LastName = futballPlayer.LastName;
            FutballTeam = futballPlayer.FutballTeam;
        }
    }
}
