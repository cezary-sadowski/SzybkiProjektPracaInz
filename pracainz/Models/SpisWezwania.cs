namespace pracainz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpisWezwania")]
    public partial class SpisWezwania
    {
        public int ID { get; set; }

        [Required]
        [StringLength(450)]
        public string Nazwa { get; set; }

        public int TypyWezwanID { get; set; }

        public string TemplateSMS { get; set; }

        public string TemplateVoice { get; set; }

        public string TemplateMail { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModify { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreate { get; set; }

        public string AuthorCreate { get; set; }

        public string AuthorModify { get; set; }

        public bool SchouldBeAvailableIfNoOtVisualization { get; set; }

        public bool NeedConfirmation { get; set; }

        public bool? Active { get; set; }
    }
}
