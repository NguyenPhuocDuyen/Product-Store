using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
