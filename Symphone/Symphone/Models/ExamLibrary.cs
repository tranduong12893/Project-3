using System;
using System.Collections.Generic;

namespace Symphone.Models
{
    public partial class ExamLibrary
    {
        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public string A { get; set; } = null!;
        public string B { get; set; } = null!;
        public string C { get; set; } = null!;
        public string D { get; set; } = null!;
        public string CorrectQues { get; set; } = null!;
    }
}
