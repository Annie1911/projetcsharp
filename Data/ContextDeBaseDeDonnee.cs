using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetcsharp.Models;
using projetcsharp.Models.Entites;

//using projetcsharp.Models.Entites;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace projetcsharp.Data
{
    public class ContextDeBaseDeDonnee : IdentityDbContext<Utilisateur>
    {
        public DbSet<UniversiteModel> Universites { get; set; }
        public DbSet<EntrepriseModel> Entreprises { get; set; }
        public DbSet<ConferenceModel> Conferences { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<AuteurModel> Auteur { get; set; }
        public DbSet<RelecteurModel> Relecteur { get; set; }
        public DbSet<RelectureModel> Relecture { get; set; }
        public DbSet<ParticipantModel> Participants { get; set; }
        public ContextDeBaseDeDonnee(DbContextOptions<ContextDeBaseDeDonnee> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Conference -> Article
            builder.Entity<ArticleModel>()
                .HasOne(a => a.Conference)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.ConferenceId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<EntrepriseModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<UniversiteModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<RelectureModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<ConferenceModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<ArticleModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            });
            builder.Entity<AuteurModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<RelecteurModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            }); builder.Entity<ParticipantModel>(ent =>
            {
                ent.HasKey(e => e.Id);
            });

            // Article -> Author 
            builder.Entity<ArticleModel>()
                .HasMany(a => a.CoAuteur)
                .WithMany(au => au.Articles)
                .UsingEntity(j => j.ToTable("ArticleAuteur"));
                

            // Relecture -> Article
            builder.Entity<RelectureModel>()
                .HasOne(r => r.Article)
                .WithMany(a => a.Relecture)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(r => r.ArticleId);

            // Relecture -> Relecteur
            builder.Entity<RelectureModel>()
                .HasOne(r => r.Relecteur)
                .WithMany(re => re.Relecture)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(r => r.RelecteurId);

            // Author -> University
            builder.Entity<AuteurModel>()
                .HasOne(a => a.Universite)
                .WithMany(u => u.Auteurs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.UniversiteId);

            // Author -> Company
            builder.Entity<AuteurModel>()
                .HasOne(a => a.Entreprise)
                .WithMany(c => c.Auteurs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(a => a.EntrepriseId);
            base.OnModelCreating(builder);
        }
    }
}
