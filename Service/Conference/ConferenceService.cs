using Microsoft.EntityFrameworkCore;
using projetcsharp.Data;
using projetcsharp.Models.Entites;

namespace projetcsharp.Service.Conference
{
    public class ConferenceService : IConference
    {
        private readonly ContextDeBaseDeDonnee _context;
        public ConferenceService(ContextDeBaseDeDonnee context)
        {
            _context = context;
        }

        public async Task<List<ConferenceModel>> GetAllConferencesAsync()
        {
            return await _context.Conferences.ToListAsync();
        }
    }
}
