using System.ComponentModel.DataAnnotations;

namespace projetcsharp.Models.Entites
{
    public class EntrepriseModel
    {
    [Key]
    public int Id { get; set; }
    public string Nom { get; set; }
    public virtual ICollection<AuteurModel> Auteurs { get; set; }
}

}
