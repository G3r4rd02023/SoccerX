using Microsoft.AspNetCore.Http;
using SoccerX.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerX.Models
{
    public class TeamViewModel:Team
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }

    }
}
