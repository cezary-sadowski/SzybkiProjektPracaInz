namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wykresy")]
    public partial class Wykresy
    {
        public int ID { get; set; }

        public decimal? CzasPracyOperatora { get; set; }

        public decimal? CzasPrzestoj { get; set; }

        public decimal? CzasPrzezbrojen { get; set; }

        public decimal? CzasKJ { get; set; }

        public decimal? CzasTechnolog { get; set; }

        public decimal? CzasAudyt { get; set; }
    }
}
