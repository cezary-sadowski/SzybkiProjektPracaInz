namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        public int ID { get; set; }

        public int? ZlecenieID { get; set; }

        public DateTime? DataRozpoczecia { get; set; }

        public DateTime? DataZakonczenia { get; set; }

        public int? OperatorId { get; set; }

        [StringLength(100)]
        public string KodProduktu { get; set; }

        [StringLength(100)]
        public string NazwaProduktu { get; set; }

        [StringLength(4000)]
        public string Komentarz { get; set; }

        [StringLength(100)]
        public string NazwaOperatora { get; set; }
    }
}
