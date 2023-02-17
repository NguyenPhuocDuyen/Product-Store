using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int? RoleId { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
