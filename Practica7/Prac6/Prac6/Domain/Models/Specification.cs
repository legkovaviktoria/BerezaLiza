using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Specification
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
