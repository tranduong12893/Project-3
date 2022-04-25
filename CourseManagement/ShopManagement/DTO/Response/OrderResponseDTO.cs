using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class OrderResponseDTO
    {
        public long id { get; set; }
        [Display(Name = "Tên Khách hàng")]
        public string customer_name { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string phone_number { get; set; }
        [Display(Name = "Địa Chỉ Giao Hàng")]
        public string address_shipping { get; set; }
        [Display(Name = "Chú Ý")]
        public string note { get; set; }
        [Display(Name = "Quốc GIa")]
        public string country_name { get; set; }
        [Display(Name = "Thành Phố")]
        public string city_name { get; set; }
        [Display(Name = "Quận/Huyện")]
        public string district_name { get; set; }
        [Display(Name = "Xã")]
        public string ward_name { get; set; }
        public int status { get; set; }
    }
}