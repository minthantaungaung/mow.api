using System;
using System.Collections.Generic;

namespace api.mov.Models
{
    public partial class Relationship
    {
        public int RelationshipId { get; set; }
        public int? ParentId { get; set; }
        public int? ChildId { get; set; }
        public string? ParentTableName { get; set; }
        public string? ChildTableName { get; set; }
        public string? Udef1 { get; set; }
    }
}
