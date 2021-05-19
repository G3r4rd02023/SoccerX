using SoccerX.Data.Entities;
using SoccerX.Models;

namespace SoccerX.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Team ToTeam(TeamViewModel model, string path, bool isNew)
        {
            return new Team
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                LogoPath = team.LogoPath,
                Name = team.Name
            };
        }

        public Tournament ToTournament(TournamentViewModel model, string path, bool isNew)
        {
            return new Tournament
            {
                EndDate = model.EndDate.ToUniversalTime(),
                Groups = model.Groups,
                Id = isNew ? 0 : model.Id,
                IsActive = model.IsActive,
                LogoPath = path,
                Name = model.Name,
                StartDate = model.StartDate.ToUniversalTime()
            };
        }

        public TournamentViewModel ToTournamentViewModel(Tournament tournamentEntity)
        {
            return new TournamentViewModel
            {
                EndDate = tournamentEntity.EndDate,
                Groups = tournamentEntity.Groups,
                Id = tournamentEntity.Id,
                IsActive = tournamentEntity.IsActive,
                LogoPath = tournamentEntity.LogoPath,
                Name = tournamentEntity.Name,
                StartDate = tournamentEntity.StartDate
            };
        }

    }

}
