using Microsoft.AspNetCore.Http;
using SoccerX.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SoccerX.Models
{
    public class TournamentViewModel:Tournament
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }

    }
}
