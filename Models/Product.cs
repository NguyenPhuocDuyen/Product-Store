using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Tên sản phẩm không được trống!")]
        [DisplayName("Tên sản phẩm")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mô tả sản phẩm không được trống!")]
        [DisplayName("Mô tả sản phẩm")]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá sản phẩm không được trống!")]
        [DisplayName("Giá sản phẩm")]
        [Range(1000, int.MaxValue, ErrorMessage = "Giá sản phẩm lớn hơn bằng 1,000 VND")]
        public int? RecentPrice { get; set; } = 0;

        public string Thumbnail { get; set; } = string.Empty;
        //public byte[] ThumbnailData { get; set; }

        //public int? UserId { get; set; }
        [Required(ErrorMessage = "Số lượng sản phẩm không được trống!")]
        [DisplayName("Số lượng sản phẩm")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng sản phẩm lớn hơn bằng 1")]
        public int? Amount { get; set; } = 0;
        
        [DisplayName("Danh mục sản phẩm")]
        public int? CategoryId { get; set; }
        
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? IsDelete { get; set; } = false;

        public virtual Category Category { get; set; }
        //public virtual User User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
