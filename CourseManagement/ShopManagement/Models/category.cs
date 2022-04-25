namespace CourseManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category Name")]
        public string category_name { get; set; }
        [Display(Name = "Image")]
        public string image_url { get; set; }
    }
}
