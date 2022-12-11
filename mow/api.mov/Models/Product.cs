using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDesc { get; set; }
        public string? Image { get; set; }
    }
}
