namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Nazwa pracownika")]
        public string ImieNaziwsko { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("Obecny na produkcji")]
        public bool CzyObecny { get; set; }

        [StringLength(100)]
        [DisplayName("Typ pracownika")]
        public string TypPracownika { get; set; }
    }
}
