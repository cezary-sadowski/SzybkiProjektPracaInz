namespace pracainz.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ERP_DB : DbContext
    {
        public ERP_DB()
            : base("name=ERP_DB")
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<KontrolaJakosci> KontrolaJakosci { get; set; }
        public virtual DbSet<OgolneInfo> OgolneInfo { get; set; }
        public virtual DbSet<PosredniaWezwaniaPracownicy> PosredniaWezwaniaPracownicy { get; set; }
        public virtual DbSet<SpisPracownikow> SpisPracownikow { get; set; }
        public virtual DbSet<SpisWezwania> SpisWezwania { get; set; }
        public virtual DbSet<Technolog> Technolog { get; set; }
        public virtual DbSet<Wykresy> Wykresy { get; set; }
        public virtual DbSet<WzoryWezwan> WzoryWezwan { get; set; }
        public virtual DbSet<Zlecenie> Zlecenie { get; set; }
        public virtual DbSet<MSreplication_options> MSreplication_options { get; set; }
        public virtual DbSet<spt_fallback_db> spt_fallback_db { get; set; }
        public virtual DbSet<spt_fallback_dev> spt_fallback_dev { get; set; }
        public virtual DbSet<spt_fallback_usg> spt_fallback_usg { get; set; }
        public virtual DbSet<spt_monitor> spt_monitor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OgolneInfo>()
                .Property(e => e.TemperaturaNaHali)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasPracyOperatora)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasPrzestoj)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasPrzezbrojen)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasKJ)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasTechnolog)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Wykresy>()
                .Property(e => e.CzasAudyt)
                .HasPrecision(18, 0);

            modelBuilder.Entity<spt_fallback_db>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_db>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.xfallback_drive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_dev>()
                .Property(e => e.phyname)
                .IsUnicode(false);

            modelBuilder.Entity<spt_fallback_usg>()
                .Property(e => e.xserver_name)
                .IsUnicode(false);
        }
    }
}
