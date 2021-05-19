using SoccerX.Data.Entities;
using SoccerX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerX.Helpers
{
    public interface IConverterHelper
    {
        Team ToTeam(TeamViewModel model, string path, bool isNew);

        TeamViewModel ToTeamViewModel(Team team);

        Tournament ToTournament(TournamentViewModel model, string path, bool isNew);

        TournamentViewModel ToTournamentViewModel(Tournament tournament);


    }
}
