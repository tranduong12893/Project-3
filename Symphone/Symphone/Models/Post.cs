using System;
using System.Collections.Generic;

namespace Symphone.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Img { get; set; } = null!;
        public int UserId { get; set; }
        public string Topic { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
