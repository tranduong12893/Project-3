namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class question
    {
        public long id { get; set; }

        public string question_name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }
    }
}
