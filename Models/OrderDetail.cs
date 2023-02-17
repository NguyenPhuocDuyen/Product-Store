using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? Amount { get; set; } = 0;
        public int? PaymentPrice { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
