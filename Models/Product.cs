using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;
        public int? RecentPrice { get; set; } = 0;
        public string Thumbnail { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public int? Amount { get; set; } = 0;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
