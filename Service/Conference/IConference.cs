using projetcsharp.Models.Entites;

namespace projetcsharp.Service.Conference
{
    public interface IConference
    {
        Task<List<ConferenceModel>> GetAllConferencesAsync();
    }
}
