using System;
using System.Collections.Generic;

namespace Symphone.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public short Type { get; set; }
        public short Status { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
