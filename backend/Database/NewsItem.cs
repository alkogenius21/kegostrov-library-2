using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Database {
    public class NewsItem {
        [Key]
        public Guid NewsItemId { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public AppUser Author { get; set; }
        public DateOnly PublishDate { get; set; }
    }
}