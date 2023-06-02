using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ProductOrder
    {
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Value { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
