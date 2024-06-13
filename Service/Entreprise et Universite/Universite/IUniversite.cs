using projetcsharp.DTO.Entreprises_et_Universites;
using projetcsharp.Models.Entites;
using projetcsharp.Reponse;

namespace projetcsharp.Service.Entreprise_et_Universite.Universite
{
    public interface IUniversite
    {
        Task<List<UniversiteModel>> GetAllUniversiteAsync();
        Task<UniversiteModel> GetUniversite(int Id);
        Task<ServiceReponse> AddUniversite(UniversiteDTO Model);
        Task<ServiceReponse> DeleteUniversite(int Id);
        Task<ServiceReponse> UpdateUniversite(UniversiteDTO Model);
    }
}
