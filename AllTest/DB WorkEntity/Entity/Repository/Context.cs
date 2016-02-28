namespace DB_WorkEntity.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DB_WorkEntity.Entity.Domain;

    public partial class TestContext : DbContext
    {
        public TestContext()
            : base("name=test1")
        {
        }

        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Fuel> Fuel { get; set; }
        public virtual DbSet<Tov_all> Tov_all { get; set; }
        public virtual DbSet<ViewEndDay> ViewEndDay { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Fuel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tov_all>()
                .Property(e => e.Cardcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tov_all>()
                .Property(e => e.Kod_city)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tov_all>()
                .Property(e => e.Klient)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tov_all>()
                .Property(e => e.Kod_pred)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ViewEndDay>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
