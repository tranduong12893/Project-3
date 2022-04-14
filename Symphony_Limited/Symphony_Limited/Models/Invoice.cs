using System;
using System.Collections.Generic;

namespace Symphony_Limited.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int Tel { get; set; }
        public string Address { get; set; } = null!;
        public int Courseid { get; set; }
        public string Code { get; set; } = null!;
        public short Status { get; set; }
    }
}
