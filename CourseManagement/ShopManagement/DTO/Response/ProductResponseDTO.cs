using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class ProductResponseDTO
    {
        public long id { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string product_name { get; set; }

        [Display(Name = "Thể Loại")]
        public string category_name { get; set; }
        [Display(Name = "Giá Gốc")]
        public decimal? origin_price { get; set; }
        [Display(Name = "Giá Bán")]
        public decimal? price { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string image_url { get; set; }
        [Display(Name = "Mô Tả")]
        public string description { get; set; }

        public bool isPopular { get; set; }
        [Display(Name = "Màu Sắc")]
        public string color_name { get; set; }
        [Display(Name = "Kích Cỡ")]
        public string size_name { get; set; }
    }
}