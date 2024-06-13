using Microsoft.AspNetCore.Identity;

namespace projetcsharp.Models
{
    public class Utilisateur : IdentityUser
    {
        public string NomComplete { get; set; }
        public string Adresse { get; set; }
        public string Role { get; set; }
    }
}
