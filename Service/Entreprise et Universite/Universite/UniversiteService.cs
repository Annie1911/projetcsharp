using Microsoft.EntityFrameworkCore;
using projetcsharp.Data;
using projetcsharp.DTO.Entreprises_et_Universites;
using projetcsharp.Models.Entites;
using projetcsharp.Reponse;

namespace projetcsharp.Service.Entreprise_et_Universite.Universite
{
    public class UniversiteService : IUniversite
    {

        private readonly ContextDeBaseDeDonnee _context;

        public UniversiteService(ContextDeBaseDeDonnee context)
        {
            _context = context;
        }

        public async Task<ServiceReponse> AddUniversite(UniversiteDTO Model)
        {
            var dbUniversite = await _context.Universites.FindAsync(Model.Name);
            if(dbUniversite.Equals(null))
            {
                return new ServiceReponse(false, $"{Model.Name}existe déjà");
            }
            try
            {
                var newUniversite = new UniversiteModel()
                {
                    Nom = Model.Name,
                };

            } catch (Exception ex)
            {
                return new ServiceReponse(false, $"{ex.Message}");
            }
            return new ServiceReponse(true, $"{Model.Name} ajoutée");
        }

        public Task<ServiceReponse> DeleteUniversite(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UniversiteModel>> GetAllUniversiteAsync()
        {
            return await _context.Universites.ToListAsync();
        }

        public Task<UniversiteModel> GetUniversite(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse> UpdateUniversite(UniversiteDTO Model)
        {
            throw new NotImplementedException();
        }
    }
}
