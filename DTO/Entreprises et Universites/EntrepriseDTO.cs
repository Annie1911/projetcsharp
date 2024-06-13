using System.ComponentModel.DataAnnotations;

namespace projetcsharp.DTO.Entreprises_et_Universites
{
    public class EntrepriseDTO
    {

        [Required(ErrorMessage = "Veuillez saisir un nom")]
        public string Name { get; set; }
        
    }
}
