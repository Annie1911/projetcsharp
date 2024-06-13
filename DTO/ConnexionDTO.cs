using System.ComponentModel.DataAnnotations;

namespace projetcsharp.DTO
{
    public class ConnexionDTO 
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
