namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            courses_student = new HashSet<courses_student>();
        }

        public long id { get; set; }

        [StringLength(50)]
        public string student_code { get; set; }

        [StringLength(200)]
        public string student_name { get; set; }

        [StringLength(50)]
        public string phone_number { get; set; }

        public string address { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<courses_student> courses_student { get; set; }
    }
}
