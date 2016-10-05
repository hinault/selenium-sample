namespace SeleniumApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SeleniumAppDbContext : DbContext
    {
        public SeleniumAppDbContext()
            : base("name=SeleniumAppDbContext")
        {
        }

        public virtual DbSet<Etudiant> Etudiant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>()
                .Property(e => e.Nom)
                .IsFixedLength();

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.Prenom)
                .IsFixedLength();

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Etudiant>()
                .Property(e => e.Sexe)
                .IsFixedLength();
        }
    }
}
