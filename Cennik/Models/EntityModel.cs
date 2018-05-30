namespace Cennik.Connection
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            Database.SetInitializer<EntityModel>(null);
        }

        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Przedmioty> Przedmioty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategorie>()
                .HasMany(e => e.Przedmioty)
                .WithOptional(e => e.Kategorie)
                .HasForeignKey(e => e.IdKategorii);
        }
    }
}
