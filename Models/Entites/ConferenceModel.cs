namespace projetcsharp.Models.Entites
{
    public class ConferenceModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Sigle { get; set; }
    public string Theme { get; set; }
    public DateTime SubmissionStartDate { get; set; }
    public DateTime SubmissionEndDate { get; set; }
    public DateTime ReviewStartDate { get; set; }
    public DateTime ReviewEndDate { get; set; }
    public DateTime RegistrationStartDate { get; set; }
    public DateTime RegistrationEndDate { get; set; }
    public DateTime ConferenceStartDate { get; set; }
    public DateTime ConferenceEndDate { get; set; }

    public virtual ICollection<ArticleModel> Articles { get; set; }
    public virtual ICollection<ParticipantModel> Participants { get; set; }
    }

}
