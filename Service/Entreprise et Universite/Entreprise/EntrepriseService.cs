using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using projetcsharp.Data;
using projetcsharp.DTO.Entreprises_et_Universites;
using projetcsharp.Models.Entites;
using projetcsharp.Reponse;

namespace projetcsharp.Service.Entreprise_et_Universite.Entreprise
{
    public class EntrepriseService : IEntreprise
    {
        private readonly ContextDeBaseDeDonnee _context;

        public EntrepriseService(ContextDeBaseDeDonnee context)
        {
            _context = context;
        }
        
        public async Task<ServiceReponse> AddEntrepriseAsync(EntrepriseDTO model)
        {
            var dbentreprise = await _context.Entreprises.FindAsync(model.Name);
            if(dbentreprise == null)
            {
                return new ServiceReponse(false, "L'entreprise existe déjà");
            }
            else
            {
                try
                {
                    var entreprise = new EntrepriseModel()
                    {
                        Nom = model.Name,
                    };

                    _context.Entreprises.Add(entreprise);

                    await _context.SaveChangesAsync();


                }
                catch (Exception ex)
                {
                    return new ServiceReponse(false, ex.Message);
                }
            }
            return new ServiceReponse(true, "Entreprise ajoutée");
        }

    public Task<ServiceReponse> DeleteEntrepriseAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EntrepriseModel>> GetAllEntrepriseAsync()
        {
            return await _context.Entreprises.ToListAsync();
        }

        public Task<EntrepriseModel> GetEntrepriseAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceReponse> UpdateEntrepriseAsy(EntrepriseDTO Model)
        {
            throw new NotImplementedException();
        }
    }
}
