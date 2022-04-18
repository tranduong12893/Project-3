using System;
using System.Collections.Generic;

namespace Symphone.Models
{
    public partial class CourseList
    {
        public int Id { get; set; }
        public string NameCourse { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Price { get; set; } = null!;
        public short Status { get; set; }
        public string Topic { get; set; } = null!;
    }
}
