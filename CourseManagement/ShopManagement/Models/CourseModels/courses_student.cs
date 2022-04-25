namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class courses_student
    {
        public long id { get; set; }

        public long? student_id { get; set; }

        public long? course_id { get; set; }

        public long? course_type_id { get; set; }

        public int? score { get; set; }
        public bool pracetice { get; set; }
        public virtual cours cours { get; set; }

        public virtual courses_type courses_type { get; set; }

        public virtual student student { get; set; }
    }
}
