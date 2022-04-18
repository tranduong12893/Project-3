using System;
using System.Collections.Generic;

namespace Symphone.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Ques { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
