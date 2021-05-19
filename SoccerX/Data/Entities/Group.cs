using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerX.Data.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Tournament Tournament { get; set; }

        public ICollection<GroupDetail> GroupDetails { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
