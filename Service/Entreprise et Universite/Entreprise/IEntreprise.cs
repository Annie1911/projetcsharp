using projetcsharp.DTO.Entreprises_et_Universites;
using projetcsharp.Models.Entites;
using projetcsharp.Reponse;

namespace projetcsharp.Service.Entreprise_et_Universite.Entreprise
{
    public interface IEntreprise
    {
        Task<List<EntrepriseModel>> GetAllEntrepriseAsync();
        Task<EntrepriseModel> GetEntrepriseAsync(int Id);
        Task<ServiceReponse> AddEntrepriseAsync(EntrepriseDTO Model);
        Task<ServiceReponse> DeleteEntrepriseAsync(int Id);
        Task<ServiceReponse> UpdateEntrepriseAsy(EntrepriseDTO Model);
    }
}
