using Microsoft.AspNetCore.Identity;
using SoccerX.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerX.Data.Entities
{
    public class User:IdentityUser
    {
        [Display(Name = "DNI")]
        [MaxLength(20, ErrorMessage = "El campo {0}  no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0}  no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0}  no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0}  no puede tener mas de {1} caracteres.")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public string PicturePath { get; set; }

        [Display(Name = "Rol")]
        public UserType UserType { get; set; }

        [Display(Name = "Equipo Favorito")]
        public Team Team { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Prediction> Predictions { get; set; }

    }
}
