using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class User
    {
        public uint UserId { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }
}
