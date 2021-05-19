using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerX.Data.Entities
{
    public class GroupDetail
    {
        [Key]
        public int Id { get; set; }

        public Team Team { get; set; }

        [Display(Name = "PJ")]
        public int MatchesPlayed { get; set; }

        [Display(Name = "PG")]
        public int MatchesWon { get; set; }

        [Display(Name = "PE")]
        public int MatchesTied { get; set; }

        [Display(Name = "PP")]
        public int MatchesLost { get; set; }

        public int Points => MatchesWon * 3 + MatchesTied;

        [Display(Name = "GF")]
        public int GoalsFor { get; set; }

        [Display(Name = "GC")]
        public int GoalsAgainst { get; set; }

        public int GoalDifference => GoalsFor - GoalsAgainst;

        public Group Group { get; set; }

    }
}
