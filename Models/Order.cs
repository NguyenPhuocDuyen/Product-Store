using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string OrderAddress { get; set; } = string.Empty;
        public int? StatusId { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
