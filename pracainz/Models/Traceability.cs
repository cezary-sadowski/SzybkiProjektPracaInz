namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Traceability")]
    public partial class Traceability
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string DostawcaCzesci { get; set; }

        public int? NrDostawy { get; set; }

        public int? PunktWejscia { get; set; }

        public int? AktualneStanowisko { get; set; }

        public int? AktualnyOperatorID { get; set; }

        public int? NrZlecenia { get; set; }

        public DateTime? DataDostarczenia { get; set; }

        public int? PoczatkowaIloscCzesci { get; set; }
    }
}
