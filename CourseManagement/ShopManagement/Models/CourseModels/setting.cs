namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class setting
    {
        public long id { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        public string title { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }
    }
}
