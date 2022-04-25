using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.DTO.Response
{
    public class WardResponseDTO
    {
        public long id { get; set; }

        public string country_name { get; set; }

        public string city_name { get; set; }

        public string district_name { get; set; }
        public string ward_name { get; set; }
    }
}