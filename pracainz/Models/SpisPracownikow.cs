namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpisPracownikow")]
    public partial class SpisPracownikow
    {
        [Key]
        public int SpisID { get; set; }

        public int? Login { get; set; }

        [StringLength(100)]
        public string ImieNaziwsko { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool? CzyObecny { get; set; }

        [StringLength(100)]
        public string TypPracownika { get; set; }
    }
}
