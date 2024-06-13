namespace projetcsharp.Models.Entites
{
    public class ArticleAuteurModel
    {
        public int ArticleId { get; set; }
        public ArticleModel Article { get; set; }

        public int AuteurId { get; set; }
        public AuteurModel Auteur { get; set; }
    }
}
