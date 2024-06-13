using projetcsharp.DTO;
using projetcsharp.Reponse;

namespace projetcsharp.Service
{
    public interface ICompte
    {
        Task<ServiceReponse> InscriptionAsync(InscriptionDTO model);
        Task<ServiceReponse> ConnexionAsync(ConnexionDTO model);
    }
}
