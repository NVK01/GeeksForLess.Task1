﻿using System.Text.Json.Serialization;

namespace GeeksForLess.Task1.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }

        [JsonIgnore]
        public Catalog? Parent { get; set; }
        [JsonIgnore]
        public List<Catalog>? Children { get; set; }
    }
}
