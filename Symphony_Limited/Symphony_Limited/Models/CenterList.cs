using System;
using System.Collections.Generic;

namespace Symphony_Limited.Models
{
    public partial class CenterList
    {
        public int Id { get; set; }
        public string CenterName { get; set; } = null!;
        public int Tel { get; set; }
        public string Address { get; set; } = null!;
        public string Map { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Title { get; set; } = null!;
        public short Status { get; set; }
    }
}
