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
        public virtual DbSet<SpisPracownikow> SpisPracownikow { get; set; }
        public virtual DbSet<WzoryWezwan> WzoryWezwan { get; set; }
        public virtual DbSet<Zlecenie> Zlecenie { get; set; }
        public virtual DbSet<PosredniaWezwaniaPracownicy> PosredniaWezwaniaPracownicy { get; set; }
        public virtual DbSet<SpisWezwania> SpisWezwania { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
