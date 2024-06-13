namespace projetcsharp.Models.Entites
{
    public class UniversiteModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public virtual ICollection<AuteurModel> Auteurs { get; set; }
}

}