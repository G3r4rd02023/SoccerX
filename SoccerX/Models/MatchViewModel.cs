using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerX.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerX.Models
{
    public class MatchViewModel: Match
    {
        public int GroupId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Local")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un equipo.")]
        public int LocalId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Visitante")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un equipo.")]
        public int VisitorId { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }

    }
}
