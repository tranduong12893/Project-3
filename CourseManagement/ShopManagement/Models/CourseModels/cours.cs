namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("courses")]
    public partial class cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cours()
        {
            courses_student = new HashSet<courses_student>();
            students_register = new HashSet<students_register>();
        }

        public long id { get; set; }

        [StringLength(100)]
        public string course_name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }


        [Column(TypeName = "text")]
        public string out_line { get; set; }

        public long? category_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start_date_plan { get; set; }

        [StringLength(200)]
        public string image { get; set; }

        [StringLength(200)]
        public string short_description { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<courses_student> courses_student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<students_register> students_register { get; set; }
    }
}
