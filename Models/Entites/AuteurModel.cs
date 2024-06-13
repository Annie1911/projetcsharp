namespace projetcsharp.Models.Entites
{
    public class AuteurModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public int? UniversiteId { get; set; }
    public UniversiteModel? Universite { get; set; }
    public int? EntrepriseId { get; set; }
    public EntrepriseModel? Entreprise { get; set; }
    public virtual ICollection<ArticleModel> Articles { get; set; }
}

}
