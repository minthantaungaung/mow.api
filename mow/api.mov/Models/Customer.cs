using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string Email { get; set; } = null!;
        public string? City { get; set; }
        public string? Township { get; set; }
        public string? DetailedAddress { get; set; }
        public string? Phone { get; set; }
        public string? Age { get; set; }
        public string? Password { get; set; }
    }
}
