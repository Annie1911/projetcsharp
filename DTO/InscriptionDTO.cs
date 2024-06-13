using System.ComponentModel.DataAnnotations;

namespace projetcsharp.DTO
{
    public class InscriptionDTO : ConnexionDTO
    {
        [Required]
        [Display(Name = "Nom complet")]
        public string NomComplet { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required]
        public string Role { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer Mot de passe")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
