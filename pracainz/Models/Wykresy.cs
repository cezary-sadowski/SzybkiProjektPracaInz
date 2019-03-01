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

        public double? CzasPracyOperatora { get; set; }

        public double? CzasPrzestoj { get; set; }

        public double? CzasPrzezbrojen { get; set; }

        public double? CzasKJ { get; set; }

        public double? CzasTechnolog { get; set; }

        public double? CzasAudyt { get; set; }
    }
}
