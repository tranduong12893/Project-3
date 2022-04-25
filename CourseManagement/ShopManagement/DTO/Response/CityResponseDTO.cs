using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class CityResponseDTO
    {
        public long id { get; set; }
        [Display(Name = "Quốc Gia")]
        public string country_name { get; set; }
        [Display(Name = "Tên Thành Phố")]
        public string city_name { get; set; }
    }
}