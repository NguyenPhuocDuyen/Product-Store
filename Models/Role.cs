using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool? IsDelete { get; set; } = false;

        public virtual ICollection<User> Users { get; set; }
    }
}
