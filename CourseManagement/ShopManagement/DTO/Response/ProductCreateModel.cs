using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class ProductCreateModel
    {
        public long id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string product_name { get; set; }

        [Display(Name = "Thể Loại")]
        public int? category { get; set; }

        [Display(Name = "Đơn GIá")]
        public decimal? price { get; set; }
        [Display(Name = "hình Ảnh")]
        public string image_url { get; set; }
        [Display(Name = "Mô Tả")]
        public string description { get; set; }
        [Display(Name = "Thể Loại")]
        public IEnumerable<category> categories { get; set; }
    }
}