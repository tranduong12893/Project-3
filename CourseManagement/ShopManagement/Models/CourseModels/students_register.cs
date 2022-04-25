namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class students_register
    {
        public long id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string phone_number { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        public int? status { get; set; }

        public long? course_type_id { get; set; }

        public long? course_id { get; set; }

        public bool pracetice { get; set; }

        public virtual cours cours { get; set; }

        public virtual courses_type courses_type { get; set; }

        public int? payment_method { get; set; }
    }
}
