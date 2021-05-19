using SoccerX.Data.Entities;
using SoccerX.Models;

namespace SoccerX.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Team ToTeamEntity(TeamViewModel model, string path, bool isNew)
        {
            return new Team
            {
                Id = isNew ? 0 : model.Id,
                LogoPath = path,
                Name = model.Name
            };
        }

        public TeamViewModel ToTeamViewModel(Team teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                LogoPath = teamEntity.LogoPath,
                Name = teamEntity.Name
            };
        }
    }

}
