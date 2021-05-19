using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerX.Data.Entities
{
    public class Match
    {
       [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha")]
        public DateTime DateLocal => Date.ToLocalTime();

        public Team Local { get; set; }

        public Team Visitor { get; set; }

        [Display(Name = "Local")]
        public int GoalsLocal { get; set; }

        [Display(Name = "Visita")]
        public int GoalsVisitor { get; set; }

        [Display(Name = "Finalizado?")]
        public bool IsClosed { get; set; }

        public Group Group { get; set; }

    }
}
