namespace projetcsharp.Models.Entites
{
    public class ParticipantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<ConferenceModel> Conferences { get; set; }
    }

}
