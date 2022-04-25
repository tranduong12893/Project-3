namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("branchs")]
    public partial class branch
    {
        public long id { get; set; }

        [StringLength(100)]
        public string branch_name { get; set; }

        public string address { get; set; }

        [StringLength(50)]
        public string phone_number { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
