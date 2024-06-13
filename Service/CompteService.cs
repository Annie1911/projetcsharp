using Microsoft.AspNetCore.Identity;
using projetcsharp.DTO;
using projetcsharp.Models;
using projetcsharp.Reponse;
using System.Security.Claims;

namespace projetcsharp.Service
{
    public class CompteService : ICompte
    {
        private readonly UserManager<Utilisateur> userManager;
        private readonly SignInManager<Utilisateur> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CompteService(UserManager<Utilisateur> userManager, SignInManager<Utilisateur> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<ServiceReponse> ConnexionAsync(ConnexionDTO model)
        {
            var dbUser = await userManager.FindByEmailAsync(model.EmailAddress);

            if(dbUser == null)
            {
                return new ServiceReponse(false, "Utilisateur non trouvé");
            }

            string getRole;

            try
            {
                getRole = (await userManager.GetRolesAsync(dbUser!)).FirstOrDefault();
            }catch (Exception ex)
            {
                return new ServiceReponse(false, ex.Message);

            }

            List<Claim> claims = new List<Claim>();

            try
            {
            {
                    claims.Add(new Claim(ClaimTypes.Name, dbUser.NomComplete));
                    claims.Add(new Claim(ClaimTypes.Email, dbUser.Email));
                    claims.Add(new Claim(ClaimTypes.Role, getRole));
            };
            } catch(Exception ex)
            {
                return new ServiceReponse(false, ex.Message);
            }
            var result = await signInManager.CheckPasswordSignInAsync(dbUser, model.Password, false);
            if(!result.Succeeded)
            {
                return new ServiceReponse(false, "Information invalide");
            }
            await signInManager.SignInWithClaimsAsync(dbUser, false, claims);
            return new ServiceReponse(true, "Connexion réussie");
        }

        public async Task<ServiceReponse> InscriptionAsync(InscriptionDTO model)
        {
            var dbUser = await userManager.FindByEmailAsync(model.EmailAddress);

            if (dbUser != null)
            {
                return new ServiceReponse(false, "Utilisateur existe déjà");
            }

            var appUser = new Utilisateur()
            {
                NomComplete = model.NomComplet,
                UserName = model.EmailAddress,
                Email = model.EmailAddress,
                PasswordHash = model.Password,
                Adresse = model.Adresse,
                Role = model.Role
            };

            var createUser = await userManager.CreateAsync(appUser, model.Password);

            if (createUser.Succeeded)
            {
                var adminRole = await roleManager.FindByNameAsync("Admin");
                if (adminRole is null && model.Role != "Admin")
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    appUser.Role = "Admin";
                    await userManager.AddToRoleAsync(appUser, "Admin");
                } else
                {
                    var userRole = await roleManager.FindByNameAsync(model.Role);
                    if(userRole is null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(model.Role));
                    }
                    await userManager.AddToRoleAsync(appUser, model.Role);
                }
                return new ServiceReponse(true, "Utilisateur crée avec succès");
            }
            return new ServiceReponse(false, createUser.ToString());
        }
    }
}
