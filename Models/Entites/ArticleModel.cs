namespace projetcsharp.Models.Entites
{
    public class ArticleModel
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public string PdfFilePath { get; set; }
    public int ConferenceId { get; set; }
    public ConferenceModel Conference { get; set; }
    public virtual ICollection<AuteurModel> CoAuteur { get; set; }
    public virtual ICollection<RelectureModel> Relecture { get; set; }
}

}
