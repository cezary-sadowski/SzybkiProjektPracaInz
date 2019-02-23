namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zlecenie")]
    public partial class Zlecenie
    {
        public int ID { get; set; }

        public int? SztukDoWykonania { get; set; }

        public int? SztukDobrych { get; set; }

        public int? SztukZlych { get; set; }

        [StringLength(200)]
        public string CzescAlternatywna { get; set; }

        public int? IloscWezwan { get; set; }

        [StringLength(4000)]
        public string Status { get; set; }

        public double? OEE { get; set; }

        public double? Dostepnosc { get; set; }

        public double? Wydajnosc { get; set; }

        public double? Jakosc { get; set; }

        public double? CzasPracyPlanowany { get; set; }

        public double? CzasPracyRealny { get; set; }

        public double? CzasPracyRzeczywisty { get; set; }
    }
}
