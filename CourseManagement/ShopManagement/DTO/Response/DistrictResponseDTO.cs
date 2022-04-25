using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class DistrictResponseDTO
    {
        public long id { get; set; }
        [Display(Name = "Quốc Gia")]
        public string country_name { get; set; }
        [Display(Name = "Thành Phố")]
        public string city_name { get; set; }
        [Display(Name = "Quận/Huyện")]
        public string district_name { get; set; }
    }
}