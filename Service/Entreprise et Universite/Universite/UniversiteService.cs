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

        public async Task<ServiceReponse> AddUniversiteAsync(UniversiteDTO model)
        {
            var dbUniversite = await _context.Universites.FirstOrDefaultAsync(e => e.Nom == model.Name);
            if (dbUniversite != null)
            {
                return new ServiceReponse(false, "L'Université existe déjà");
            }

            try
            {
                var universite = new UniversiteModel
                {
                    Nom = model.Name,
                };

                _context.Universites.Add(universite);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ServiceReponse(false, ex.Message);
            }

            return new ServiceReponse(true, "Universite ajoutée");
        }


        public Task<ServiceReponse> DeleteUniversiteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UniversiteModel>> GetAllUniversiteAsync()
        {
            return await _context.Universites.ToListAsync();
        }

        public Task<UniversiteModel> GetUniversiteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse> UpdateUniversiteAsync(UniversiteDTO Model)
        {
            throw new NotImplementedException();
        }
    }
}
