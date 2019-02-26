namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OgolneInfo")]
    public partial class OgolneInfo
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string KierownikZmiany { get; set; }

        [StringLength(4000)]
        public string KomentarzKierownika { get; set; }

        public DateTime? NajblizszyAudyt { get; set; }

        [StringLength(4000)]
        public string KomentarzTwojeStanowiska { get; set; }

        public DateTime? AktualnyCzas { get; set; }

        public decimal? TemperaturaNaHali { get; set; }

        public DateTime? OstatniaKontrolaMaszyny { get; set; }
    }
}
