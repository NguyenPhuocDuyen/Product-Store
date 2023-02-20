using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
