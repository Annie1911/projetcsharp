using System.ComponentModel.DataAnnotations;

namespace projetcsharp.DTO.Membre_de_comite
{
    public class MembreComiteDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [MinLength(8)]

        public string ConfirmPassword { get; set; }
    }
}
