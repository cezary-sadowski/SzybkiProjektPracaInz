namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Technolog")]
    public partial class Technolog
    {
        public int ID { get; set; }

        public int? LoginTechnologa { get; set; }

        [StringLength(100)]
        public string NazwaTechnologa { get; set; }

        public DateTime? DataModyfikacji { get; set; }

        [StringLength(100)]
        public string PowodPrzestoju { get; set; }

        [StringLength(200)]
        public string Komentarz { get; set; }

        public bool? CzyProdukcjaWznowiona { get; set; }
    }
}
