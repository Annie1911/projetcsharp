using projetcsharp.DTO.Entreprises_et_Universites;
using projetcsharp.Models.Entites;
using projetcsharp.Reponse;

namespace projetcsharp.Service.Entreprise_et_Universite.Universite
{
    public interface IUniversite
    {
        Task<List<UniversiteModel>> GetAllUniversiteAsync();
        Task<UniversiteModel> GetUniversiteAsync(int Id);
        Task<ServiceReponse> AddUniversiteAsync(UniversiteDTO Model);
        Task<ServiceReponse> DeleteUniversiteAsync(int Id);
        Task<ServiceReponse> UpdateUniversiteAsync(UniversiteDTO Model);
    }
}
