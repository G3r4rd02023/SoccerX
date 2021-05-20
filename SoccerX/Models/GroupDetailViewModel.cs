using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerX.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerX.Models
{
    public class GroupDetailViewModel:GroupDetail
    {
        public int GroupId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Equipo")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Equipo.")]
        public int TeamId { get; set; }

        public IEnumerable<SelectListItem> Teams { get; set; }

    }
}
