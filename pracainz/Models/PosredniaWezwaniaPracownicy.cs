namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PosredniaWezwaniaPracownicy")]
    public partial class PosredniaWezwaniaPracownicy
    {
        public int SpisWezwaniaID { get; set; }

        public int SpisPracownikowID { get; set; }

        public int ID { get; set; }

        public bool SendSMS { get; set; }

        public bool SendVoice { get; set; }

        public bool SendMail { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModify { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreate { get; set; }

        public string AuthorCreate { get; set; }

        public string AuthorModify { get; set; }
    }
}
