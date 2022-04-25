namespace CourseManagement.Models.CourseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public long id { get; set; }

        [StringLength(30)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? user_role { get; set; }
    }
}
