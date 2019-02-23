namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WzoryWezwan")]
    public partial class WzoryWezwan
    {
        public int ID { get; set; }

        [StringLength(4000)]
        public string SmsKJ { get; set; }

        [StringLength(4000)]
        public string EmailKJ { get; set; }

        [StringLength(4000)]
        public string SmsKierownik { get; set; }

        [StringLength(4000)]
        public string EmailKierownik { get; set; }

        [StringLength(4000)]
        public string SmsTechnolog { get; set; }

        [StringLength(4000)]
        public string EmailTechnolog { get; set; }
    }
}
