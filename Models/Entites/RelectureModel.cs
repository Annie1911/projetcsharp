namespace projetcsharp.Models.Entites
{
    public class RelectureModel
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public ArticleModel Article { get; set; }
    public int RelecteurId { get; set; }
    public RelecteurModel Relecteur { get; set; }
    public string Commentaire { get; set; }
    public string Statut { get; set; } 
}

}
