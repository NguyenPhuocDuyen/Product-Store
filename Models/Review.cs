using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? Rate { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
