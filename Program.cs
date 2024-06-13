using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projetcsharp.Authentification;
using projetcsharp.Components;
using projetcsharp.Data;
using projetcsharp.Models;
using projetcsharp.Service;
using projetcsharp.Service.Conference;
using projetcsharp.Service.Entreprise_et_Universite.Entreprise;
using projetcsharp.Service.Entreprise_et_Universite.Universite;

var builder = WebApplication.CreateBuilder(args);
var chaineDeConnexion = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ContextDeBaseDeDonnee>(options =>
{
    options.UseMySql(chaineDeConnexion, ServerVersion.AutoDetect(chaineDeConnexion));
});



builder.Services.AddScoped<IEntreprise, EntrepriseService>();
builder.Services.AddScoped<IUniversite, UniversiteService>();
builder.Services.AddScoped<IConference, ConferenceService>();

builder.Services.AddIdentity<Utilisateur, IdentityRole>(
        options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
        }
    ).AddEntityFrameworkStores<ContextDeBaseDeDonnee>().AddRoles<IdentityRole>().AddSignInManager().AddDefaultTokenProviders();

builder.Services.AddScoped<ICompte, CompteService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapDecoEndpoint();
app.Run();
