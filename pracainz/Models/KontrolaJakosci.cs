namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KontrolaJakosci")]
    public partial class KontrolaJakosci
    {
        public int ID { get; set; }

        public int? ZlecenieID { get; set; }

        public int? LoginOperatoraKJ { get; set; }

        [StringLength(100)]
        public string NazwaOperatoraKJ { get; set; }

        public int? ZleSztukiPotwierdzone { get; set; }

        public int? ZleSztukiDoRegeneracji { get; set; }

        public int? ZleSztukiDoZlomowania { get; set; }

        public DateTime? DataModyfikacji { get; set; }
    }
}
