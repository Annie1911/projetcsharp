namespace projetcsharp.Models.Entites
{
    public class RelecteurModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }

    public virtual ICollection<RelectureModel> Relecture { get; }
}

}
